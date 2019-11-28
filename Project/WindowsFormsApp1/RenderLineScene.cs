﻿using System;
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

        public static Texture tex = null;
        public static Material mat = new Material();

        public static void SetUpMaterial()
        {
            mat.Diffuse = Color.White;
            mat.Ambient = Color.FromArgb(40, 30, 20);
        }

        public static void SetProjectionsAndCameras()
        {
            Render.dx.Transform.Projection = Matrix.PerspectiveFovLH(
                MouseAndKeyboardEvents.DegresToRadian(90.0f), //fov
                (float)form.Width / (float)form.Height,       //aspectRatio
                0.01f,                                        //zNear
                100f);                                        //zFar

            Render.dx.Transform.View = Matrix.LookAtLH(
                new Vector3(2, 3, -10),  //position
                new Vector3(),          //lookAt
                new Vector3(0, 1, 0));  //upVector
        }

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

        public static void LoadTexture()
        {
            tex = TextureLoader.FromFile(Render.dx, @"C:\Users\Vadim\Desktop\MinecraftEd\Project\WindowsFormsApp1\Res\minecraft\textures\map\map_background.png");
            tex.PreLoad();
        }

        public static void DrawSprite()
        {
            using (Sprite sp = new Sprite(Render.dx))
            {
                sp.Begin(SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);

                sp.Transform = Matrix.Transformation(
                new Vector3(),
                Quaternion.Identity,
                new Vector3(2, 2, 2),
                new Vector3(),
                Quaternion.RotationYawPitchRoll(
                    MouseAndKeyboardEvents.DegresToRadian(0),
                    MouseAndKeyboardEvents.DegresToRadian(0),
                    MouseAndKeyboardEvents.DegresToRadian(0)),
                    new Vector3(0, 0, 0));

                sp.Draw(tex, new Vector3(), new Vector3(), Color.White.ToArgb());

                sp.End();
            }
        }

        public static void RenderScene()
        {
            Render.SetRenderStateParametrs();
            SetProjectionsAndCameras();

            Render.dx.Material = mat;
            Render.dx.SetTexture(0, tex);

            //ModelRotate(0, 0, 0, 0, 0, 0);
            //DrawSprite();

            ModelRotate(0, 0, 0, MouseAndKeyboardEvents.mainXrot, MouseAndKeyboardEvents.mainYrot, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.TriangleList, 2 * 10 * 10, MeshBuilder.vt);
            //mesh.DrawSubset(0);
        }
    }
}
