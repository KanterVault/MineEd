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
        public const float PLAYER_COLLISION_RADIUS = 0.3f;

        public static Vector3 playerWorldPosition = new Vector3(8, 64, 8); //new Vector3(-2, 7, -2);
        public static Vector3 directionMove = new Vector3();
        public static bool onMove = false;
        public static float speedMove = 1.0f;
        private static Stopwatch sw;

        public static void PlayerMoveToDirection(Vector3 direction)
        {
            directionMove = direction;
            onMove = true;
        }

        private static long beforeTicks = 0;
        private static long afterTicks = 0;
        private static float deltatime = 0.0f;

        private static IntersectInformation hitInfo = new IntersectInformation();
        
        private static Vector3 A = new Vector3();
        private static Vector3 B = new Vector3();
        private static Vector3 C = new Vector3();
        
        private static Vector3 normalVector = new Vector3();
        public static void DeltaTimeFixedUpdate()
        {
            afterTicks = sw.ElapsedTicks;
            deltatime = ((float)afterTicks - (float)beforeTicks) / 1000000.0f;
            //begincode:

            // 1) Проверка на коллизию с треугольником.
            // 2) Если коллизия есть, то двигаемся только до точки соприкосновения.

            if (onMove)
            {
                if (EditBlocksCollisions.chankMesh.Intersect(
                    playerWorldPosition,
                    new Vector3(
                        (float)Math.Sin(DegresToRadian(MouseAndKeyboardEvents.mainXrot)),
                        0,
                        (float)Math.Cos(DegresToRadian(MouseAndKeyboardEvents.mainXrot))),
                    out hitInfo))
                {
                    //Запись трёх точек треугольника на который указывает луч.
                    A = MeshBuilder.vt[hitInfo.FaceIndex * 3 + 0].Position;
                    B = MeshBuilder.vt[hitInfo.FaceIndex * 3 + 1].Position;
                    C = MeshBuilder.vt[hitInfo.FaceIndex * 3 + 2].Position;

                    //Вычисление вектора нормали по формуле нормали для плоскости через три точки.
                    normalVector = new Vector3(
                        (B.Y - A.Y) * (C.Z - A.Z) - (B.Z - A.Z) * (C.Y - A.Y),
                        (B.X - A.X) * (C.Z - A.Z) - (B.Z - A.Z) * (C.X - A.X),
                        (B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X));
                    normalVector.Normalize();
                }
                else playerWorldPosition += directionMove * speedMove * deltatime;
                onMove = false;
            }

            //edncode
            beforeTicks = sw.ElapsedTicks;
        }

        public static float DegresToRadian(float degres) { return (float)Math.PI / 180.0f * degres; }

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

//Scene.deltaTimerStr = deltatime;

//Vector3 copyPlayerWorldPosition = playerWorldPosition;

//if (onMove)
//{
//    float distanceMove = Vector3.Length(directionMove * deltatime);
//    IntersectInformation collisionInfo = new IntersectInformation();

//    for (int d = 0; d < 360 / 45; d++)
//    {
//        for (int i = 0; i < 100; i++)
//        {
//            Vector3 rayDirection = new Vector3(
//                (float)Math.Sin(DegresToRadian(d * 45)),
//                0,
//                (float)Math.Sin(DegresToRadian(d * 45)));

//            if (EditBlocksCollisions.chankMesh.Intersect(
//                copyPlayerWorldPosition + new Vector3(0, 0.5f, 0) - rayDirection * PLAYER_COLLISION_RADIUS,
//                rayDirection * 5.0f,
//                out collisionInfo) && collisionInfo.Dist < 0.06225f)
//            {
//                Vector3 A = MeshBuilder.vt[collisionInfo.FaceIndex * 3].Position;
//                Vector3 B = MeshBuilder.vt[collisionInfo.FaceIndex * 3 + 1].Position;
//                Vector3 C = MeshBuilder.vt[collisionInfo.FaceIndex * 3 + 2].Position;
//                //Вычисление нормали треугольника по формуле.
//                Vector3 normalTriangle = new Vector3(
//                    (B.Y - A.Y) * (C.Z - A.Z) - (B.Z - A.Z) * (C.Y - A.Y),
//                    (B.X - A.X) * (C.Z - A.Z) - (B.Z - A.Z) * (C.X - A.X),
//                    (B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X));
//                normalTriangle.Normalize();

//                directionMove.Add(normalTriangle * 0.01f);
//            }
//            onMove = false;
//            copyPlayerWorldPosition.Add(new Vector3(
//                directionMove.X / 100 / 8,
//                directionMove.Y / 100 / 8,
//                directionMove.Z / 100 / 8) * deltatime);
//        }
//    }
//}
//playerWorldPosition = copyPlayerWorldPosition;
