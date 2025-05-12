using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExamSystemApp;
using System.IO;           
using ExamSystemApp;       




namespace ExamSystemApp
{
    public partial class Form1 : Form
    {
        private List<ExamQuestion> questions;
        private Dictionary<int, int> userAnswers = new Dictionary<int, int>();
        private int currentIndex = 0;
        private string difficulty = "Hard";
        private string selectedCourse = "Biology";
        private int totalExamSeconds = 600; // 10 minutes = 600 seconds
        private int timeLeft;
        private Timer examTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            difficulty = "Hard";
            selectedCourse = "Biology";

            ExcelManager.CreateUsersExcel(ExcelFiles.Users);
            //ExcelManager.ExportAllQuestionsToExcel("Questions.xlsx");

            var allQs = ExcelManager.LoadQuestionsFromExcel(ExcelFiles.Questions);

            if (allQs.Count == 0)
            {
                MessageBox.Show("No questions loaded. Excel file may be empty or invalid.");
            }
            else
            {
                int matchCount = allQs.Count(q => q.Difficulty == difficulty && q.Course == selectedCourse);
            }

            questions = allQs
                .Where(q => q.Difficulty == difficulty && q.Course == selectedCourse)
                .OrderBy(_ => Guid.NewGuid())
                .Take(4)
                .ToList();



            if (questions.Count < 4)
            {
                MessageBox.Show("Not enough questions for this difficulty and course.");
                this.Close();
                return;
            }

            // Start exam
            timeLeft = totalExamSeconds;
            examTimer = new Timer();
            examTimer.Interval = 1000;
            examTimer.Tick += ExamTimer_Tick;
            examTimer.Start();

            DisplayQuestion(currentIndex);
            UpdateNavigationButtons();
        }


        private void DisplayQuestion(int index)
        {
            var q = questions[index];
            labelQuestionNumber.Text = $"Question {index + 1} of {questions.Count}";
            labelQ1.Text = q.QuestionText;
            Course.Text = $"{q.Course} Exam - {q.Difficulty} Level";

            radioA.Text = q.Options[0];
            radioB.Text = q.Options[1];
            radioC.Text = q.Options[2];
            radioD.Text = q.Options[3];

            radioA.Checked = radioB.Checked = radioC.Checked = radioD.Checked = false;

            if (userAnswers.ContainsKey(index))
            {
                int answer = userAnswers[index];
                switch (answer)
                {
                    case 0: radioA.Checked = true; break;
                    case 1: radioB.Checked = true; break;
                    case 2: radioC.Checked = true; break;
                    case 3: radioD.Checked = true; break;
                }
            }

            // Hide C and D for T/F questions
            bool isTrueFalse = q.Options[2] == "" && q.Options[3] == "";
            radioC.Visible = radioD.Visible = !isTrueFalse;
        }

        private void SaveAnswer()
        {
            int selected = GetSelectedOption();
            if (selected != -1)
                userAnswers[currentIndex] = selected;
        }

        private int GetSelectedOption()
        {
            if (radioA.Checked) return 0;
            if (radioB.Checked) return 1;
            if (radioC.Checked) return 2;
            if (radioD.Checked) return 3;
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetSelectedOption() == -1)
            {
                MessageBox.Show("Please select an answer before proceeding.");
                return;
            }

            SaveAnswer();
            currentIndex++;
            DisplayQuestion(currentIndex);
            UpdateNavigationButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            currentIndex--;
            DisplayQuestion(currentIndex);
            UpdateNavigationButtons();
        }

        private void SubmitExam()
        {
            if (GetSelectedOption() == -1)
            {
                MessageBox.Show("Please select an answer before submitting.");
                return;
            }

            SaveAnswer();
            examTimer.Stop();

            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (userAnswers.ContainsKey(i) && userAnswers[i] == questions[i].CorrectAnswerIndex)
                {
                    score += 25;
                }
            }

            MessageBox.Show($"Exam finished!\nYour score: {score} / 100", "Result");
            this.Close();
            int minutesTaken = (totalExamSeconds - timeLeft) / 60;
            ExcelManager.SaveExamResult(
                ExcelFiles.Results,
                "S02", selectedCourse, difficulty, score, minutesTaken, totalExamSeconds / 60
            );

        }

        private void UpdateNavigationButtons()
        {
            button2.Visible = currentIndex > 0;
            button1.Visible = true;

            if (currentIndex == questions.Count - 1)
            {
                button1.Text = "Submit";
                button1.Click -= button1_Click;
                button1.Click += (s, e) => SubmitExam();
            }
            else
            {
                button1.Text = "Next ->";
                button1.Click -= (s, e) => SubmitExam();
                button1.Click -= button1_Click;
                button1.Click += button1_Click;
            }
        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            TimeSpan t = TimeSpan.FromSeconds(timeLeft);
            this.Text = $"Time Left: {t:mm\\:ss}";

            if (timeLeft <= 0)
            {
                examTimer.Stop();
                MessageBox.Show("Time is up! The exam will be submitted.");
                SubmitExam();
            }
        }

        // Designer handlers (even if empty)
        private void labelQ1_Click(object sender, EventArgs e) { }
        private void radioA_CheckedChanged(object sender, EventArgs e) { }
        private void radioC_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
