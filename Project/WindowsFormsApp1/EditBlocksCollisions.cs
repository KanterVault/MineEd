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
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public static class EditBlocksCollisions
    {
        public static Vector3 comparePosition = new Vector3();
        public static float bortOffset = 0.0f;
        public static Mesh playerMesh;
        public static Mesh chankMesh;
        public static VertexBuffer vbChank;
        public static IndexBuffer ibChank;

        public static Mesh testMesh;
        public static short[] ind = { 0, 1, 2 };
        public static CustomVertex.PositionColoredTextured[] vrt =
        {
            new CustomVertex.PositionColoredTextured(new Vector3(-1, -1, 0), Color.Red.ToArgb(), 0.0f, 0.0f),
            new CustomVertex.PositionColoredTextured(new Vector3(-1, 1, 0), Color.Blue.ToArgb(), 0.0f, 0.0625f),
            new CustomVertex.PositionColoredTextured(new Vector3(1, 1, 0), Color.Green.ToArgb(), 0.03125f, 0.0625f),
        };

        public static void InitializeCollisions()
        {
            try
            {
                testMesh = new Mesh(1, 3, MeshFlags.Managed, CustomVertex.PositionColoredTextured.Format, Render.dx);
                using (VertexBuffer vb = testMesh.VertexBuffer)
                {
                    using (GraphicsStream gs = vb.Lock(0, 0, Microsoft.DirectX.Direct3D.LockFlags.None))
                    {
                        gs.Write(vrt[0]);
                        gs.Write(vrt[1]);
                        gs.Write(vrt[2]);
                    }
                    vb.Unlock();
                }
                using (IndexBuffer ib = testMesh.IndexBuffer)
                {
                    ib.SetData(ind, 0, Microsoft.DirectX.Direct3D.LockFlags.None);
                }

                playerMesh = Mesh.Cylinder(Render.dx, 0.4f, 0.4f, 1.7f, 16, 1);

                ReInitializeChankMesh();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public static void ReInitializeChankMesh()
        {
            try
            {
                chankMesh = new Mesh(
                    MeshBuilder.vt.Length / 3,
                    MeshBuilder.vt.Length,
                    MeshFlags.Managed,
                    CustomVertex.PositionColoredTextured.Format,
                    Render.dx);

                using (VertexBuffer vb = chankMesh.VertexBuffer)
                {
                    using (GraphicsStream data = vb.Lock(0, 0, Microsoft.DirectX.Direct3D.LockFlags.None))
                        for (int i = 0; i < MeshBuilder.vt.Length; i++) data.Write(MeshBuilder.vt[i]);
                    vb.Unlock();
                }

                short[] indices = new short[MeshBuilder.vt.Length];
                for (int i = 0; i < indices.Length; i++) indices[i] = (short)i;

                using (IndexBuffer ib = chankMesh.IndexBuffer)
                    ib.SetData(indices, 0, Microsoft.DirectX.Direct3D.LockFlags.None);
            }
            catch { }
        }


        public static IntersectInformation rayInfo;
        public static float dis = 0.0f;
        public static float xoffset = 0.0f;

        public static float Lerp(float a, float b, float t) { return a + (b - a) / t; }
        public static float DegresToRadian(float degres) { return (float)Math.PI / 180.0f * degres; }


        public static int mouseButtonDown = 0;
        public static Vector3 boxSelectionPositionRound = new Vector3();
        public static float negativeInt = 1.0f;
        public static bool blockPasteOrBreakEvent = false;
        public static bool intersectionAviable = false;
        public static int blockForCreate = 4;
        public static void GetPlaneVectorToPasteCubeSelection()
        {
            switch (mouseButtonDown)
            {
                case 1:
                    negativeInt = 1.0f;
                    blockPasteOrBreakEvent = true;
                    mouseButtonDown = 0;
                    break;
                case 2:
                    negativeInt = -1.0f;
                    blockPasteOrBreakEvent = true;
                    mouseButtonDown = 0;
                    break;
            }

            if (intersectionAviable)
            {
                for (int y = 0; y < ChankGenerator.CHANK_MAX_UP_BLOCKS; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            //Up & Down
                            if (vrt[0].Position.Y == vrt[1].Position.Y && vrt[0].Position.Y == vrt[2].Position.Y)
                            {
                                //Up
                                if (vrt[0].Position.Z < vrt[1].Position.Z &&
                                    ((vrt[1].Position.X < vrt[2].Position.X) || (vrt[1].Position.Z > vrt[2].Position.Z)))
                                {
                                    int block = ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x];
                                    Vector3 modifedPointPosition = pointPosition + new Vector3(0, 0.1f * negativeInt, 0);
                                    if ((modifedPointPosition.X > (float)x - 0.5f) && (modifedPointPosition.X < (float)x + 0.5f) &&
                                        (modifedPointPosition.Z > (float)z - 0.5f) && (modifedPointPosition.Z < (float)z + 0.5f) &&
                                        (modifedPointPosition.Y > (float)y - 0.5f) && (modifedPointPosition.Y < (float)y + 0.5f))
                                    {
                                        boxSelectionPositionRound = new Vector3(x, y, z);
                                        if (blockPasteOrBreakEvent && intersectionAviable)
                                        {
                                            ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] =
                                                negativeInt > 0 ? (byte)blockForCreate : (byte)0;
                                            MeshBuilder.CreateChankMesh((ChankGenerator.Chank)ChankGenerator.chanks[0]);
                                            ReInitializeChankMesh();
                                            blockPasteOrBreakEvent = false;
                                        }
                                    }
                                }
                                //Down
                                if (vrt[0].Position.Z > vrt[1].Position.Z &&
                                    ((vrt[1].Position.X < vrt[2].Position.X) || (vrt[1].Position.Z < vrt[2].Position.Z)))
                                {
                                    int block = (byte)((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x];
                                    Vector3 modifedPointPosition = pointPosition + new Vector3(0, -0.1f * negativeInt, 0);
                                    if ((modifedPointPosition.X > (float)x - 0.5f) && (modifedPointPosition.X < (float)x + 0.5f) &&
                                        (modifedPointPosition.Z > (float)z - 0.5f) && (modifedPointPosition.Z < (float)z + 0.5f) &&
                                        (modifedPointPosition.Y > (float)y - 0.5f) && (modifedPointPosition.Y < (float)y + 0.5f))
                                    {
                                        boxSelectionPositionRound = new Vector3(x, y, z);
                                        if (blockPasteOrBreakEvent && intersectionAviable)
                                        {
                                            ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] =
                                                negativeInt > 0 ? (byte)blockForCreate : (byte)0;
                                            MeshBuilder.CreateChankMesh((ChankGenerator.Chank)ChankGenerator.chanks[0]);
                                            ReInitializeChankMesh();
                                            blockPasteOrBreakEvent = false;
                                        }
                                    }
                                }
                            }
                            //Left & Right
                            if (vrt[0].Position.X == vrt[1].Position.X && vrt[0].Position.X == vrt[2].Position.X)
                            {
                                //Left
                                if (vrt[0].Position.Y < vrt[1].Position.Y &&
                                    ((vrt[0].Position.Z > vrt[2].Position.Z) || (vrt[0].Position.Y > vrt[1].Position.Y)))
                                {
                                    int block = ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x];
                                    Vector3 modifedPointPosition = pointPosition + new Vector3(-0.1f * negativeInt, 0, 0);
                                    if ((modifedPointPosition.X > (float)x - 0.5f) && (modifedPointPosition.X < (float)x + 0.5f) &&
                                        (modifedPointPosition.Z > (float)z - 0.5f) && (modifedPointPosition.Z < (float)z + 0.5f) &&
                                        (modifedPointPosition.Y > (float)y - 0.5f) && (modifedPointPosition.Y < (float)y + 0.5f))
                                    {
                                        boxSelectionPositionRound = new Vector3(x, y, z);
                                        if (blockPasteOrBreakEvent && intersectionAviable)
                                        {
                                            ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] =
                                                negativeInt > 0 ? (byte)blockForCreate : (byte)0;
                                            MeshBuilder.CreateChankMesh((ChankGenerator.Chank)ChankGenerator.chanks[0]);
                                            ReInitializeChankMesh();
                                            blockPasteOrBreakEvent = false;
                                        }
                                    }
                                }
                                //Right
                                if (vrt[0].Position.Y < vrt[1].Position.Y &&
                                    ((vrt[0].Position.Z < vrt[2].Position.Z) || (vrt[0].Position.Z < vrt[1].Position.Z)))
                                {
                                    int block = (byte)((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x];
                                    Vector3 modifedPointPosition = pointPosition + new Vector3(0.1f * negativeInt, 0, 0);
                                    if ((modifedPointPosition.X > (float)x - 0.5f) && (modifedPointPosition.X < (float)x + 0.5f) &&
                                        (modifedPointPosition.Z > (float)z - 0.5f) && (modifedPointPosition.Z < (float)z + 0.5f) &&
                                        (modifedPointPosition.Y > (float)y - 0.5f) && (modifedPointPosition.Y < (float)y + 0.5f))
                                    {
                                        boxSelectionPositionRound = new Vector3(x, y, z);
                                        if (blockPasteOrBreakEvent && intersectionAviable)
                                        {
                                            ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] =
                                                negativeInt > 0 ? (byte)blockForCreate : (byte)0;
                                            MeshBuilder.CreateChankMesh((ChankGenerator.Chank)ChankGenerator.chanks[0]);
                                            ReInitializeChankMesh();
                                            blockPasteOrBreakEvent = false;
                                        }
                                    }
                                }
                            }
                            //Front & Back
                            if (vrt[0].Position.Z == vrt[1].Position.Z && vrt[0].Position.Z == vrt[2].Position.Z)
                            {
                                //Front
                                if (vrt[0].Position.Y < vrt[1].Position.Y &&
                                    ((vrt[0].Position.X < vrt[2].Position.X) || (vrt[0].Position.X < vrt[1].Position.X)))
                                {
                                    int block = ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x];
                                    Vector3 modifedPointPosition = pointPosition + new Vector3(0, 0, -0.1f * negativeInt);
                                    if ((modifedPointPosition.X > (float)x - 0.5f) && (modifedPointPosition.X < (float)x + 0.5f) &&
                                        (modifedPointPosition.Z > (float)z - 0.5f) && (modifedPointPosition.Z < (float)z + 0.5f) &&
                                        (modifedPointPosition.Y > (float)y - 0.5f) && (modifedPointPosition.Y < (float)y + 0.5f))
                                    {
                                        boxSelectionPositionRound = new Vector3(x, y, z);
                                        if (blockPasteOrBreakEvent && intersectionAviable)
                                        {
                                            ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] =
                                                negativeInt > 0 ? (byte)blockForCreate : (byte)0;
                                            MeshBuilder.CreateChankMesh((ChankGenerator.Chank)ChankGenerator.chanks[0]);
                                            ReInitializeChankMesh();
                                            blockPasteOrBreakEvent = false;
                                        }
                                    }
                                }
                                //Back
                                if (vrt[0].Position.Y < vrt[1].Position.Y &&
                                    ((vrt[0].Position.X > vrt[2].Position.X) || (vrt[0].Position.X > vrt[1].Position.X)))
                                {
                                    int block = (byte)((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x];
                                    Vector3 modifedPointPosition = pointPosition + new Vector3(0, 0, 0.1f * negativeInt);
                                    if ((modifedPointPosition.X > (float)x - 0.5f) && (modifedPointPosition.X < (float)x + 0.5f) &&
                                        (modifedPointPosition.Z > (float)z - 0.5f) && (modifedPointPosition.Z < (float)z + 0.5f) &&
                                        (modifedPointPosition.Y > (float)y - 0.5f) && (modifedPointPosition.Y < (float)y + 0.5f))
                                    {
                                        boxSelectionPositionRound = new Vector3(x, y, z);
                                        if (blockPasteOrBreakEvent && intersectionAviable)
                                        {
                                            ((ChankGenerator.Chank)ChankGenerator.chanks[0]).chankArray[y][z][x] =
                                                negativeInt > 0 ? (byte)blockForCreate : (byte)0;
                                            MeshBuilder.CreateChankMesh((ChankGenerator.Chank)ChankGenerator.chanks[0]);
                                            ReInitializeChankMesh();
                                            blockPasteOrBreakEvent = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                boxSelectionPositionRound = new Vector3(0, -1000, 0);
                pointPosition = new Vector3(0, -1000, 0);
                Scene.physDebag = "message";
            }
            blockPasteOrBreakEvent = false;
            negativeInt = -1.0f;
        }

        public static Vector3 viewDirection = new Vector3();
        public static IntersectInformation triesCollisionInfo;

        public static float[] intersectionsUV = new float[2];

        public static Vector3 pointPosition = new Vector3();
        public static void CheckCameraRayCollision()
        {
            try
            {
                viewDirection = new Vector3(
                    (float)Math.Sin(DegresToRadian(MouseAndKeyboardEvents.mainXrot)) * (float)Math.Cos(DegresToRadian(MouseAndKeyboardEvents.mainYrot)),
                    (float)Math.Sin(DegresToRadian(MouseAndKeyboardEvents.mainYrot)),
                    (float)Math.Cos(DegresToRadian(MouseAndKeyboardEvents.mainXrot)) * (float)Math.Cos(DegresToRadian(MouseAndKeyboardEvents.mainYrot)));

                if (chankMesh.Intersect(PlayerMoving.playerWorldPosition + new Vector3(0, 0.75f + 0.5f, 0), viewDirection, out triesCollisionInfo))
                {
                    intersectionAviable = true;
                    //Scene.physDebag = "\n" +
                    //   "FaceIndex: " + triesCollisionInfo.FaceIndex.ToString() + "\n" +
                    //   "Dist: " + triesCollisionInfo.Dist.ToString() + "\n" +
                    //   "U: " + triesCollisionInfo.U.ToString() + "\n" +
                    //   "V: " + triesCollisionInfo.V.ToString();

                    pointPosition = PlayerMoving.playerWorldPosition +
                        new Vector3(0, 0.75f + 0.5f, 0) +
                        viewDirection *
                        triesCollisionInfo.Dist;

                    vrt[0] = new CustomVertex.PositionColoredTextured(
                    MeshBuilder.vt[(triesCollisionInfo.FaceIndex * 3)].Position,
                    Color.Red.ToArgb(),
                    0.0f, 0.0f);

                    vrt[1] = new CustomVertex.PositionColoredTextured(
                        MeshBuilder.vt[(triesCollisionInfo.FaceIndex * 3) + 1].Position,
                        Color.Red.ToArgb(),
                        0.0f, 0.0f);

                    vrt[2] = new CustomVertex.PositionColoredTextured(
                        MeshBuilder.vt[(triesCollisionInfo.FaceIndex * 3) + 2].Position,
                        Color.Red.ToArgb(),
                        0.0f, 0.0f);
                } else
                {
                    intersectionAviable = false;
                }

                GetPlaneVectorToPasteCubeSelection();

                using (VertexBuffer vb = testMesh.VertexBuffer)
                {
                    using (GraphicsStream gs = vb.Lock(0, 0, Microsoft.DirectX.Direct3D.LockFlags.None))
                    {
                        gs.Write(vrt[0]);
                        gs.Write(vrt[1]);
                        gs.Write(vrt[2]);
                    }
                    vb.Unlock();
                }
            }
            catch { }
        }
    }
}
