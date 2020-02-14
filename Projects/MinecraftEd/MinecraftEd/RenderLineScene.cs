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

namespace MinecraftEd
{
    public static class RenderLineScene
    {
        public static Texture[] tex = null;
        public static Material mat = new Material();

        public static Vector3 translationsBefore = new Vector3();

        public static void SetUpMaterial()
        {
            mat.Diffuse = Color.FromArgb(0, 0, 0);
            mat.Ambient = Color.FromArgb(0, 0, 0);
            mat.Emissive = Color.FromArgb(0, 0, 0);
        }

        public static void SetProjectionsAndCameras()
        {
            Render.dx.Transform.Projection = Matrix.PerspectiveFovLH(
                DegresToRadian(60.0f),
                (float)Program.scene.ClientSize.Width / (float)Program.scene.ClientSize.Height,
                0.1f,
                10000f);

            translationsBefore = Vector3.Lerp(
                translationsBefore,
                -PlayerMoving.playerWorldPosition + new Vector3(0, -0.75f - 0.5f, 0),
                0.2f);

            Render.dx.Transform.View =
                Matrix.Translation(translationsBefore) *
                Matrix.RotationY(DegresToRadian(-MouseAndKeyboardEvents.mainXrot)) *
                Matrix.RotationX(DegresToRadian(MouseAndKeyboardEvents.mainYrot));
        }

        public static float DegresToRadian(float degres) { return (float)Math.PI / 180.0f * degres; }

        public static void ModelRotate(float x, float y, float z, float Yaw, float Pitch, float Roll) // вращаем модель 
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
                @"Res\debug.stitched_terrain.png");  // путь к папке текстур
            tex[0].PreLoad();

            tex[1] = TextureLoader.FromFile(
                Render.dx,
                @"Res\minecraft\textures\gui\widgets.png");
            tex[1].PreLoad();

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
                    new Vector3(Program.scene.ClientSize.Width / 2, Program.scene.ClientSize.Height / 2, 0),
                    Color.White.ToArgb());
                spCursore.End();
            }
        }

        public static Mesh pointCollision = Mesh.Sphere(Render.dx, 0.1f, 10, 10);
        public static Mesh boxSelect = Mesh.Box(Render.dx, 1.005f, 1.005f, 1.005f);
        public static CustomVertex.PositionOnly[] selectLines = new CustomVertex.PositionOnly[24]
        {
            //UP
            new CustomVertex.PositionOnly(new Vector3(-0.5f, 0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(-0.5f, 0.5f, 0.5f)),

            new CustomVertex.PositionOnly(new Vector3(0.5f, 0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, 0.5f, 0.5f)),

            new CustomVertex.PositionOnly(new Vector3(-0.5f, 0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, 0.5f, -0.5f)),

            new CustomVertex.PositionOnly(new Vector3(-0.5f, 0.5f, 0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, 0.5f, 0.5f)),

            //DOWN
            new CustomVertex.PositionOnly(new Vector3(-0.5f, -0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(-0.5f, -0.5f, 0.5f)),

            new CustomVertex.PositionOnly(new Vector3(0.5f, -0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, -0.5f, 0.5f)),

            new CustomVertex.PositionOnly(new Vector3(-0.5f, -0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, -0.5f, -0.5f)),

            new CustomVertex.PositionOnly(new Vector3(-0.5f, -0.5f, 0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, -0.5f, 0.5f)),

            //EDGES
            new CustomVertex.PositionOnly(new Vector3(-0.5f, -0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(-0.5f, 0.5f, -0.5f)),

            new CustomVertex.PositionOnly(new Vector3(0.5f, -0.5f, -0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, 0.5f, -0.5f)),

            new CustomVertex.PositionOnly(new Vector3(0.5f, -0.5f, 0.5f)),
            new CustomVertex.PositionOnly(new Vector3(0.5f, 0.5f, 0.5f)),

            new CustomVertex.PositionOnly(new Vector3(-0.5f, -0.5f, 0.5f)),
            new CustomVertex.PositionOnly(new Vector3(-0.5f, 0.5f, 0.5f))
        };

        public static void RenderScene()
        {
            Render.SetRenderStateParametrs();
            SetProjectionsAndCameras();
            Render.dx.Material = mat;
            Render.dx.SetTexture(0, tex[0]);
            EditBlocksCollisions.CheckCameraRayCollision();
            PlayerMoving.DeltaTimeFixedUpdate();


            DrawUISprite();

            for (int z = 0; z < 2; z++)
            {
                for (int x = 0; x < 2; x++)
                {
                    ModelRotate(x * 14, 0, z * 14, 0, 0, 0);
                    EditBlocksCollisions.chankMesh.DrawSubset(0);
                }
            }

            #region SelectPaste
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X,
                EditBlocksCollisions.boxSelectionPositionRound.Y,
                EditBlocksCollisions.boxSelectionPositionRound.Z,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z + 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z - 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z + 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z - 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z - 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z - 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            ModelRotate(
                EditBlocksCollisions.boxSelectionPositionRound.X - 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Y + 0.0005f,
                EditBlocksCollisions.boxSelectionPositionRound.Z + 0.0005f,
                0, 0, 0);
            Render.dx.DrawUserPrimitives(PrimitiveType.LineList, 12, selectLines);
            #endregion
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
