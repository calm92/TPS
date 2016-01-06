using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InvoicePrint
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f1 = new Form1();
           // frmDemo f3 = new frmDemo();
            Application.Run(f1);
        }
    }
}
