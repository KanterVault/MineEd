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
        public static Form form = Scene.ActiveForm;

        public static Texture[] tex = null;
        public static Material mat = new Material();

        public static Vector3 translationsBefore = new Vector3();

        public static void SetUpMaterial()
        {
            mat.Diffuse = Color.Green;
            mat.Ambient = Color.FromArgb(255, 255, 255);
        }

        public static void SetProjectionsAndCameras()
        {
            Render.dx.Transform.Projection = Matrix.PerspectiveFovLH(
                DegresToRadian(60.0f),                                              //fov
                (float)form.ClientSize.Width / (float)form.ClientSize.Height,       //aspectRatio
                0.01f,                                                              //zNear
                1000f);                                                             //zFar

            translationsBefore = Vector3.Lerp(
                translationsBefore,
                -PlayerMoving.playerWorldPosition + new Vector3(0, -1.75f - 0.5f, 0),
                0.3f);

            Render.dx.Transform.View =
                Matrix.Translation(translationsBefore) *
                Matrix.RotationY(DegresToRadian(-MouseAndKeyboardEvents.mainXrot)) *
                Matrix.RotationX(DegresToRadian(MouseAndKeyboardEvents.mainYrot));
        }

        public static float DegresToRadian(float degres) { return (float)Math.PI / 180.0f * degres; }

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
            tex = new Texture[2];
                
            tex[0] = TextureLoader.FromFile(
                Render.dx,
                @"Res\debug.stitched_terrain.png");
            tex[0].PreLoad();

            tex[1] = TextureLoader.FromFile(
                Render.dx,
                @"Res\minecraft\textures\gui\widgets.png");
            tex[1].PreLoad();

            //tex[1] = TextureLoader.FromFile(
            //    Render.dx,
            //    @"Res\minecraft\textures\gui\widgets.png",
            //    256,
            //    256,
            //    0,
            //    Usage.None,
            //    Format.A8R8G8B8,
            //    Pool.Managed,
            //    Filter.Point,
            //    Filter.Point,
            //    Color.White.ToArgb());
            //tex[1].PreLoad();

            if (tex[1] == null) MessageBox.Show("Fack!"); 
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

                sp.Draw(tex[0], new Vector3(), new Vector3(), Color.White.ToArgb());

                sp.End();
            }
        }

        public static void DrawUISprite()
        {
            using (Sprite spCursore = new Sprite(Render.dx))
            {
                spCursore.Begin(SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);

                spCursore.Transform = Matrix.Transformation(
                    new Vector3(),
                    Quaternion.Identity,
                    new Vector3(1, 1, 1),
                    new Vector3(),
                    Quaternion.RotationYawPitchRoll(
                        MouseAndKeyboardEvents.DegresToRadian(0),
                        MouseAndKeyboardEvents.DegresToRadian(0),
                        MouseAndKeyboardEvents.DegresToRadian(0)),
                    new Vector3(0, 0, 0));

                spCursore.Draw(
                    tex[1],
                    new Rectangle(256 - 16, 0, 16, 16),
                    new Vector3(8, 8, 0),
                    new Vector3(Scene.ActiveForm.ClientSize.Width / 2, Scene.ActiveForm.ClientSize.Height / 2, 0),
                    Color.White.ToArgb());

                //spCursore.Transform = Matrix.Transformation(
                //    new Vector3(),
                //    Quaternion.Identity,
                //    new Vector3(2, 2, 2),
                //    new Vector3(),
                //    Quaternion.RotationYawPitchRoll(
                //        MouseAndKeyboardEvents.DegresToRadian(0),
                //        MouseAndKeyboardEvents.DegresToRadian(0),
                //        MouseAndKeyboardEvents.DegresToRadian(0)),
                //    new Vector3(0, 0, 0));

                //spCursore.Draw(
                //    tex[1],
                //    new Rectangle(0, 0, 256, 256),
                //    new Vector3(0, 0, 0),
                //    new Vector3(0, 0, 0),
                //    Color.White.ToArgb());

                spCursore.End();
            }
        }

        public static Mesh pointCollision = Mesh.Sphere(Render.dx, 0.1f, 10, 10);
        public static Mesh boxSelect = Mesh.Box(Render.dx, 1.1f, 1.1f, 1.1f);
        public static void RenderScene()
        {
            Render.SetRenderStateParametrs();
            SetProjectionsAndCameras();

            DrawUISprite();

            Render.dx.Material = mat;
            Render.dx.SetTexture(0, tex[0]);

            ModelRotate(0, 0, 0, 0, 0, 0);
            Collisions.chankMesh.DrawSubset(0);

            ModelRotate(0, 0, 0, 0, 0, 0);
            Collisions.testMesh.DrawSubset(0);

            ModelRotate(
                Collisions.pointPosition.X,
                Collisions.pointPosition.Y,
                Collisions.pointPosition.Z,
                0, 0, 0);
            pointCollision.DrawSubset(0);


            ModelRotate(
                0,
                0,
                0,
                0, 0, 0);
            boxSelect.DrawSubset(0);

            Collisions.CheckPlayerGrounCollision();
            Collisions.CheckCameraRayCollision();
        }

        public static void DisposeAllTextures()
        {
            for (int i = 0; i < tex.Length; i++)
            {
                try { tex[i].Dispose(); } catch { }
            }
        }
    }
}
