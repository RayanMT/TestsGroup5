using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuestionCreationApp
{
    public partial class Form1 : Form
    {
        private List<Question> questions = new List<Question>();

        string excelPath = "questions.xlsx";

        public Form1()
        {
            InitializeComponent();
            InitializeDropdowns();
            comboQuestionType.SelectedIndexChanged += comboQuestionType_SelectedIndexChanged;
            LoadFromExcelIfExists();
        }

        private void InitializeDropdowns()
        {
            comboQuestionType.Items.AddRange(new string[] { "MultipleChoice", "YesNo", "FillInBlank" });
            comboQuestionType.SelectedIndex = 0;

            comboCorrectAnswer.Items.AddRange(new string[] { "A", "B", "C", "D" });
            comboCorrectAnswer.SelectedIndex = 0;

            comboCategory.Items.AddRange(new string[] { "Algorithms", "Databases", "Testing" });
            comboCategory.SelectedIndex = 0;

            comboDifficulty.Items.AddRange(new string[] { "Easy", "Medium", "Hard" });
            comboDifficulty.SelectedIndex = 0;
        }

        private void comboQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboQuestionType.SelectedItem.ToString();

            bool isMCQ = selectedType == "MultipleChoice";
            bool isYesNo = selectedType == "YesNo";
            bool isFillBlank = selectedType == "FillInBlank";

            // Show/Hide answer textboxes
            txtA.Visible = isMCQ;
            txtB.Visible = isMCQ;
            txtC.Visible = isMCQ;
            txtD.Visible = isMCQ;

            // Prepare the correct answer ComboBox
            comboCorrectAnswer.Items.Clear();

            if (isMCQ)
            {
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDownList;
                comboCorrectAnswer.Items.AddRange(new string[] { "A", "B", "C", "D" });
                comboCorrectAnswer.SelectedIndex = 0;
            }
            else if (isYesNo)
            {
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDownList;
                comboCorrectAnswer.Items.AddRange(new string[] { "Yes", "No" });
                comboCorrectAnswer.SelectedIndex = 0;
            }
            else if (isFillBlank)
            {
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDown;
                comboCorrectAnswer.Text = ""; // Let the user type the correct answer manually
            }
        }




        private void AddQuestion_Click(object sender, EventArgs e)
        {
            string selectedType = comboQuestionType.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Please fill in the question.", "Error");
                return;
            }

            // Validate based on type
            if (selectedType == "MultipleChoice")
            {
                if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text) ||
                    string.IsNullOrWhiteSpace(txtC.Text) || string.IsNullOrWhiteSpace(txtD.Text))
                {
                    MessageBox.Show("Please fill in all answers for Multiple Choice.", "Error");
                    return;
                }
            }

            // Pre-fill Yes/No fields
            if (selectedType == "YesNo")
            {
                txtA.Text = "Yes";
                txtB.Text = "No";
                txtC.Text = "";
                txtD.Text = "";
            }

            // Clear extra options in FillInBlank
            if (selectedType == "FillInBlank")
            {
                txtA.Text = "";
                txtB.Text = "";
                txtC.Text = "";
                txtD.Text = "";
            }

            // Handle correct answer safely
            string correctAnswer;
            if (selectedType == "FillInBlank")
            {
                correctAnswer = comboCorrectAnswer.Text.Trim();
                if (string.IsNullOrWhiteSpace(correctAnswer))
                {
                    MessageBox.Show("Please enter the correct answer for Fill In The Blank.", "Error");
                    return;
                }
            }
            else
            {
                if (comboCorrectAnswer.SelectedItem == null)
                {
                    MessageBox.Show("Please select a correct answer.", "Error");
                    return;
                }
                correctAnswer = comboCorrectAnswer.SelectedItem.ToString();
            }

            // Create question object
            Question q = new Question
            {
                Type = selectedType,
                Text = txtQuestion.Text,
                AnswerA = txtA.Text,
                AnswerB = txtB.Text,
                AnswerC = txtC.Text,
                AnswerD = txtD.Text,
                CorrectAnswer = correctAnswer,
                Category = comboCategory.SelectedItem?.ToString() ?? "",
                Difficulty = comboDifficulty.SelectedItem?.ToString() ?? ""
            };

            questions.Add(q);
            SaveAllQuestionsToExcel();
            ClearInputs();
        }


        private void ClearInputs()
        {
            txtQuestion.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            comboCategory.SelectedIndex = 0;
            comboDifficulty.SelectedIndex = 0;

            // Reset comboCorrectAnswer depending on selected question type
            string selectedType = comboQuestionType.SelectedItem.ToString();

            if (selectedType == "MultipleChoice")
            {
                comboCorrectAnswer.Items.Clear();
                comboCorrectAnswer.Items.AddRange(new string[] { "A", "B", "C", "D" });
                comboCorrectAnswer.SelectedIndex = 0;
            }
            else if (selectedType == "YesNo")
            {
                comboCorrectAnswer.Items.Clear();
                comboCorrectAnswer.Items.AddRange(new string[] { "Yes", "No" });
                comboCorrectAnswer.SelectedIndex = 0;
            }
            else if (selectedType == "FillInBlank")
            {
                comboCorrectAnswer.Items.Clear();
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDown;
                comboCorrectAnswer.Text = "";
            }
        }


        private void SaveAllQuestionsToExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Questions");

                // Headers
                string[] headers = { "Type", "Question", "A", "B", "C", "D", "Correct", "Category", "Difficulty" };
                for (int i = 0; i < headers.Length; i++)
                    worksheet.Cell(1, i + 1).Value = headers[i];

                // Data
                for (int i = 0; i < questions.Count; i++)
                {
                    var q = questions[i];

                    string type = comboQuestionType.SelectedItem.ToString();

                    worksheet.Cell(i + 2, 1).Value = type;
                    worksheet.Cell(i + 2, 2).Value = q.Text;

                    if (type == "MultipleChoice")
                    {
                        worksheet.Cell(i + 2, 3).Value = q.AnswerA;
                        worksheet.Cell(i + 2, 4).Value = q.AnswerB;
                        worksheet.Cell(i + 2, 5).Value = q.AnswerC;
                        worksheet.Cell(i + 2, 6).Value = q.AnswerD;
                    }
                    else
                    {
                        // Leave other answers empty
                        worksheet.Cell(i + 2, 3).Value = "";
                        worksheet.Cell(i + 2, 4).Value = "";
                        worksheet.Cell(i + 2, 5).Value = "";
                        worksheet.Cell(i + 2, 6).Value = "";
                    }

                    worksheet.Cell(i + 2, 7).Value = q.CorrectAnswer;
                    worksheet.Cell(i + 2, 8).Value = q.Category;
                    worksheet.Cell(i + 2, 9).Value = q.Difficulty;
                }

                workbook.SaveAs(excelPath);
            }
        }

        private void LoadFromExcelIfExists()
        {
            if (!File.Exists(excelPath)) return;

            using (var workbook = new XLWorkbook(excelPath))
            {
                var worksheet = workbook.Worksheet("Questions");
                var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                foreach (var row in rows)
                {
                    var q = new Question
                    {
                        Type = row.Cell(1).GetString(),
                        Text = row.Cell(2).GetString(),
                        AnswerA = row.Cell(3).GetString(),
                        AnswerB = row.Cell(4).GetString(),
                        AnswerC = row.Cell(5).GetString(),
                        AnswerD = row.Cell(6).GetString(),
                        CorrectAnswer = row.Cell(7).GetString(),
                        Category = row.Cell(8).GetString(),
                        Difficulty = row.Cell(9).GetString()
                    };
                    questions.Add(q);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete feature disabled. Display is removed.");
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }


    }
}