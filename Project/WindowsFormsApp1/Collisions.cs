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

        public static Mesh mesh;

        public static readonly short[] id = new short[3] { 0, 1, 2 };

        public static void InitializeCollisions()
        {
            try
            {
                playerMesh = Mesh.Cylinder(Render.dx, 0.4f, 0.4f, 1.7f, 16, 1);

                //vbChank = new VertexBuffer(
                //    typeof(CustomVertex.PositionColored),
                //    3,
                //    Render.dx,
                //    Usage.Dynamic | Usage.WriteOnly,
                //    CustomVertex.PositionColored.Format,
                //    Pool.Default);
                //vbChank.SetData(MeshBuilder.vt2, 0, Microsoft.DirectX.Direct3D.LockFlags.None);

                //ibChank = new IndexBuffer(
                //    typeof(int),
                //    3,
                //    Render.dx,
                //    Usage.WriteOnly,
                //    Pool.Default);
                //ibChank.SetData(id, 0, Microsoft.DirectX.Direct3D.LockFlags.None);

                //chankMesh = new Mesh(
                //    1,
                //    3,
                //    MeshFlags.Managed,
                //    CustomVertex.PositionColored.Format,
                //    Render.dx);

                //chankMesh = chankMesh.Clone(
                //    MeshFlags.Dynamic | MeshFlags.WriteOnly,
                //    CustomVertex.PositionColoredTextured.Format,
                //    Render.dx);

                //chankMesh.SetVertexBufferData(vbChank, Microsoft.DirectX.Direct3D.LockFlags.None);
                //chankMesh.SetIndexBufferData(ibChank, Microsoft.DirectX.Direct3D.LockFlags.None);

                int numberVerts = 8;
                short[] indices = {
                    0,1,2, // Front Face
                    1,3,2, // Front Face
                    4,5,6, // Back Face
                    6,5,7, // Back Face
                    0,5,4, // Top Face
                    0,2,5, // Top Face
                    1,6,7, // Bottom Face
                    1,7,3, // Bottom Face
                    0,6,1, // Left Face
                    4,6,0, // Left Face
                    2,3,7, // Right Face
                    5,2,7 // Right Face
                };

                mesh = new Mesh(
                    numberVerts * 3,
                    numberVerts,
                    MeshFlags.Managed,
                    CustomVertex.PositionColored.Format,
                    Render.dx);

                using (VertexBuffer vb = mesh.VertexBuffer)
                {
                    GraphicsStream data = vb.Lock(0, 0, Microsoft.DirectX.Direct3D.LockFlags.None);

                    data.Write(new CustomVertex.PositionColored(-1.0f, 1.0f, 1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(-1.0f, -1.0f, 1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(1.0f, 1.0f, 1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(1.0f, -1.0f, 1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(-1.0f, 1.0f, -1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(1.0f, 1.0f, -1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(-1.0f, -1.0f, -1.0f, 0x00ff00ff));
                    data.Write(new CustomVertex.PositionColored(1.0f, -1.0f, -1.0f, 0x00ff00ff));

                    vb.Unlock();
                }

                using (IndexBuffer ib = mesh.IndexBuffer)
                {
                    ib.SetData(indices, 0, Microsoft.DirectX.Direct3D.LockFlags.None);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public static void CheckPlayerGrounCollision()
        {

        }
    }
}
