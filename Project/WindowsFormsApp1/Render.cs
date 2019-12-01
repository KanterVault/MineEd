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
    public static class Render
    {
        public static Form form = Scene.ActiveForm;

        public static Microsoft.DirectX.Direct3D.Device dx = null;
        public static PresentParameters pp = null;

        public static bool live = true;
        public static Thread renderThread = null;

        public static void SetUpPresentParametrs()
        {
            //pp = new PresentParameters();
            //pp.Windowed = true;
            //pp.SwapEffect = SwapEffect.Copy;
            //pp.DeviceWindow = form;
            //pp.BackBufferCount = 1;
            //pp.BackBufferFormat = Format.A8R8G8B8;
            //pp.PresentationInterval = PresentInterval.Default;
            //pp.PresentFlag = PresentFlag.None;
            //pp.AutoDepthStencilFormat = DepthFormat.D24S8;
            //pp.MultiSample = MultiSampleType.None;
            //pp.MultiSampleQuality = 0;
            //pp.EnableAutoDepthStencil = true;

            pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            pp.DeviceWindow = form;
            pp.BackBufferCount = 0;
            pp.BackBufferFormat = Format.A8R8G8B8;
            pp.PresentationInterval = PresentInterval.Default;
            pp.PresentFlag = PresentFlag.None;
            pp.AutoDepthStencilFormat = DepthFormat.D24S8;
            pp.MultiSample = MultiSampleType.None; //MultiSampleType.FourSamples;
            pp.MultiSampleQuality = 0;
            pp.EnableAutoDepthStencil = true;
        }

        public static bool CreateDirectXDevice()
        {
            Thread.Sleep(1000);
            try
            {
                live = true;
                dx = new Microsoft.DirectX.Direct3D.Device(
                    0,
                    Microsoft.DirectX.Direct3D.DeviceType.Hardware,
                    form,
                    Microsoft.DirectX.Direct3D.CreateFlags.HardwareVertexProcessing,
                    pp);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                Scene.ERRORMESSAGE = ex.ToString();
                return false;
            }
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
                    dx.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Aqua, 1.0f, 0);
                    dx.BeginScene();

                    RenderLineScene.RenderScene();

                    dx.EndScene();
                    dx.Present();
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Scene.ERRORMESSAGE = ex.ToString();

                    //RenderLineScene.LoadTexture();
                }
            }
        }

        public static void SetRenderStateParametrs()
        {
            dx.RenderState.Lighting = false;
            dx.RenderState.FillMode = FillMode.Solid;
            dx.RenderState.ZBufferEnable = true;
            dx.RenderState.CullMode = Cull.None; //Cull.CounterClockwise;
            Render.dx.VertexFormat = CustomVertex.PositionColoredTextured.Format;

            dx.Lights[0].Diffuse = Color.White;
            dx.Lights[0].Type = LightType.Directional;
            dx.Lights[0].Direction = new Vector3(0, -1, 0);
            dx.Lights[0].Position = new Vector3();
            dx.Lights[0].Enabled = false;
            dx.Lights[0].Update();

            dx.RenderState.AlphaBlendEnable = true;
            dx.RenderState.AlphaBlendOperation = BlendOperation.Add;
            dx.RenderState.SourceBlend = Blend.SourceAlpha;
            dx.RenderState.DestinationBlend = Blend.InvSourceAlpha;
            //dx.RenderState.BlendFactor = Color.FromArgb(0, 0, 0, 0);
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

            try { RenderLineScene.tex.Dispose(); } catch { }

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
