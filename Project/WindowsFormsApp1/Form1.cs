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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        private static PresentParameters pp = null;
        private static Microsoft.DirectX.Direct3D.Device dx = null;
        private static int process = 0;
        private static int wWidht = 640;
        private static int wHeight = 480;

        private static CustomVertex.PositionColored[] vx = new CustomVertex.PositionColored[3]
        {
            new CustomVertex.PositionColored(new Vector3(0, 0, 0), Color.Red.ToArgb()),
            new CustomVertex.PositionColored(new Vector3(0, 0, 1), Color.Blue.ToArgb()),
            new CustomVertex.PositionColored(new Vector3(5, 0, 1), Color.Green.ToArgb())
        };

        private void SetPresentParametrs()
        {
            if (process == 0)
            {
                pp = new PresentParameters();
                pp.BackBufferCount = 1;
                pp.BackBufferFormat = Format.A8R8G8B8;
                pp.BackBufferWidth = this.ClientSize.Width;
                pp.BackBufferHeight = this.ClientSize.Height;
                pp.AutoDepthStencilFormat = DepthFormat.D24S8;
                pp.DeviceWindow = this;
                pp.EnableAutoDepthStencil = true;
                pp.PresentationInterval = PresentInterval.Immediate;
                pp.PresentFlag = PresentFlag.None;
                pp.SwapEffect = SwapEffect.Discard;
                pp.Windowed = true;
                pp.MultiSample = MultiSampleType.None;
                pp.MultiSampleQuality = 0;
                process = 1;
            }
        }
        private void CreateDX()
        {
            try
            {
                if (process == 1)
                {
                    dx = new Microsoft.DirectX.Direct3D.Device(
                    0,
                    Microsoft.DirectX.Direct3D.DeviceType.Hardware,
                    this,
                    Microsoft.DirectX.Direct3D.CreateFlags.HardwareVertexProcessing,
                    pp);

                    dx.RenderState.ZBufferEnable = true;
                    dx.RenderState.StencilEnable = true;
                    dx.RenderState.Lighting = true;
                    dx.SetRenderState(RenderStates.MultisampleAntiAlias, 0);
                    dx.SetRenderState(RenderStates.MaxTessellationLevel, 0);
                    dx.SetRenderState(RenderStates.MinTessellationLevel, 0);

                    dx.Lights[0].Enabled = true;
                    dx.Lights[0].Diffuse = Color.White;
                    dx.Lights[0].Direction = new Vector3(-0.1f, -1, 0.3f);
                    dx.Lights[0].Position = new Vector3(0, 0, 0);
                    dx.Lights[0].Type = LightType.Directional;
                    dx.Lights[0].Update();

                    process = 2;
                }
            }
            catch { MessageBox.Show("Ошибка при создании девайса."); }
        }


        private static Mesh ms0 = null;
        private static Mesh ms1 = null;
        private static Material mat = new Material();
        private static Texture tex = null;
        private static int trackValue = 0;

        private void CreateModel()
        {
            if (process == 2)
            {
                ms0 = Mesh.Box(dx, 2, 2, 1);
                ms1 = Mesh.Box(dx, 13, 0.4f, 0.2f);

                mat.Diffuse = Color.White;

                ImageInformation imgInf = new ImageInformation();
                tex = TextureLoader.FromFile(
                    dx,
                    @"C:\Users\Vadim\Desktop\MinecraftEd\Project\WindowsFormsApp1\Res\minecraft\textures\gui\accessibility.png",
                    32,
                    64,
                    1,
                    Usage.AutoGenerateMipMap,
                    Format.A8R8G8B8,
                    Pool.Managed,
                    Filter.Point,
                    Filter.Point,
                    Color.White.ToArgb(),
                    ref imgInf);

                //tex = TextureLoader.FromFile(dx, @"C:\Users\Vadim\Desktop\MinecraftEd\Project\WindowsFormsApp1\Res\minecraft\textures\gui\accessibility.png");
            }
        }

        public delegate void Task();
        public static void NoneMethods() { }
        public static void RenderTask(IAsyncResult result)
        {
            Task resultTask = (Task)result.AsyncState;
            resultTask.EndInvoke(result);

            while (process == 2)
            {
                try
                {
                    dx.BeginScene();
                    dx.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Aqua, 1.0f, 0);

                    dx.Material = mat;
                    dx.Lights[0].Enabled = true;

                    dx.Transform.Projection = Matrix.PerspectiveFovLH(
                        0.5f,
                        (float)wWidht / (float)wHeight, //(float)Width / (float)Height,
                        0.01f,
                        1000);

                    dx.Transform.View = dx.Transform.World = Matrix.Transformation(
                        new Vector3(),
                        Quaternion.Identity,
                        new Vector3(1, 1, 1),
                        new Vector3(),
                        Quaternion.RotationYawPitchRoll(0, 0, 0),
                        new Vector3(0, -5, trackValue));
                    //Matrix.LookAtLH(new Vector3(0, 10, 20), new Vector3(0, 0, 0), new Vector3(0, 1, 0));

                    dx.Transform.World = Matrix.Transformation(
                        new Vector3(),
                        Quaternion.Identity,
                        new Vector3(1, 1, 1),
                        new Vector3(),
                        Quaternion.Identity,
                        new Vector3(0, 0, 0));

                    ms0.DrawSubset(0);

                    dx.Transform.World = Matrix.Transformation(
                        new Vector3(),
                        Quaternion.Identity,
                        new Vector3(1, 1, 1),
                        new Vector3(),
                        Quaternion.Identity,
                        new Vector3(0, 2, 0));

                    ms1.DrawSubset(0);

                    dx.Transform.World = Matrix.Transformation(
                        new Vector3(),
                        Quaternion.Identity,
                        new Vector3(1, 1, 1),
                        new Vector3(),
                        Quaternion.RotationYawPitchRoll((float)Math.PI / 180.0f * 90.0f, 0, 0),
                        new Vector3(0, -2, 0));

                    ms1.DrawSubset(0);

                    using (Sprite sprite = new Sprite(dx))
                    {
                        sprite.Begin(SpriteFlags.SortTexture | SpriteFlags.AlphaBlend);
                        sprite.Transform = Matrix.Scaling(4.0f, 4.0f, 1) * Matrix.Translation(0, 0, 0) * Matrix.RotationYawPitchRoll(0, 0, 0);
                        sprite.Draw(tex, new Vector3(), new Vector3(trackValue, 0, 0), Color.White.ToArgb());
                        sprite.End();
                    }

                    dx.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vx);

                    dx.EndScene();
                    dx.Present();
                }
                catch (Exception ex) { MessageBox.Show("Ошибка рендера. " + ex.ToString()); process = 3; }
            }
        }

        private void SceneLine()
        {
            Task task = new Task(NoneMethods);
            task.BeginInvoke(new AsyncCallback(RenderTask), task);
        }

        private void DisposeTextures()
        {
            try { tex.Dispose(); } catch { }
        }
        private void DisposeDX()
        {
            try
            {
                if (dx != null)
                {
                    try { dx.Dispose(); } catch { }
                    dx = null;
                }
            }
            catch { MessageBox.Show("Ошибка при удалении девайса."); }
        }
        private void RemovePP()
        {
            try { if (dx != null) pp = null; }
            catch { MessageBox.Show("Ошибка при удалении настроек девайса."); }
        }

        private void Start(object sender, EventArgs e)
        {
            SetPresentParametrs();
            CreateDX();
            CreateModel();
            SceneLine();
            timerUpdate.Enabled = true;
        }

        private void Update(object sender, EventArgs e)
        {
            trackValue = trackBar1.Value;
        }

        private void Quit(object sender, FormClosingEventArgs e)
        {
            process = -1;
            timerUpdate.Enabled = false;
            //Thread.Sleep(500);
            DisposeTextures();
            DisposeDX();
            RemovePP();
        }

        private void ResizeWindow(object sender, EventArgs e)
        {
            wWidht = this.ClientSize.Width;
            wHeight = this.ClientSize.Height;
        }
    }
}
