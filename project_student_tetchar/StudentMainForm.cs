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
    public partial class StudentMainForm : Form
    {
        public StudentMainForm()
        {
            InitializeComponent();
            this.Load += StudentMainForm_Load;
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ControlBox = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // כאן אתה יכול לפתוח חלון חדש של תרגול או להציג הודעה
            MessageBox.Show("ברוך הבא לתרגול!", "תרגול", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //לדוגמה: פתיחת טופס חדש בשם PracticeForm
        //PracticeForm practiceForm = new PracticeForm();
        //    practiceForm.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // כאן אפשר להציג היסטוריית ציונים, למשל ב־MessageBox או לפתוח חלון ייעודי
            MessageBox.Show("כאן תוצג היסטוריית הציונים שלך.", "היסטוריית ציונים", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // לדוגמה, אם יש לך טופס בשם GradesHistoryForm:
            // GradesHistoryForm historyForm = new GradesHistoryForm();
            // historyForm.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // אפשרות 1: הודעה פשוטה
            MessageBox.Show("כאן יוצג מעקב אחר ההתקדמות בלימודים או במבחנים.", "מעקב התקדמות", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // אפשרות 2: פתיחה של טופס ייעודי
            // ProgressTrackingForm progressForm = new ProgressTrackingForm();
            // progressForm.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
   
            Application.Exit();
        }

    }
}
