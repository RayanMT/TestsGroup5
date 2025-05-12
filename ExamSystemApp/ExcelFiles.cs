using System;
using System.IO;
using System.Windows.Forms;

namespace ExamSystemApp
{
    public static class ExcelFiles
    {
        // Folder under your exe where .xlsx lives
        private static string Folder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\rshad\source\repos\ExamSystemApp\ExamSystemApp\bin\Debug");

        public static string Questions => Path.Combine(Folder, "Questions.xlsx");
        public static string Users     => Path.Combine(Folder, "Users.xlsx");
        public static string Results   => Path.Combine(Folder, "Results.xlsx");
    }
}
