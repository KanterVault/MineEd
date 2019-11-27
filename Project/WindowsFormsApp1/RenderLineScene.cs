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
    public static class RenderLineScene
    {
        public static Mesh mesh = Mesh.Cylinder(Render.dx, 4, 4, 10, 12, 6);
        public static Form form = Scene.ActiveForm;

        public static void SetProjectionsAndCameras()
        {
            Render.dx.Transform.Projection = Matrix.PerspectiveFovLH(
                MouseAndKeyboardEvents.DegresToRadian(90.0f), //fov
                (float)form.Width / (float)form.Height,       //aspectRatio
                0.01f,                                        //zNear
                100f);                                        //zFar

            Render.dx.Transform.View = Matrix.LookAtLH(
                new Vector3(4, 6, -20),  //position
                new Vector3(),          //lookAt
                new Vector3(0, 1, 0));  //upVector
        }

        /// <summary>
        /// Model transform edit (World root)
        /// </summary>
        /// <param name="x">pos x units</param>
        /// <param name="y">pos y units</param>
        /// <param name="z">pos z units</param>
        /// <param name="Yaw">rotate yaw degres</param>
        /// <param name="Pitch">rotate pitch degres</param>
        /// <param name="Roll">rotate roll degres</param>
        public static void ModelRotate(float x, float y, float z, float Yaw, float Pitch, float Roll)
        {
            Render.dx.Transform.World = Matrix.Transformation(
                new Vector3(),
                Quaternion.Identity,
                new Vector3(1, 1, 1),
                new Vector3(),
                Quaternion.RotationYawPitchRoll(
                    MouseAndKeyboardEvents.DegresToRadian(Yaw),
                    MouseAndKeyboardEvents.DegresToRadian(Pitch),
                    MouseAndKeyboardEvents.DegresToRadian(Roll)),
                    new Vector3(x, y, z));
        }

        public static void RenderScene()
        {
            Render.SetRenderStateParametrs();
            SetProjectionsAndCameras();

            ModelRotate(0, 0, 0, 0, 0, 0);
            Render.dx.VertexFormat = CustomVertex.PositionColored.Format;
            Render.dx.DrawUserPrimitives(PrimitiveType.TriangleList, 1, MeshBuilder.vt);


            //ModelRotate(0, 0, 0, MouseAndKeyboardEvents.mainXrot, MouseAndKeyboardEvents.mainYrot, 0);
            mesh.DrawSubset(0);
        }
    }
}
