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

        public static readonly short[] id = new short[3] { 0, 1, 2 };

        public static void InitializeCollisions()
        {
            try
            {
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

        public static void CheckPlayerGrounCollision()
        {

        }
    }
}
