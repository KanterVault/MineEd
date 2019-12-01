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

                short[] indices = new short[MeshBuilder.vt.Length];
                for (int i = 0; i < indices.Length; i++) indices[i] = (short)i;

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

                using (IndexBuffer ib = chankMesh.IndexBuffer)
                    ib.SetData(indices, 0, Microsoft.DirectX.Direct3D.LockFlags.None);

                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        public static IntersectInformation rayInfo;
        public static float dis = 0.0f;
        public static float xoffset = 0.0f;
        public static void CheckPlayerGrounCollision()
        {
            //chankMesh.Intersect(
            //    PlayerMoving.playerWorldPosition,
            //    PlayerMoving.directionMove,
            //    out rayInfo);

            testMesh.Intersect(
                new Vector3(0, 0, -dis),
                new Vector3(xoffset, 0, 1),
                out rayInfo);

            Scene.physDebag = "\n" +
                "FaceIndex: " + rayInfo.FaceIndex.ToString() + "\n" +
                "Dist: " + rayInfo.Dist.ToString() + "\n" +
                "U: " + rayInfo.U.ToString() + "\n" +
                "V: " + rayInfo.V.ToString();
        }
    }
}
