using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ExamSystem_New
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ✅ מגדיר את השפה של כל ההודעות והכפתורים לאנגלית
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
