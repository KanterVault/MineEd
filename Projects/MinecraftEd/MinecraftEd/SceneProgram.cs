using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.DirectInput;

namespace MinecraftEd
{
    public static class SceneProgram
    {
        public static string ERRORMESSAGE = "";
        public static string physDebag = "";
        public static float deltaTimerStr = 0.0f;

        private static System.Windows.Forms.Timer timerUpdate = new System.Windows.Forms.Timer();

        private static void ViewInLogLabel()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("X: ");
            sb.Append(MouseAndKeyboardEvents.mainXrot.ToString());
            sb.Append("\nY: ");
            sb.Append(MouseAndKeyboardEvents.mainYrot.ToString());
            sb.Append("\nKeysPress: ");
            for (int a = 0; a < MouseAndKeyboardEvents.keys.Length; a++) sb.Append(MouseAndKeyboardEvents.keys[a].ToString());
            sb.Append("\nKeysDirections: ");
            sb.Append(MouseAndKeyboardEvents.xdir);
            sb.Append(" | ");
            sb.Append(MouseAndKeyboardEvents.ydir);
            sb.Append("\n   Cos: ");
            sb.Append(Math.Cos(MouseAndKeyboardEvents.DegresToRadian(MouseAndKeyboardEvents.mainXrot)).ToString());
            sb.Append("\n   Sin: ");
            sb.Append(Math.Cos(MouseAndKeyboardEvents.DegresToRadian(MouseAndKeyboardEvents.mainXrot)).ToString());
            sb.Append("\nPlayer direction: ");
            sb.Append("\n   z: " + MouseAndKeyboardEvents.movePlayerDirections.Z);
            sb.Append("\n   x: " + MouseAndKeyboardEvents.movePlayerDirections.X);
            //if (ERRORMESSAGE.Length > 20) sb.Append("\n" + ERRORMESSAGE.PadLeft(ERRORMESSAGE.Length - 20));
            sb.Append("\nPlayer World position:");
            sb.Append("\n   x: " + PlayerMoving.playerWorldPosition.X);
            sb.Append("\n   y: " + PlayerMoving.playerWorldPosition.Y);
            sb.Append("\n   z: " + PlayerMoving.playerWorldPosition.Z);
            sb.Append("\nCollision: " + physDebag);
            sb.Append("\nDeltatime: " + deltaTimerStr);
            sb.Append("\nMouseLock: " + MouseAndKeyboardEvents.mouseLook);
            sb.Append("\nLerpCameraPosition:");
            sb.Append("\n   x: " + RenderLineScene.translationsBefore.X);
            sb.Append("\n   y: " + RenderLineScene.translationsBefore.Y);
            sb.Append("\n   z: " + RenderLineScene.translationsBefore.Z);

            //label_Info.Text = sb.ToString();
            Program.message = sb.ToString();
        }

        public static void Start(object sender, EventArgs arg)
        {
            timerUpdate.Tick += Update;
            timerUpdate.Interval = 1;
            timerUpdate.Enabled = true;

            MouseAndKeyboardEvents.CreateGuidDevices();
            MouseAndKeyboardEvents.SetCooperativeLevels();
            Render.CreateDeviceAndRenderthread();
            PlayerMoving.InitializeMoveTimer();

            //pfc.AddFontFile(@"fonts/SFPixelate.ttf");//orange kid.ttf");
            //label_Info.Font = new System.Drawing.Font(pfc.Families[0], 15);

            timerUpdate.Enabled = true;
        }

        private static int state1 = 0;
        private static int state2 = 0;
        private static void SetCursoreVisible()
        {
            if (MouseAndKeyboardEvents.mouseLook == 0)
            {
                Cursor.Position = Program.scene.PointToScreen(
                    new Point(Program.scene.ClientSize.Width / 2,
                    Program.scene.ClientSize.Height / 2));
                if (state1 == 0)
                {
                    MouseAndKeyboardEvents.dvX.Acquire();
                    MouseAndKeyboardEvents.dvY.Acquire();
                    MouseAndKeyboardEvents.dvK.Acquire();
                    Cursor.Hide();
                    state2 = 0;
                }
                state1++;
            }
            else if (MouseAndKeyboardEvents.mouseLook == 1)
            {
                if (state2 == 0)
                {
                    MouseAndKeyboardEvents.dvX.Unacquire();
                    MouseAndKeyboardEvents.dvY.Unacquire();
                    MouseAndKeyboardEvents.dvK.Unacquire();
                    Cursor.Show();
                    state1 = 0;
                }
                state2++;
            }
        }

        private static void Update(object sender, EventArgs e)
        {
            if (MouseAndKeyboardEvents.mouseLook == 0)
            {
                MouseAndKeyboardEvents.SetDirections();
                MouseAndKeyboardEvents.KeysMouseEvents();
            }
            if (MouseAndKeyboardEvents.mouseLook == 2) MouseAndKeyboardEvents.mouseLook = 0;

            ViewInLogLabel();
            SetCursoreVisible();
        }

        private static void DisposeAll()
        {
            timerUpdate.Enabled = false;
            Render.DisposeAll();
            MouseAndKeyboardEvents.DisposeAll();
            PlayerMoving.DisposeMoveTimer();
        }

        public static void Quit(object sender, FormClosingEventArgs e)
        {
            DisposeAll();
        }

        public static void MouseDownScene(object sender, MouseEventArgs e)
        {
            if (MouseAndKeyboardEvents.mouseLook == 1) MouseAndKeyboardEvents.mouseLook++;

            if (MouseAndKeyboardEvents.mouseLook == 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    EditBlocksCollisions.mouseButtonDown = 2;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    EditBlocksCollisions.mouseButtonDown = 1;
                }
            }
        }
    }
}
