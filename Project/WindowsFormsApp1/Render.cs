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

        public static void SetUpPresentParametrs()
        {
            pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            pp.DeviceWindow = form;
            pp.BackBufferCount = 1;
            pp.BackBufferFormat = Format.A8R8G8B8;
            pp.PresentationInterval = PresentInterval.Immediate;
            pp.PresentFlag = PresentFlag.None;
            pp.AutoDepthStencilFormat = DepthFormat.D16;
            pp.EnableAutoDepthStencil = true;
        }

        public static bool CreateDirectXDevice()
        {
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

        public delegate void TaskRender(); public static void NullMethod() { }
        public static void RenderThread(IAsyncResult result)
        {
            TaskRender task = (TaskRender)result.AsyncState;
            task.EndInvoke(result);

            MeshBuilder.CreateNewTerrainMesh();

            while (live)
            {
                try
                {
                    dx.BeginScene();
                    dx.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Aqua, 1.0f, 0);

                    RenderLineScene.RenderScene();

                    dx.EndScene();
                    dx.Present();
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Scene.ERRORMESSAGE = ex.ToString();
                }
            }
        }

        public static void SetRenderStateParametrs()
        {
            dx.RenderState.Lighting = false;
            dx.RenderState.FillMode = FillMode.Solid;
            dx.RenderState.ZBufferEnable = true;
            dx.RenderState.CullMode = Cull.None;
            Render.dx.VertexFormat = CustomVertex.PositionColored.Format;
        }

        public static void StartRenderCallBack()
        {
            TaskRender render = new TaskRender(NullMethod);
            render.BeginInvoke(new AsyncCallback(RenderThread), render);
        }

        public static void DisposeAll()
        {
            live = false;
            Thread.Sleep(2000);
            try { dx.EndScene(); } catch { }
            try { dx.Present(); } catch { }
            try { dx.Dispose(); } catch { }
            dx = null;
            pp = null;
        }

        public static void CreateDeviceAndRenderthread()
        {
            SetUpPresentParametrs();
            if (CreateDirectXDevice()) StartRenderCallBack();
            else DisposeAll();
        }
    }
}
