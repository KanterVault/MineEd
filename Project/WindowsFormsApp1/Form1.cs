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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.Opaque, true);
        }

        private static Microsoft.DirectX.DirectInput.Device dvX = null;
        private static Microsoft.DirectX.DirectInput.Device dvY = null;
        private static Microsoft.DirectX.DirectInput.Device dvK = null;

        private static float xrot = 0.0f;
        private static float yrot = 0.0f;
        private static float mainXrot = 0.0f;
        private static float mainYrot = 0.0f;

        private static int xdir = 0;
        private static int ydir = 0;

        private static Vector3 movePlayerDirections = new Vector3();

        private static Key[] keys = null;

        private void CreateGuidDevices()
        {
            dvX = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Mouse);
            dvY = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Mouse);
            dvK = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
        }

        private void SetCooperativeLevels()
        {
            dvX.SetCooperativeLevel(
               this,
               Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
               Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive);
            dvX.Acquire();

            dvY.SetCooperativeLevel(
                this,
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive);
            dvY.Acquire();

            dvK.SetCooperativeLevel(
                this,
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive);
            dvK.Acquire();
        }

        private void ViewInLogLabel()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("X: ");
            sb.Append(mainXrot.ToString());
            sb.Append("\nY: ");
            sb.Append(mainYrot.ToString());
            sb.Append("\nKeysPress: ");
            for (int a = 0; a < keys.Length; a++) sb.Append(keys[a].ToString());
            sb.Append("\nKeysDirections: ");
            sb.Append(xdir);
            sb.Append(" | ");
            sb.Append(ydir);
            sb.Append("\nCos: ");
            sb.Append(Math.Cos(DegresToRadian(mainXrot)).ToString());

            label_Info.Text = sb.ToString();
        }

        private void KeysAndMouseEvents()
        {
            xrot += (float)dvX.CurrentMouseState.X / 2.0f;
            yrot -= (float)dvY.CurrentMouseState.Y / 2.0f;

            mainXrot = Lerp(mainXrot, xrot, 1.7f);
            mainYrot = Lerp(mainYrot, yrot, 1.7f);

            keys = dvK.GetPressedKeys();
            xdir = 0;
            ydir = 0;
            for (int a = 0; a < keys.Length; a++)
            {
                if (keys[a] == Key.W) ydir += 1;
                if (keys[a] == Key.S) ydir -= 1;
                if (keys[a] == Key.A) xdir -= 1;
                if (keys[a] == Key.D) xdir += 1;
            }

            if (xdir == 0 && ydir == 1) //forward
            {
                movePlayerDirections.X = 1;
            }
        }

        private float Lerp(float a, float b, float t) { return a + (b - a) / t; }
        private float DegresToRadian(float degres) { return (float)Math.PI / 180.0f * degres; }

        private void DisposeAll()
        {
            Thread.Sleep(1000);
            dvX.Unacquire();
            dvY.Unacquire();
            dvK.Unacquire();
            dvX.Dispose();
            dvY.Dispose();
            dvK.Dispose();
        }

        private void Start(object sender, EventArgs e)
        {
            CreateGuidDevices();
            SetCooperativeLevels();
            timerUpdate.Enabled = true;
        }

        private void Update(object sender, EventArgs e)
        {
            KeysAndMouseEvents();
            ViewInLogLabel();
        }

        private void Quit(object sender, FormClosingEventArgs e)
        {
            timerUpdate.Enabled = false;
            DisposeAll();
        }
    }
}
