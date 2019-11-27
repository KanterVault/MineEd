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
    public static class MeshBuilder
    {
        public static CustomVertex.PositionColored[] vt = null;

        public static void CreateNewTerrainMesh()
        {
            vt = new CustomVertex.PositionColored[3]
            {
                new CustomVertex.PositionColored(new Vector3(0, 0, 0), Color.Red.ToArgb()),
                new CustomVertex.PositionColored(new Vector3(0, 0, 1), Color.Blue.ToArgb()),
                new CustomVertex.PositionColored(new Vector3(1, 0, 1), Color.Green.ToArgb())
            };
            //vt = new CustomVertex.PositionColored[3 * 2 * 10 * 10];
            //int vertCount = 0;

            //for (int y = 0; y < 10; y++)
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        vt[vertCount] = new CustomVertex.PositionColored(new Vector3(0 + x, 0, 0 + y), Color.Red.ToArgb());
            //        vt[vertCount + 1] = new CustomVertex.PositionColored(new Vector3(0 + x, 0, 1 + y), Color.Blue.ToArgb());
            //        vt[vertCount + 2] = new CustomVertex.PositionColored(new Vector3(1 + x, 0, 1 + y), Color.Green.ToArgb());

            //        vt[vertCount + 3] = new CustomVertex.PositionColored(new Vector3(0 + x, 0, 0 + y), Color.Red.ToArgb());
            //        vt[vertCount + 4] = new CustomVertex.PositionColored(new Vector3(1 + x, 0, 1 + y), Color.Blue.ToArgb());
            //        vt[vertCount + 5] = new CustomVertex.PositionColored(new Vector3(1 + x, 0, 0 + y), Color.Green.ToArgb());

            //        vertCount += 6;
            //    }
            //}
        }
    }
}
