namespace ExamSystemApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelQ1 = new System.Windows.Forms.Label();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.labelQuestionNumber = new System.Windows.Forms.Label();
            this.Reminder = new System.Windows.Forms.Label();
            this.Course = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelQ1
            // 
            this.labelQ1.AutoSize = true;
            this.labelQ1.Location = new System.Drawing.Point(12, 111);
            this.labelQ1.Name = "labelQ1";
            this.labelQ1.Size = new System.Drawing.Size(158, 16);
            this.labelQ1.TabIndex = 0;
            this.labelQ1.Text = "Question will appear here";
            this.labelQ1.Click += new System.EventHandler(this.labelQ1_Click);
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Location = new System.Drawing.Point(42, 154);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(79, 20);
            this.radioA.TabIndex = 1;
            this.radioA.TabStop = true;
            this.radioA.Text = "Option A";
            this.radioA.UseVisualStyleBackColor = true;
            this.radioA.CheckedChanged += new System.EventHandler(this.radioA_CheckedChanged);
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(42, 183);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(79, 20);
            this.radioB.TabIndex = 2;
            this.radioB.TabStop = true;
            this.radioB.Text = "Option B";
            this.radioB.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Location = new System.Drawing.Point(43, 212);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(79, 20);
            this.radioC.TabIndex = 3;
            this.radioC.TabStop = true;
            this.radioC.Text = "Option C";
            this.radioC.UseVisualStyleBackColor = true;
            this.radioC.CheckedChanged += new System.EventHandler(this.radioC_CheckedChanged);
            // 
            // radioD
            // 
            this.radioD.AutoSize = true;
            this.radioD.Location = new System.Drawing.Point(43, 241);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(80, 20);
            this.radioD.TabIndex = 4;
            this.radioD.TabStop = true;
            this.radioD.Text = "Option D";
            this.radioD.UseVisualStyleBackColor = true;
            this.radioD.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(680, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Next ->";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelQuestionNumber
            // 
            this.labelQuestionNumber.AutoSize = true;
            this.labelQuestionNumber.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelQuestionNumber.Location = new System.Drawing.Point(11, 70);
            this.labelQuestionNumber.Name = "labelQuestionNumber";
            this.labelQuestionNumber.Size = new System.Drawing.Size(157, 22);
            this.labelQuestionNumber.TabIndex = 7;
            this.labelQuestionNumber.Text = "Question Number ";
            // 
            // Reminder
            // 
            this.Reminder.AutoSize = true;
            this.Reminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold);
            this.Reminder.Location = new System.Drawing.Point(3, 5);
            this.Reminder.Name = "Reminder";
            this.Reminder.Size = new System.Drawing.Size(488, 18);
            this.Reminder.TabIndex = 6;
            this.Reminder.Text = "Remember that you need to answer all the question up to the last one then you can" +
    " submit the exam from there..\nwish you success!";
            // 
            // Course
            // 
            this.Course.BackColor = System.Drawing.Color.Lime;
            this.Course.Dock = System.Windows.Forms.DockStyle.Top;
            this.Course.Font = new System.Drawing.Font("Mistral", 16.2F, System.Drawing.FontStyle.Bold);
            this.Course.ForeColor = System.Drawing.Color.Black;
            this.Course.Location = new System.Drawing.Point(0, 0);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(782, 40);
            this.Course.TabIndex = 8;
            this.Course.Text = "(Course Name)\'s Exam For Software Engineering";
            this.Course.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Course.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Reminder);
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 40);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(599, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "<- Prev";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Course);
            this.Controls.Add(this.labelQuestionNumber);
            this.Controls.Add(this.radioD);
            this.Controls.Add(this.radioC);
            this.Controls.Add(this.radioB);
            this.Controls.Add(this.radioA);
            this.Controls.Add(this.labelQ1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQ1;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelQuestionNumber;
        private System.Windows.Forms.Label Reminder;
        private System.Windows.Forms.Label Course;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
    }
}
