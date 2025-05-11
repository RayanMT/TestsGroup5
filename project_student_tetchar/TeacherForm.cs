using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_student_tetchar
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
            this.Load += TeacherForm_Load;
        }


        private void TeacherForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ControlBox = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*    // אם יש לך טופס בשם CreateQuestionForm
    CreateQuestionForm form = new CreateQuestionForm();
    form.Show();  // או form.ShowDialog(); אם אתה רוצה שיהיה מודאלי*/
            MessageBox.Show("כאן תוכל ליצור שאלות חדשות עבור המבחנים.", "יצירת שאלות", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /*   // הנחה שיש טופס ליצירת מבחנים
    CreateExamForm form = new CreateExamForm();
    form.Show(); // או ShowDialog אם אתה רוצה שיחסום את החלון הקודם*/
            MessageBox.Show("כאן תוכל להרכיב מבחן מתוך מאגר השאלות.", "יצירת מבחן", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            /*    GradesAnalysisForm analysisForm = new GradesAnalysisForm();
    analysisForm.Show(); // או .ShowDialog() לפי הצורך*/
            MessageBox.Show("כאן יוצג ניתוח ציונים: ממוצע, ציונים קודמים, התקדמות ועוד.",
                "ניתוח ציונים",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit(); // סוגר את כל האפליקציה
            DialogResult result = MessageBox.Show("האם אתה בטוח שברצונך לצאת?",
                                      "אישור יציאה",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
