using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace iubi
{
    class Program
    {
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int cmdShow);

        static void Main(string[] args)
        {

            iubi myServer = new iubi();
            myServer.Setup();
            IntPtr hWind = GetConsoleWindow();
            if (hWind != IntPtr.Zero)
            {
                Thread.Sleep(1000);
                ShowWindow(hWind, 0);
            }
            Console.ReadKey();

        }
    }
}
