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
        private static Stopwatch sw;
        

        public static void PlayerMoveToDirection(Vector3 direction)
        {
            directionMove = direction;
            onMove = true;
        }

        private static long beforeTicks = 0;
        private static long afterTicks = 0;
        private static float deltatime = 0.0f;
        public static void DeltaTimeFixedUpdate()
        {
            afterTicks = sw.ElapsedTicks;
            deltatime = ((float)afterTicks - (float)beforeTicks) / 1000000.0f;
            //begincode:
            Scene.deltaTimerStr = deltatime;

            if (onMove)
            {
                float distanceMove = Vector3.Length(directionMove * deltatime);
                IntersectInformation collisionInfo = new IntersectInformation();

                if (EditBlocksCollisions.chankMesh.Intersect(
                    playerWorldPosition + new Vector3(0, 0.5f, 0),
                    new Vector3(directionMove.X, directionMove.Y, directionMove.Z) * 100.0f,
                    out collisionInfo) && collisionInfo.Dist < 0.1f)
                {
                    Vector3 A = MeshBuilder.vt[collisionInfo.FaceIndex * 3].Position;
                    Vector3 B = MeshBuilder.vt[collisionInfo.FaceIndex * 3 + 1].Position;
                    Vector3 C = MeshBuilder.vt[collisionInfo.FaceIndex * 3 + 2].Position;
                    //Вычисление нормали треугольника по формуле.
                    Vector3 normalTriangle = new Vector3(
                        (B.Y-A.Y)*(C.Z-A.Z)-(B.Z-A.Z)*(C.Y-A.Y),
                        (B.X-A.X)*(C.Z-A.Z)-(B.Z-A.Z)*(C.X-A.X),
                        (B.X-A.X)*(C.Y-A.Y)-(B.Y-A.Y)*(C.X-A.X));
                    normalTriangle.Normalize();

                    directionMove.Add(normalTriangle * 2.0f);

                    Scene.physDebag = "\n" +
                       "FaceIndex: " + collisionInfo.FaceIndex.ToString() + "\n" +
                       "Dist: " + collisionInfo.Dist.ToString() + "\n" +
                       "a:\n" + MeshBuilder.vt[collisionInfo.FaceIndex * 3].Position.ToString() + "\n\n" +
                       "b:\n" + MeshBuilder.vt[collisionInfo.FaceIndex * 3 + 1].Position.ToString() + "\n\n" +
                       "c:\n" + MeshBuilder.vt[collisionInfo.FaceIndex * 3 + 2].Position.ToString() + "\n\n" +
                       "Normal:\n" + normalTriangle.ToString();
                }

                playerWorldPosition.Add(new Vector3(directionMove.X, directionMove.Y, directionMove.Z) * deltatime);

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
