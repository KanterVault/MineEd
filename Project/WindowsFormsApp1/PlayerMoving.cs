using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Timers;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.DirectInput;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public static class PlayerMoving
    {
        public static Vector3 playerWorldPosition = new Vector3(8, 63, 8); //new Vector3(-2, 7, -2);
        public static Vector3 directionMove = new Vector3();
        public static bool onMove = false;
        public static float speedMove = 0.3f;
        public static Stopwatch sw;
        

        public static void PlayerMoveToDirection(Vector3 direction)
        {
            directionMove = direction;
            directionMove.Normalize();
            onMove = true;
        }

        public static long beforeTicks = 0;
        public static long afterTicks = 0;
        public static float deltatime = 0.0f;
        public static void DeltaTimeFixedUpdate()
        {
            afterTicks = sw.ElapsedTicks;
            deltatime = ((float)afterTicks - (float)beforeTicks) / 1000000.0f;
            //begincode:
            Scene.deltaTimerStr = deltatime;

            if (onMove)
            {
                playerWorldPosition.Add(directionMove * deltatime);
                onMove = false;
            }

            //edncode
            beforeTicks = sw.ElapsedTicks;
        }

        public static void InitializeMoveTimer()
        {
            sw = new Stopwatch();
            sw.Start();
            beforeTicks = sw.ElapsedTicks;
            afterTicks = sw.ElapsedTicks;
            sw.Start();
        }

        public static void DisposeMoveTimer()
        {
            sw.Stop();
        }
    }
}
