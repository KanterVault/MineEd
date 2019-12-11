using System;
using System.Windows.Forms;
using System.Threading;

namespace MinecraftEd
{
    static class Program
    {
        public static bool exit = false;
        public static string message = "";
        public static Form scene = new Form()
        {
            StartPosition = FormStartPosition.CenterScreen,
            Width = 640,
            Height = 480,
            Text = "Game"
        };

        [STAThread]
        public static void Thr()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(scene);
            exit = true;
        }

        static void Main()
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(40, 20);
            Console.SetWindowSize(40, 20);

            Thread th = new Thread(Thr);
            th.Start();

            scene.Shown += SceneProgram.Start;
            scene.FormClosing += SceneProgram.Quit;
            scene.MouseDown += SceneProgram.MouseDownScene;

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
