using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DrawTools
{
    static class Program
    {
        /// <summary>
        /// The main entry pointscroll for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}