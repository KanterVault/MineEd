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
    public static class MeshBuilder
    {
        public const float MAP_WIDTH = 32.0f;
        public const float MAP_HEIGHT = 16.0f;
        public const float START_WIDTH = 1.0f / 32.0f;
        public const float START_HEIGHT = 1.0f / 16.0f;

        public static CustomVertex.PositionColoredTextured[] vt = null;


        public static void CreateNewTerrainMesh()
        {
            vt = new CustomVertex.PositionColoredTextured[3 * 2 * 10 * 10];
            int vertCount = 0;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    vt[vertCount] = new CustomVertex.PositionColoredTextured(new Vector3(0 + x, 0, 0 + y), Color.LightGreen.ToArgb(), 0.0f, 0.0f);
                    vt[vertCount + 1] = new CustomVertex.PositionColoredTextured(new Vector3(0 + x, 0, 1 + y), Color.LightGreen.ToArgb(), 0.0f, 1.0f);
                    vt[vertCount + 2] = new CustomVertex.PositionColoredTextured(new Vector3(1 + x, 0, 1 + y), Color.LightGreen.ToArgb(), 1.0f, 1.0f);

                    vt[vertCount + 3] = new CustomVertex.PositionColoredTextured(new Vector3(0 + x, 0, 0 + y), Color.LightGreen.ToArgb(), 0.0f, 0.0f);
                    vt[vertCount + 4] = new CustomVertex.PositionColoredTextured(new Vector3(1 + x, 0, 1 + y), Color.LightGreen.ToArgb(), 1.0f, 1.0f);
                    vt[vertCount + 5] = new CustomVertex.PositionColoredTextured(new Vector3(1 + x, 0, 0 + y), Color.LightGreen.ToArgb(), 1.0f, 0.0f);

                    vertCount += 6;
                }
            }
        }

        public static void CreateChankMesh()
        {
            ArrayList vertexes = new ArrayList();
            CreateFrontFace(0, 3, 0, new Vector2(0, 3));
            CreateBackFace(0, 3, 0, new Vector2(0, 3));
            CreateTopFace(0, 3, 0, new Vector2(2, 3));
            CreateBottomFace(0, 3, 0, new Vector2(1, 5));
            CreateLeftFace(0, 3, 0, new Vector2(0, 3));
            CreateRightFace(0, 3, 0, new Vector2(0, 3));

            void CreateFrontFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateBackFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateTopFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateBottomFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateLeftFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateRightFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    Color.White.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    Color.White.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }

            vt = new CustomVertex.PositionColoredTextured[vertexes.Count];
            for (int i = 0; i < vt.Length; i++) vt[i] = (CustomVertex.PositionColoredTextured)vertexes[i];
        }
    }
}
