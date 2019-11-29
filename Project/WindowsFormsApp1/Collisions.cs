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

                vbChank = new VertexBuffer(
                    typeof(CustomVertex.PositionColored),
                    3,
                    Render.dx,
                    Usage.Dynamic | Usage.WriteOnly,
                    CustomVertex.PositionColored.Format,
                    Pool.Default);
                vbChank.SetData(MeshBuilder.vt2, 0, Microsoft.DirectX.Direct3D.LockFlags.None);

                ibChank = new IndexBuffer(
                    typeof(int),
                    3,
                    Render.dx,
                    Usage.WriteOnly,
                    Pool.Default);
                ibChank.SetData(id, 0, Microsoft.DirectX.Direct3D.LockFlags.None);

                chankMesh = new Mesh(
                    1,
                    3,
                    MeshFlags.Managed,
                    CustomVertex.PositionColored.Format,
                    Render.dx);

                chankMesh.SetVertexBufferData(vbChank, Microsoft.DirectX.Direct3D.LockFlags.None);
                chankMesh.SetIndexBufferData(ibChank, Microsoft.DirectX.Direct3D.LockFlags.None);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public static void CheckPlayerGrounCollision()
        {

        }
    }
}
