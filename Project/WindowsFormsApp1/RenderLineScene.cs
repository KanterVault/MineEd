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

        public static Texture tex = null;
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
                DegresToRadian(60.0f),                        //fov
                (float)form.ClientSize.Width / (float)form.ClientSize.Height,       //aspectRatio
                0.01f,                                        //zNear
                1000f);                                        //zFar

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
            tex = TextureLoader.FromFile(
                Render.dx,
                @"Res\debug.stitched_terrain.png");
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

            ModelRotate(0, 0, 0, 0, 0, 0);
            Collisions.chankMesh.DrawSubset(0);
            ModelRotate(14, 0, 0, 0, 0, 0);
            Collisions.chankMesh.DrawSubset(0);
            ModelRotate(28, 0, 0, 0, 0, 0);
            Collisions.chankMesh.DrawSubset(0);

            ModelRotate(0, 0, 0, 0, 0, 0);
            Collisions.testMesh.DrawSubset(0);

            CustomVertex.PositionColored[] cold = {
                new CustomVertex.PositionColored(new Vector3(0, 0, -Collisions.dis), Color.Black.ToArgb()),
                new CustomVertex.PositionColored(new Vector3((float)Collisions.xoffset, 0, Collisions.dis), Color.Black.ToArgb())
            };

            Render.dx.DrawUserPrimitives(
                PrimitiveType.LineList,
                1,
                cold);

            Collisions.CheckPlayerGrounCollision();
        }
    }
}
