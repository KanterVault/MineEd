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
        public static Mesh mesh = Mesh.Cylinder(Render.dx, 3, 4, 6, 12, 6);
        public static Form form = Form1.ActiveForm;

        public static void SetProjectionsAndCameras()
        {
            Render.dx.Transform.Projection = Matrix.PerspectiveFovLH(
                MouseAndKeyboardEvents.DegresToRadian(90.0f), //fov
                (float)form.Width / (float)form.Height,       //aspectRatio
                0.01f,                                        //zNear
                100f);                                        //zFar

            Render.dx.Transform.View = Matrix.LookAtLH(
                new Vector3(0, 0, -6),  //position
                new Vector3(),          //lookAt
                new Vector3(0, 1, 0));  //upVector
        }

        public static void RenderScene()
        {
            SetProjectionsAndCameras();

            mesh.DrawSubset(0);
        }
    }
}
