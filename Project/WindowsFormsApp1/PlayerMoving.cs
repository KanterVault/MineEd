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
        public static Vector3 playerWorldPosition = new Vector3();
        public static System.Timers.Timer time = null;
        public static Vector3 directionMove = new Vector3();
        public static float speedMove = 0.1f;

        public static void OnTimerEvent(Object sender, ElapsedEventArgs e)
        {
            directionMove.Normalize();
            playerWorldPosition.Add(directionMove * speedMove);
            time.Stop();
        }

        public static void InitializeMoveTimer()
        {
            time = new System.Timers.Timer();
            time.Start();
            time.Elapsed += OnTimerEvent;
            time.Interval = 5;
            time.Enabled = true;
            time.Start();
        }

        public static void DisposeMoveTimer()
        {
            time.Stop();
            time.Close();
            time.Dispose();
        }

        public static void PlayerMoveToDirection(Vector3 direction)
        {
            directionMove = direction;
            time.Start();
        }
    }
}
