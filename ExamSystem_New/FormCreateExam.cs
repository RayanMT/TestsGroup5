using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExamSystem_New
{
    public partial class FormCreateExam : Form
    {
        private DataTable questionsTable;
        private DataTable examTable;

        public FormCreateExam()
        {
            InitializeComponent();
            LoadCategories();
            LoadDifficulties();
        }

        private void LoadCategories()
        {
            comboCategory.Items.AddRange(new string[] { "Algorithms", "Databases", "Software Testing" });
        }

        private void LoadDifficulties()
        {
            comboDifficulty.Items.AddRange(new string[] { "Easy", "Medium", "Hard" });
        }

        private void btnLoadQuestions_Click(object sender, EventArgs e)
        {
            string inputText = txtNumQuestions.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter the number of questions.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(inputText, out int numQuestions))
            {
                MessageBox.Show("Please enter a valid number (digits only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuestions <= 0)
            {
                MessageBox.Show("Number of questions must be greater than zero.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions.xlsx");
            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("The file 'questions.xlsx' was not found. Please make sure it is located in the bin/Debug folder.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Excel.Application xApp = new Excel.Application();
            Excel.Workbook xWorkbook = xApp.Workbooks.Open(filePath);
            Excel.Worksheet xWorksheet = xWorkbook.Sheets[1];
            Excel.Range xRange = xWorksheet.UsedRange;

            questionsTable = new DataTable();
            for (int j = 1; j <= xRange.Columns.Count; j++)
                questionsTable.Columns.Add(xRange.Cells[1, j].Value2.ToString());

            for (int i = 2; i <= xRange.Rows.Count; i++)
            {
                DataRow row = questionsTable.NewRow();
                for (int j = 1; j <= xRange.Columns.Count; j++)
                    row[j - 1] = xRange.Cells[i, j].Value2?.ToString() ?? "";
                questionsTable.Rows.Add(row);
            }

            xWorkbook.Close(false);
            xApp.Quit();

            // Extra check after loading:
            string category = comboCategory.Text.Trim();
            string difficulty = comboDifficulty.Text.Trim();

            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(difficulty))
            {
                MessageBox.Show("Questions loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var matching = questionsTable.AsEnumerable()
                .Where(r => r["Category"].ToString() == category && r["Difficulty"].ToString() == difficulty);

            int available = matching.Count();

            if (available == 0)
            {
                MessageBox.Show("Questions loaded successfully, but no questions match the selected category and difficulty.", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (numQuestions > available)
            {
                MessageBox.Show($"Questions loaded successfully, but only {available} questions are available.\nPlease reduce the number of questions.", "Too Few Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Questions loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerateExam_Click(object sender, EventArgs e)
        {
            string category = comboCategory.Text.Trim();
            string difficulty = comboDifficulty.Text.Trim();
            string inputText = txtNumQuestions.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter the number of questions.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(inputText, out int numQuestions))
            {
                MessageBox.Show("Please enter a valid number (digits only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuestions <= 0)
            {
                MessageBox.Show("Number of questions must be greater than zero.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (questionsTable == null || questionsTable.Rows.Count == 0)
            {
                MessageBox.Show("Please load the questions file first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var matchingQuestions = questionsTable.AsEnumerable()
                .Where(r => r["Category"].ToString() == category && r["Difficulty"].ToString() == difficulty);

            int available = matchingQuestions.Count();

            if (available == 0)
            {
                MessageBox.Show("No matching questions found for the selected category and difficulty.", "No Questions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (numQuestions > available)
            {
                MessageBox.Show($"Only {available} questions are available for the selected category and difficulty.\nPlease reduce the number of questions.", "Too Many Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = matchingQuestions
                .OrderBy(r => Guid.NewGuid())
                .Take(numQuestions);

            examTable = selected.CopyToDataTable();
            dgvExam.DataSource = examTable;
        }

        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            if (examTable == null || examTable.Rows.Count == 0)
            {
                MessageBox.Show("Cannot save an empty exam.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application xApp = new Excel.Application();
            xApp.DisplayAlerts = false;

            Excel.Workbook wb = xApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = wb.ActiveSheet;
            ws.Name = "Exam";

            for (int i = 0; i < examTable.Columns.Count; i++)
                ws.Cells[1, i + 1] = examTable.Columns[i].ColumnName;

            for (int i = 0; i < examTable.Rows.Count; i++)
                for (int j = 0; j < examTable.Columns.Count; j++)
                    ws.Cells[i + 2, j + 1] = examTable.Rows[i][j].ToString();

            string fileName = $"exam_{Guid.NewGuid().ToString().Substring(0, 8)}.xlsx";
            wb.SaveAs(fileName);
            wb.Close(false);

            // Also append to the database
            string dbFile = "exam_database.xlsx";
            Excel.Workbook dbWb;

            if (System.IO.File.Exists(dbFile))
                dbWb = xApp.Workbooks.Open(dbFile);
            else
                dbWb = xApp.Workbooks.Add();

            Excel.Worksheet dbSheet = dbWb.Sheets[1];
            int startRow = 1;
            while (dbSheet.Cells[startRow, 1].Value2 != null) startRow++;

            for (int i = 0; i < examTable.Columns.Count; i++)
                dbSheet.Cells[startRow, i + 1] = examTable.Columns[i].ColumnName;

            for (int i = 0; i < examTable.Rows.Count; i++)
                for (int j = 0; j < examTable.Columns.Count; j++)
                    dbSheet.Cells[startRow + i + 1, j + 1] = examTable.Rows[i][j].ToString();

            dbWb.SaveAs(dbFile);
            dbWb.Close(false);
            xApp.Quit();

            MessageBox.Show($"The exam was saved successfully!\nNew file: {fileName}\nAppended to: exam_database.xlsx", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
