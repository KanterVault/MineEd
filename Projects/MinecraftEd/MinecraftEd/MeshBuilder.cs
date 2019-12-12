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

namespace MinecraftEd
{
    public static class MeshBuilder
    {
        public const float MAP_WIDTH = 32.0f;
        public const float MAP_HEIGHT = 16.0f;
        public const float START_WIDTH = 1.0f / 32.0f;
        public const float START_HEIGHT = 1.0f / 16.0f;

        public static Color color = new Color();
        public static CustomVertex.PositionColoredTextured[] vt = null;

        private static void CreateFrontFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
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
        private static void CreateBackFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
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
        private static void CreateTopFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
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
        private static void CreateBottomFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
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
        private static void CreateLeftFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
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
        private static void CreateRightFace(int blockX, int blockY, int blockZ, Vector2 mapPosition)
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

        private static ArrayList vertexes = null;
        public static void CreateChankMesh(ChankGenerator.Chank chankToView)
        {
            vertexes = new ArrayList();

            for (int y = 1; y < ChankGenerator.CHANK_MAX_UP_BLOCKS - 1; y++)
            {
                for (int z = 1; z < 15; z++)
                {
                    for (int x = 1; x < 15; x++)
                    {
                        void CreateFaces(int u, int v, string sp)
                        {
                            if (chankToView.chankArray[y][z][x - 1] == (byte)0)
                            {
                                color = Color.FromArgb(127, 127, 127);
                                CreateLeftFace(x, y, z, new Vector2(u, v));
                            }
                            if (chankToView.chankArray[y][z][x + 1] == (byte)0)
                            {
                                color = Color.FromArgb(127, 127, 127);
                                CreateRightFace(x, y, z, new Vector2(u, v));
                            }
                            if (chankToView.chankArray[y][z - 1][x] == (byte)0)
                            {
                                color = Color.FromArgb(127 + 30, 127 + 30, 127 + 30);
                                CreateFrontFace(x, y, z, new Vector2(u, v));
                            }
                            if (chankToView.chankArray[y][z + 1][x] == (byte)0)
                            {
                                color = Color.FromArgb(127 - 30, 127 - 30, 127 - 30);
                                CreateBackFace(x, y, z, new Vector2(u, v));
                            }
                            if (chankToView.chankArray[y + 1][z][x] == (byte)0)
                            {
                                if (sp == "grass")
                                {
                                    color = Color.FromArgb(100, 255, 100);
                                    CreateTopFace(x, y, z, new Vector2(2, 3));
                                }
                                else
                                {
                                    color = Color.FromArgb(255, 255, 255);
                                    CreateTopFace(x, y, z, new Vector2(u, v));
                                }
                            }
                            if (chankToView.chankArray[y - 1][z][x] == (byte)0)
                            {
                                if (sp == "grass")
                                {
                                    color = Color.FromArgb(63, 63, 63);
                                    CreateBottomFace(x, y, z, new Vector2(1, 5));
                                }
                                else
                                {
                                    color = Color.FromArgb(63, 63, 63);
                                    CreateBottomFace(x, y, z, new Vector2(u, v));
                                }
                                
                            }
                        }

                        switch (chankToView.chankArray[y][z][x])
                        {
                            case 0:
                                break;
                            case 1: //песок
                                CreateFaces(17, 13, "");
                                break;
                            case 2: //трава
                                CreateFaces(0, 3, "grass");
                                break;
                            case 3: //земля
                                CreateFaces(1, 5, "");
                                break;
                            case 4: //камень
                                CreateFaces(18, 14, "");
                                break;
                            case 5: //дерево
                                CreateFaces(19, 2, "");
                                break;
                            case 6: //булыжник
                                CreateFaces(18, 12, "");
                                break;
                        }
                    }
                }
            }

            vt = new CustomVertex.PositionColoredTextured[vertexes.Count];
            for (int i = 0; i < vt.Length; i++) vt[i] = (CustomVertex.PositionColoredTextured)vertexes[i];
        }
    }
}
