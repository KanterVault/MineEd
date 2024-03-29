﻿using System;
using System.Windows.Forms;
using System.Threading;

namespace MinecraftEd
{
    static class Program
    {
        public static bool exit = false;
        public static string message = "";
        public static Form scene = new Form();

        [STAThread]
        public static void Thr()
        {
            scene.StartPosition = FormStartPosition.CenterScreen;
            scene.Width = 640;
            scene.Height = 480;
            scene.Text = "Game";
            scene.Shown += SceneProgram.Start;
            scene.FormClosing += SceneProgram.Quit;
            scene.MouseDown += SceneProgram.MouseDownScene;

            //scene.WindowState = FormWindowState.Maximized;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(scene);
            exit = true;
        }

        static void Main()
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(40, 30);
            Console.SetWindowSize(40, 30);

            Thread th = new Thread(Thr);
            th.Start();

            while (true)
            {
                if (exit) break;
                Thread.Sleep(10);
                Console.Clear();
                try { Console.Write(message); } catch { }
            }
            th.Abort();
        }
    }
}
