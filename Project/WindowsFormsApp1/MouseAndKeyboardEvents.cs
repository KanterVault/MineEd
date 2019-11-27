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
    public static class MouseAndKeyboardEvents
    {
        public static Form handleForm = null;

        public static bool live = true;

        public static Microsoft.DirectX.DirectInput.Device dvX = null;
        public static Microsoft.DirectX.DirectInput.Device dvY = null;
        public static Microsoft.DirectX.DirectInput.Device dvK = null;

        public static float xrot = 0.0f;
        public static float yrot = 0.0f;
        public static float mainXrot = 0.0f;
        public static float mainYrot = 0.0f;

        public static int xdir = 0;
        public static int ydir = 0;

        public static Vector3 movePlayerDirections = new Vector3();
        public static float angleToPlayerDirection = 0.0f;

        public static Key[] keys = new Key[0];

        public static void CreateGuidDevices()
        {
            dvX = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Mouse);
            dvY = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Mouse);
            dvK = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
        }

        public static void SetCooperativeLevels()
        {
            dvX.SetCooperativeLevel(
               handleForm,
               Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
               Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive);
            dvX.Acquire();

            dvY.SetCooperativeLevel(
                handleForm,
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive);
            dvY.Acquire();

            dvK.SetCooperativeLevel(
                handleForm,
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive);
            dvK.Acquire();
        }


        public delegate void Task1(); public static void NullMethod1() { }
        public delegate void Task2(); public static void NullMethod2() { }

        public static void AsyncKeysAndMouseEvents(IAsyncResult result)
        {
            Task1 task = (Task1)result.AsyncState;
            task.EndInvoke(result);

            while(live)
            {
                xrot += (float)dvX.CurrentMouseState.X / 4.0f;
                yrot -= (float)dvY.CurrentMouseState.Y / 4.0f;

                mainXrot = Lerp(mainXrot, xrot, 1.7f);
                mainYrot = Lerp(mainYrot, yrot, 1.7f);

                keys = dvK.GetPressedKeys();
                xdir = 0;
                ydir = 0;
                for (int a = 0; a < keys.Length; a++)
                {
                    if (keys[a] == Key.W) ydir += 1;
                    if (keys[a] == Key.S) ydir -= 1;
                    if (keys[a] == Key.A) xdir -= 1;
                    if (keys[a] == Key.D) xdir += 1;
                }
            }
        }
        public static void KeysAndMouseEvents()
        {
            Task1 task = new Task1(NullMethod1);
            task.BeginInvoke(new AsyncCallback(AsyncKeysAndMouseEvents), task);
        }

        public static void AsyncSetDirections(IAsyncResult result)
        {
            Task2 task = (Task2)result.AsyncState;
            task.EndInvoke(result);

            while (live)
            {
                if (xdir == 0 && ydir == 1) angleToPlayerDirection = 0.0f;
                if (xdir == 0 && ydir == -1) angleToPlayerDirection = 180.0f;
                if (xdir == 1 && ydir == 0) angleToPlayerDirection = 90.0f;
                if (xdir == -1 && ydir == 0) angleToPlayerDirection = -90.0f;

                if (xdir == -1 && ydir == 1) angleToPlayerDirection = -45.0f;
                if (xdir == 1 && ydir == -1) angleToPlayerDirection = 180.0f - 45.0f;
                if (xdir == 1 && ydir == 1) angleToPlayerDirection = 45.0f;
                if (xdir == -1 && ydir == -1) angleToPlayerDirection = 180.0f + 45.0f;

                movePlayerDirections.Z = (float)Math.Cos(DegresToRadian(angleToPlayerDirection + mainXrot));
                movePlayerDirections.X = (float)Math.Sin(DegresToRadian(angleToPlayerDirection + mainXrot));
            }
        }

        public static void SetDirections()
        {
            Task2 task = new Task2(NullMethod2);
            task.BeginInvoke(new AsyncCallback(AsyncSetDirections), task);
        }

        public static float Lerp(float a, float b, float t) { return a + (b - a) / t; }
        public static float DegresToRadian(float degres) { return (float)Math.PI / 180.0f * degres; }

        public static void DisposeAll()
        {
            live = false;
            Thread.Sleep(500);
            dvX.Unacquire();
            dvY.Unacquire();
            dvK.Unacquire();
            dvX.Dispose();
            dvY.Dispose();
            dvK.Dispose();
        }
    }
}
