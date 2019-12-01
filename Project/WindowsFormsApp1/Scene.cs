using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.DirectInput;

namespace WindowsFormsApp1
{
    public partial class Scene : Form
    {
        public Scene()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        public static string ERRORMESSAGE = "";
        public static string physDebag = "";

        private void ViewInLogLabel()
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
            sb.Append("\nCos: ");
            sb.Append(Math.Cos(MouseAndKeyboardEvents.DegresToRadian(MouseAndKeyboardEvents.mainXrot)).ToString());
            sb.Append("\nSin: ");
            sb.Append(Math.Cos(MouseAndKeyboardEvents.DegresToRadian(MouseAndKeyboardEvents.mainXrot)).ToString());
            sb.Append("\nPlayer direction: ");
            sb.Append("\n   z: " + MouseAndKeyboardEvents.movePlayerDirections.Z);
            sb.Append("\n   x: " + MouseAndKeyboardEvents.movePlayerDirections.X);
            if (ERRORMESSAGE.Length > 20) sb.Append("\n" + ERRORMESSAGE.PadLeft(ERRORMESSAGE.Length - 20));
            sb.Append("\nPlayer World position:");
            sb.Append("\n   x: " + PlayerMoving.playerWorldPosition.X);
            sb.Append("\n   y: " + PlayerMoving.playerWorldPosition.Y);
            sb.Append("\n   z: " + PlayerMoving.playerWorldPosition.Z);
            sb.Append("\nКоллизия: " + physDebag);


            label_Info.Text = sb.ToString();
        }

        private void Start(object sender, EventArgs e)
        {
            MouseAndKeyboardEvents.CreateGuidDevices();
            MouseAndKeyboardEvents.SetCooperativeLevels();
            Render.CreateDeviceAndRenderthread();
            PlayerMoving.InitializeMoveTimer();

            timerUpdate.Enabled = true;
        }

        private void SetCursoreVisible()
        {
            if (MouseAndKeyboardEvents.mouseLook == 1 || MouseAndKeyboardEvents.mouseLook == 2)
                Cursor.Position = PointToScreen(new Point(ClientSize.Width / 2, ClientSize.Height / 2));
            if (MouseAndKeyboardEvents.mouseLook == 1)
            {
                Cursor.Hide();
                MouseAndKeyboardEvents.mouseLook++;
            }
            else if (MouseAndKeyboardEvents.mouseLook == 3)
            {
                Cursor.Show();
                MouseAndKeyboardEvents.mouseLook = 0;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (MouseAndKeyboardEvents.mouseLook == 1 || MouseAndKeyboardEvents.mouseLook == 2)
            {
                MouseAndKeyboardEvents.SetDirections();
                MouseAndKeyboardEvents.KeysMouseEvents();
            }

            ViewInLogLabel();
            SetCursoreVisible();

            Collisions.dis = (float)trackBar1.Value;
            Collisions.xoffset = (float)trackBar2.Value / 200.0f;
        }

        private void Quit(object sender, FormClosingEventArgs e)
        {
            timerUpdate.Enabled = false;
            Render.DisposeAll();
            MouseAndKeyboardEvents.DisposeAll();
            PlayerMoving.DisposeMoveTimer();
        }

        private void MouseDownScene(object sender, MouseEventArgs e)
        {
            if (MouseAndKeyboardEvents.mouseLook == 0) MouseAndKeyboardEvents.mouseLook++;
        }

        private void KeyboardDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyboardPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
