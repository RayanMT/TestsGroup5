using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Windows.Forms;


namespace ExamSystemApp
{
    public static class ExcelManager
    {
        public static void CreateUsersExcel(string filePath)
        {
            if (File.Exists(filePath)) return;

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Users");

            worksheet.Cell(1, 1).Value = "UserID";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Email";
            worksheet.Cell(1, 4).Value = "Role";
            worksheet.Cell(1, 5).Value = "Password";

            workbook.SaveAs(filePath);
        }

        public static List<ExamQuestion> LoadQuestionsFromExcel(string filePath)
        {
            var questions = new List<ExamQuestion>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist: " + filePath);
                return questions;
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("Questions");

                if (worksheet == null)
                {
                    MessageBox.Show("Worksheet 'Questions' not found!");
                    return questions;
                }

                var rows = worksheet.RowsUsed().Skip(1); // skip header row

                if (!rows.Any())
                {
                    MessageBox.Show("Worksheet found, but no data rows detected.");
                    return questions;
                }

                foreach (var row in rows)
                {
                    string course = row.Cell(1).GetString().Trim();
                    string difficulty = row.Cell(2).GetString().Trim();
                    string questionText = row.Cell(3).GetString().Trim();

                    string[] options = new string[]
                    {
                row.Cell(4).GetString().Trim(),
                row.Cell(5).GetString().Trim(),
                row.Cell(6).GetString().Trim(),
                row.Cell(7).GetString().Trim()
                    };

                    int correctAnswerIndex = int.Parse(row.Cell(8).GetString().Trim());

                    questions.Add(new ExamQuestion(questionText, options, correctAnswerIndex, difficulty, course));
                }
            }

            return questions;
        }


        public static List<User> LoadUsersFromExcel(string filePath)
        {
            var users = new List<User>();
            if (!File.Exists(filePath)) return users;

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("Users");
                var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // skip header
                foreach (var row in rows)
                {
                    var user = new User
                    {
                        UserID = row.Cell(1).GetString(),
                        Name = row.Cell(2).GetString(),
                        Email = row.Cell(3).GetString(),
                        Role = row.Cell(4).GetString(),
                        Password = row.Cell(5).GetString()
                    };
                    users.Add(user);
                }
            }

            return users;
        }

        public static void SaveExamResult(string filePath, string userId, string course, string difficulty, int score, int minutesTaken, int totalMinutes)
        {
            XLWorkbook workbook;
            IXLWorksheet worksheet;

            // Check if file exists
            if (File.Exists(filePath))
            {
                workbook = new XLWorkbook(filePath);
                worksheet = workbook.Worksheet("Results");
            }
            else
            {
                workbook = new XLWorkbook();
                worksheet = workbook.Worksheets.Add("Results");

                // Add header only if the sheet is new
                worksheet.Cell(1, 1).Value = "UserID";
                worksheet.Cell(1, 2).Value = "Course";
                worksheet.Cell(1, 3).Value = "Difficulty";
                worksheet.Cell(1, 4).Value = "Score";
                worksheet.Cell(1, 5).Value = "TimeTaken";
                worksheet.Cell(1, 6).Value = "Date";
            }

            // Find the first empty row
            int newRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 2;

            // Fill in the data
            worksheet.Cell(newRow, 1).Value = userId;
            worksheet.Cell(newRow, 2).Value = course;
            worksheet.Cell(newRow, 3).Value = difficulty;
            worksheet.Cell(newRow, 4).Value = score;
            worksheet.Cell(newRow, 5).Value = $"{minutesTaken} min of {totalMinutes}";
            worksheet.Cell(newRow, 6).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            workbook.SaveAs(filePath);
        }


    }
}
