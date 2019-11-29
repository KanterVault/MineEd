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
        public static Vector3 playerWorldPosition = new Vector3(-2, 7, -2);
        public static Vector3 directionMove = new Vector3();
        public static float speedMove = 0.1f;

        public static System.Timers.Timer time = null;
        public static System.Timers.Timer timeUpdateGravity = null;

        public static void OnTimerEvent(Object sender, ElapsedEventArgs e)
        {
            directionMove.Normalize();
            playerWorldPosition.Add(directionMove * speedMove);
            time.Stop();
        }

        public static float gravityAddForce = -0.015f;    //Гравитация
        public static float velocityY = 0.0f;             //Инеция
        public static float jumpForceValue = 0.2f;        //Сила прыжка

        public static bool onCollision = false;
        public static bool spaceButton = false;
        public static void OnGravityTimerUpdate(Object sender, ElapsedEventArgs e)
        {
            Collisions.CheckPlayerGrounCollision();
        }

        public static void InitializeMoveTimer()
        {
            time = new System.Timers.Timer();
            time.Elapsed += OnTimerEvent;
            time.Interval = 5;
            time.Enabled = true;
            time.Start();

            timeUpdateGravity = new System.Timers.Timer();
            timeUpdateGravity.Elapsed += OnGravityTimerUpdate;
            timeUpdateGravity.Interval = 5;
            timeUpdateGravity.Enabled = true;
            timeUpdateGravity.Start();
        }

        public static void DisposeMoveTimer()
        {
            time.Stop();
            time.Close();
            time.Dispose();

            timeUpdateGravity.Stop();
            timeUpdateGravity.Close();
            timeUpdateGravity.Dispose();
        }

        public static void PlayerMoveToDirection(Vector3 direction)
        {
            directionMove = direction;
            time.Start();
        }
    }
}
