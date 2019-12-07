using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.DirectInput;

namespace WindowsFormsApp1
{
    public static class PlayerMoving
    {
        public static Vector3 playerWorldPosition = new Vector3(8, 63, 8); //new Vector3(-2, 7, -2);
        public static Vector3 directionMove = new Vector3();
        public static float speedMove = 0.3f;

        public static void PlayerMoveToDirection(Vector3 direction)
        {
            directionMove = direction;
        }

        public static void InitializeMoveTimer()
        {

        }

        public static void DisposeMoveTimer()
        {

        }
    }
}
