using System;
using System.Windows.Forms;

namespace Protocol_Manager
{
    static class Program
    {
        [STAThread]

        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(args));
        }
    }
}
