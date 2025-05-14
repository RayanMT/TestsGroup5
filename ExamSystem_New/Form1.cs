using System;
using System.Windows.Forms;

namespace ExamSystem_New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            FormCreateExam examForm = new FormCreateExam();
            examForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
