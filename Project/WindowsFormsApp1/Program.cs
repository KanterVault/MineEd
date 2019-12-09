using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static bool exit = false;
        public static string message = "";
        public static int[] windowXY = new int[2] { 100, 100 };

        [STAThread]
        public static void Thr()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Scene());
            exit = true;
        }

        static void Main()
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(40, 20);
            Console.SetWindowSize(40, 20);

            Thread th = new Thread(Thr);
            th.Start();
            while (true)
            {
                if (exit) break;
                Thread.Sleep(10);
                Console.Clear();
                try { Console.Write(message); } catch { }
                Console.SetWindowPosition(0, 0);
            }
            th.Abort();
        }
    }
}
