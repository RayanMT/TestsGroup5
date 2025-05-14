namespace ExamSystem_New
{
    partial class FormCreateExam
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.TextBox txtNumQuestions;
        private System.Windows.Forms.Button btnLoadQuestions;
        private System.Windows.Forms.Button btnGenerateExam;
        private System.Windows.Forms.Button btnSaveExam;
        private System.Windows.Forms.DataGridView dgvExam;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblNumQuestions;

        private void InitializeComponent()
        {
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.txtNumQuestions = new System.Windows.Forms.TextBox();
            this.btnLoadQuestions = new System.Windows.Forms.Button();
            this.btnGenerateExam = new System.Windows.Forms.Button();
            this.btnSaveExam = new System.Windows.Forms.Button();
            this.dgvExam = new System.Windows.Forms.DataGridView();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblNumQuestions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExam)).BeginInit();
            this.SuspendLayout();

            // comboCategory
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.Location = new System.Drawing.Point(180, 30);
            this.comboCategory.Size = new System.Drawing.Size(250, 24);

            // comboDifficulty
            this.comboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDifficulty.Location = new System.Drawing.Point(180, 70);
            this.comboDifficulty.Size = new System.Drawing.Size(250, 24);

            // txtNumQuestions
            this.txtNumQuestions.Location = new System.Drawing.Point(180, 110);
            this.txtNumQuestions.Size = new System.Drawing.Size(250, 22);

            // btnLoadQuestions
            this.btnLoadQuestions.Location = new System.Drawing.Point(460, 30);
            this.btnLoadQuestions.Size = new System.Drawing.Size(180, 30);
            this.btnLoadQuestions.Text = "Load Questions";
            this.btnLoadQuestions.UseVisualStyleBackColor = true;
            this.btnLoadQuestions.Click += new System.EventHandler(this.btnLoadQuestions_Click);

            // btnGenerateExam
            this.btnGenerateExam.Location = new System.Drawing.Point(460, 70);
            this.btnGenerateExam.Size = new System.Drawing.Size(180, 30);
            this.btnGenerateExam.Text = "Generate Exam";
            this.btnGenerateExam.UseVisualStyleBackColor = true;
            this.btnGenerateExam.Click += new System.EventHandler(this.btnGenerateExam_Click);

            // btnSaveExam
            this.btnSaveExam.Location = new System.Drawing.Point(460, 110);
            this.btnSaveExam.Size = new System.Drawing.Size(180, 30);
            this.btnSaveExam.Text = "Save Exam";
            this.btnSaveExam.UseVisualStyleBackColor = true;
            this.btnSaveExam.Click += new System.EventHandler(this.btnSaveExam_Click);

            // dgvExam
            this.dgvExam.Location = new System.Drawing.Point(30, 170);
            this.dgvExam.Size = new System.Drawing.Size(740, 270);
            this.dgvExam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExam.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            // lblCategory
            this.lblCategory.Location = new System.Drawing.Point(30, 30);
            this.lblCategory.Text = "Category:";
            this.lblCategory.AutoSize = true;

            // lblDifficulty
            this.lblDifficulty.Location = new System.Drawing.Point(30, 70);
            this.lblDifficulty.Text = "Difficulty:";
            this.lblDifficulty.AutoSize = true;

            // lblNumQuestions
            this.lblNumQuestions.Location = new System.Drawing.Point(30, 110);
            this.lblNumQuestions.Text = "Number of Questions:";
            this.lblNumQuestions.AutoSize = true;

            // FormCreateExam
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.comboDifficulty);
            this.Controls.Add(this.txtNumQuestions);
            this.Controls.Add(this.btnLoadQuestions);
            this.Controls.Add(this.btnGenerateExam);
            this.Controls.Add(this.btnSaveExam);
            this.Controls.Add(this.dgvExam);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblNumQuestions);
            this.Text = "Create Exam Screen";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            ((System.ComponentModel.ISupportInitialize)(this.dgvExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
