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
    public static class Render
    {
        public static Microsoft.DirectX.Direct3D.Device dx = null;

        public static PresentParameters pp = null;

        public static bool live = true;
        public static Thread renderThread = null;

        public static void SetUpPresentParametrs()
        {
            pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Copy;
            pp.DeviceWindow = Program.scene;
            pp.BackBufferCount = 0;
            pp.BackBufferFormat = Format.A8R8G8B8;
            pp.PresentationInterval = PresentInterval.Default;
            pp.PresentFlag = PresentFlag.None;
            pp.AutoDepthStencilFormat = DepthFormat.D16;
            pp.MultiSample = MultiSampleType.None;
            pp.MultiSampleQuality = 0;
            pp.EnableAutoDepthStencil = true;
        }

        private static int initializeCount = 0;
        public static bool CreateDirectXDevice()
        {
            do
            {
                //Thread.Sleep(200);
                try
                {
                    live = true;

                    try
                    {
                        dx = new Microsoft.DirectX.Direct3D.Device(
                            0,
                            Microsoft.DirectX.Direct3D.DeviceType.Hardware,
                            Program.scene,
                            Microsoft.DirectX.Direct3D.CreateFlags.HardwareVertexProcessing,
                            pp);
                    }
                    catch
                    {
                        dx = new Microsoft.DirectX.Direct3D.Device(
                            0,
                            Microsoft.DirectX.Direct3D.DeviceType.Hardware,
                            Program.scene,
                            Microsoft.DirectX.Direct3D.CreateFlags.SoftwareVertexProcessing,
                            pp);
                    }

                    initializeCount = 0;
                    return true;
                }
                catch (Exception ex)
                {
                    if (initializeCount >= 3)
                    {
                        MessageBox.Show("Error: " + ex.ToString());
                        SceneProgram.ERRORMESSAGE = ex.ToString();
                        return false;
                    }
                    initializeCount++;
                }
            }
            while (initializeCount < 4);
            return true;
        }

        public static void RenderThread()
        {
            RenderLineScene.LoadTexture();
            ChankGenerator.CreateChank(new Vector2(), ChankGenerator.GeneratorKey.Flat);
            RenderLineScene.SetUpMaterial();

            while (live)
            {
                try
                {
                    if (MouseAndKeyboardEvents.mouseLook == 0)
                    {
                        dx.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Aqua, 1.0f, 0);
                        dx.BeginScene();

                        RenderLineScene.RenderScene();

                        dx.EndScene();
                        dx.Present();
                    }
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    SceneProgram.ERRORMESSAGE = ex.ToString();

                    //RenderLineScene.LoadTexture();
                }
            }
        }

        public static void SetRenderStateParametrs()
        {
            dx.RenderState.Lighting = false;
            dx.RenderState.FillMode = FillMode.Solid;
            dx.RenderState.ZBufferEnable = true;
            dx.RenderState.CullMode = Cull.CounterClockwise;
            Render.dx.VertexFormat = CustomVertex.PositionColoredTextured.Format;
            dx.RenderState.MultiSampleAntiAlias = false;

            dx.Lights[0].Diffuse = Color.FromArgb(255, 255, 255);
            dx.Lights[0].Ambient = Color.FromArgb(127, 127, 127);
            dx.Lights[0].Specular = Color.FromArgb(0, 0, 0);
            dx.Lights[0].Type = LightType.Directional;
            dx.Lights[0].Direction = new Vector3(0.2f, -0.7f, 0.1f);
            dx.Lights[0].Position = new Vector3();
            dx.Lights[0].Enabled = false;
            dx.Lights[0].Update();

            dx.RenderState.AlphaBlendEnable = false;
            dx.RenderState.AlphaBlendOperation = BlendOperation.Add;
            dx.RenderState.SourceBlend = Blend.SourceAlpha;
            dx.RenderState.DestinationBlend = Blend.InvSourceAlpha;
            //dx.RenderState.BlendFactor = Color.Azure;

            dx.SamplerState[0].MagFilter = TextureFilter.Point;
            dx.SamplerState[0].MipFilter = TextureFilter.None;
            dx.SamplerState[0].MinFilter = TextureFilter.None;

            //dx.RenderState.AntiAliasedLineEnable = true;
        }

        public static void StartRenderThread()
        {
            live = true;
            renderThread = new Thread(RenderThread);
            renderThread.Start();
        }

        public static void DisposeAll()
        {
            live = false;
            Thread.Sleep(500);

            try { RenderLineScene.DisposeAllTextures(); } catch { }

            try { dx.EndScene(); } catch { }
            try { dx.Present(); } catch { }
            try { dx.Dispose(); } catch { }
            try { renderThread.Abort(); } catch { }
            dx = null;
            pp = null;
            renderThread = null;
        }

        public static void CreateDeviceAndRenderthread()
        {
            SetUpPresentParametrs();
            if (CreateDirectXDevice()) StartRenderThread();
            else DisposeAll();
        }
    }
}
