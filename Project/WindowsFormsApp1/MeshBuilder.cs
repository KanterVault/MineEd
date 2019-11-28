﻿using System;
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
        public static CustomVertex.PositionTextured[] vt = null;

        public static void CreateNewTerrainMesh()
        {
            vt = new CustomVertex.PositionTextured[3 * 2 * 10 * 10];
            int vertCount = 0;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    vt[vertCount] = new CustomVertex.PositionTextured(new Vector3(0 + x, 0, 0 + y), 0.0f, 0.0f);
                    vt[vertCount + 1] = new CustomVertex.PositionTextured(new Vector3(0 + x, 0, 1 + y), 0.0f, 1.0f);
                    vt[vertCount + 2] = new CustomVertex.PositionTextured(new Vector3(1 + x, 0, 1 + y), 1.0f, 1.0f);

                    vt[vertCount + 3] = new CustomVertex.PositionTextured(new Vector3(0 + x, 0, 0 + y), 0.0f, 0.0f);
                    vt[vertCount + 4] = new CustomVertex.PositionTextured(new Vector3(1 + x, 0, 1 + y), 1.0f, 1.0f);
                    vt[vertCount + 5] = new CustomVertex.PositionTextured(new Vector3(1 + x, 0, 0 + y), 1.0f, 0.0f);

                    vertCount += 6;
                }
            }
        }
    }
}
