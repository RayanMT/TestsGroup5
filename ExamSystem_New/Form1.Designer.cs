namespace ExamSystem_New
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCreateExam;
        private System.Windows.Forms.Button btnExit;

        private void InitializeComponent()
        {
            this.btnCreateExam = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnCreateExam
            this.btnCreateExam.Location = new System.Drawing.Point(300, 130);
            this.btnCreateExam.Size = new System.Drawing.Size(200, 40);
            this.btnCreateExam.Text = "Create Exam";
            this.btnCreateExam.UseVisualStyleBackColor = true;
            this.btnCreateExam.Click += new System.EventHandler(this.btnCreateExam_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(300, 190);
            this.btnExit.Size = new System.Drawing.Size(200, 40);
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnCreateExam);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ResumeLayout(false);
        }
    }
}
