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

        public static Color color = new Color();
        public static CustomVertex.PositionColoredTextured[] vt = null;

        public static void CreateChankMesh(ChankGenerator.Chank chankToView)
        {
            ArrayList vertexes = new ArrayList();

            for (int y = 1; y < ChankGenerator.CHANK_MAX_UP_BLOCKS - 1; y++)
            {
                for (int z = 1; z < 15; z++)
                {
                    for (int x = 1; x < 15; x++)
                    {
                        //dirt
                        if (chankToView.chankArray[y][z][x] == (byte)3)
                        {
                            if (chankToView.chankArray[y][z][x - 1] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateLeftFace(x, y, z, new Vector2(1, 5));
                            }
                            if (chankToView.chankArray[y][z][x + 1] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateRightFace(x, y, z, new Vector2(1, 5));
                            }
                            if (chankToView.chankArray[y][z - 1][x] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateFrontFace(x, y, z, new Vector2(1, 5));
                            }
                            if (chankToView.chankArray[y][z + 1][x] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateBackFace(x, y, z, new Vector2(1, 5));
                            }
                            if (chankToView.chankArray[y + 1][z][x] == (byte)0)
                            {
                                color = Color.FromArgb(255, 255, 255);
                                CreateTopFace(x, y, z, new Vector2(1, 5));
                            }
                            if (chankToView.chankArray[y - 1][z][x] == (byte)0)
                            {
                                color = Color.FromArgb(100, 100, 100);
                                CreateBottomFace(x, y, z, new Vector2(1, 5));
                            }
                        }
                        //grass
                        if (chankToView.chankArray[y][z][x] == (byte)2)
                        {
                            if (chankToView.chankArray[y][z][x - 1] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateLeftFace(x, y, z, new Vector2(0, 3));
                            }
                            if (chankToView.chankArray[y][z][x + 1] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateRightFace(x, y, z, new Vector2(0, 3));
                            }
                            if (chankToView.chankArray[y][z - 1][x] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateFrontFace(x, y, z, new Vector2(0, 3));
                            }
                            if (chankToView.chankArray[y][z + 1][x] == (byte)0)
                            {
                                color = Color.FromArgb(175, 175, 175);
                                CreateBackFace(x, y, z, new Vector2(0, 3));
                            }
                            if (chankToView.chankArray[y + 1][z][x] == (byte)0)
                            {
                                color = Color.FromArgb(100, 255, 100);
                                CreateTopFace(x, y, z, new Vector2(2, 3));
                            }
                            if (chankToView.chankArray[y - 1][z][x] == (byte)0)
                            {
                                color = Color.FromArgb(100, 100, 100);
                                CreateBottomFace(x, y, z, new Vector2(1, 5));
                            }
                        }
                    }
                }
            }


            void CreateBlockMesh(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                color = Color.FromArgb(200, 200, 200);
                CreateFrontFace(blockX, blockY, blockZ, mapPosition);
                color = Color.FromArgb(200, 200, 200);
                CreateBackFace(blockX, blockY, blockZ, mapPosition);
                color = Color.FromArgb(255, 255, 255);
                CreateTopFace(blockX, blockY, blockZ, mapPosition);
                color = Color.FromArgb(100, 100, 100);
                CreateBottomFace(blockX, blockY, blockZ, mapPosition);
                color = Color.FromArgb(200, 200, 200);
                CreateLeftFace(blockX, blockY, blockZ, mapPosition);
                color = Color.FromArgb(200, 200, 200);
                CreateRightFace(blockX, blockY, blockZ, mapPosition);
            }

            void CreateFrontFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateBackFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateTopFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateBottomFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateLeftFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(-0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }
            void CreateRightFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
            {
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));

                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, -0.5f + blockZ),
                    color.ToArgb(), 0.0f + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, 0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (START_HEIGHT + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
                vertexes.Add(new CustomVertex.PositionColoredTextured(new Vector3(0.5f + blockX, -0.5f + blockY, 0.5f + blockZ),
                    color.ToArgb(), START_WIDTH + (1.0f / MAP_WIDTH * (float)mapPosition.X), (0.0f + (1.0f / MAP_HEIGHT * (float)mapPosition.Y)) * -1));
            }

            vt = new CustomVertex.PositionColoredTextured[vertexes.Count];
            for (int i = 0; i < vt.Length; i++) vt[i] = (CustomVertex.PositionColoredTextured)vertexes[i];
        }
    }
}
