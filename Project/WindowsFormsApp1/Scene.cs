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

            label_Info.Text = sb.ToString();
        }

        private void SetTestPanelPosition()
        {
            panel1.Location = new Point(
               (int)(MouseAndKeyboardEvents.movePlayerDirections.X * 40) + 100,
               (int)(MouseAndKeyboardEvents.movePlayerDirections.Z * -40) + 100);
        }

        private void Start(object sender, EventArgs e)
        {
            MouseAndKeyboardEvents.CreateGuidDevices();
            MouseAndKeyboardEvents.SetCooperativeLevels();
            Render.CreateDeviceAndRenderthread();
            timerUpdate.Enabled = true;
        }

        private void Update(object sender, EventArgs e)
        {
            MouseAndKeyboardEvents.KeysAndMouseEvents();
            MouseAndKeyboardEvents.SetDirections();
            SetTestPanelPosition();
            ViewInLogLabel();
        }

        private void Quit(object sender, FormClosingEventArgs e)
        {
            timerUpdate.Enabled = false;
            Render.DisposeAll();
            MouseAndKeyboardEvents.DisposeAll();
        }
    }
}
