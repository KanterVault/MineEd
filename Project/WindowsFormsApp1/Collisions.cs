using System;
using System.Collections;
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
    public static class Collisions
    {
        public static Vector3 comparePosition = new Vector3();
        public static void CheckPlayerGrounCollision()
        {
            comparePosition = new Vector3(
                (int)Math.Round(PlayerMoving.playerWorldPosition.X),
                (int)Math.Round(PlayerMoving.playerWorldPosition.Y),
                (int)Math.Round(PlayerMoving.playerWorldPosition.Z));

            if ((comparePosition.X >= 0 && comparePosition.X < 16) &&
                (comparePosition.Y >= 0 && comparePosition.Y < 16) &&
                (comparePosition.Z >= 0 && comparePosition.Z < 16))
            {
                if ((ChankGenerator.chanks.Count > 0) &&
                    (((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray
                    [(int)comparePosition.Y]
                    [(int)comparePosition.Z]
                    [(int)comparePosition.X] != (byte)0))
                {
                    PlayerMoving.velocityY = 0.001f;
                    PlayerMoving.collisionY = true;

                    PlayerMoving.collisionYPosition = comparePosition.Y;
                }
                else PlayerMoving.collisionY = false;
            }
            else PlayerMoving.collisionY = false;
            //for (int y = 0; y < ChankGenerator.CHANK_MAX_UP_BLOCKS; y++)
            //{
            //    for (int z = 0; z < 16; z++)
            //    {
            //        for (int x = 0; x < 16; x++)
            //        {
            //            if (((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] == '0')
            //            {

            //            }
            //        }
            //    }
            //}
        }
    }
}
