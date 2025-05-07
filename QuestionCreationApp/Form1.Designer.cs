namespace QuestionCreationApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.comboCorrectAnswer = new System.Windows.Forms.ComboBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.comboQuestionType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MV Boli", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(463, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(805, 117);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question Text";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtQuestion.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.ForeColor = System.Drawing.SystemColors.Window;
            this.txtQuestion.Location = new System.Drawing.Point(63, 192);
            this.txtQuestion.MaxLength = 32799;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(410, 59);
            this.txtQuestion.TabIndex = 2;
            this.txtQuestion.Text = "text Question";
            this.txtQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(1255, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 59);
            this.label2.TabIndex = 3;
            this.label2.Text = "Answer A\t";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(1255, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 77);
            this.label3.TabIndex = 4;
            this.label3.Text = "Answer B";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(1254, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 64);
            this.label4.TabIndex = 5;
            this.label4.Text = "Answer C";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(1253, 622);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 66);
            this.label5.TabIndex = 6;
            this.label5.Text = "Answer D";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(1252, 717);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 69);
            this.label6.TabIndex = 7;
            this.label6.Text = "Correct Answer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(1255, 819);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 58);
            this.label7.TabIndex = 8;
            this.label7.Text = "Category";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(1252, 927);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 61);
            this.label8.TabIndex = 9;
            this.label8.Text = "Difficulty";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(1252, 1006);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(257, 75);
            this.label9.TabIndex = 10;
            this.label9.Text = "Add Question\t";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtA
            // 
            this.txtA.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtA.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtA.Location = new System.Drawing.Point(63, 291);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(410, 59);
            this.txtA.TabIndex = 11;
            this.txtA.Text = "txtA";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtB
            // 
            this.txtB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtB.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtB.Location = new System.Drawing.Point(63, 398);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(410, 59);
            this.txtB.TabIndex = 12;
            this.txtB.Text = "txtB";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtC
            // 
            this.txtC.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtC.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtC.Location = new System.Drawing.Point(63, 502);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(410, 59);
            this.txtC.TabIndex = 13;
            this.txtC.Text = "txtC";
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD
            // 
            this.txtD.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtD.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtD.Location = new System.Drawing.Point(63, 615);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(410, 59);
            this.txtD.TabIndex = 14;
            this.txtD.Text = "txtD";
            this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboCorrectAnswer
            // 
            this.comboCorrectAnswer.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.comboCorrectAnswer.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCorrectAnswer.ForeColor = System.Drawing.SystemColors.Info;
            this.comboCorrectAnswer.FormattingEnabled = true;
            this.comboCorrectAnswer.Location = new System.Drawing.Point(63, 755);
            this.comboCorrectAnswer.Name = "comboCorrectAnswer";
            this.comboCorrectAnswer.Size = new System.Drawing.Size(410, 49);
            this.comboCorrectAnswer.TabIndex = 15;
            this.comboCorrectAnswer.Text = "comboCorrectAnswer";
            // 
            // comboCategory
            // 
            this.comboCategory.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.comboCategory.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategory.ForeColor = System.Drawing.SystemColors.Info;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(63, 854);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(410, 49);
            this.comboCategory.TabIndex = 16;
            this.comboCategory.Text = "comboCategory";
            // 
            // comboDifficulty
            // 
            this.comboDifficulty.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.comboDifficulty.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDifficulty.ForeColor = System.Drawing.SystemColors.Info;
            this.comboDifficulty.FormattingEnabled = true;
            this.comboDifficulty.Location = new System.Drawing.Point(63, 947);
            this.comboDifficulty.Name = "comboDifficulty";
            this.comboDifficulty.Size = new System.Drawing.Size(410, 49);
            this.comboDifficulty.TabIndex = 17;
            this.comboDifficulty.Text = "comboDifficulty";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(689, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(391, 84);
            this.button1.TabIndex = 18;
            this.button1.Text = "AddQuestion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AddQuestion_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Delete.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Delete.Location = new System.Drawing.Point(689, 482);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(391, 101);
            this.Delete.TabIndex = 20;
            this.Delete.Text = "Delete Question";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // comboQuestionType
            // 
            this.comboQuestionType.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.comboQuestionType.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboQuestionType.ForeColor = System.Drawing.SystemColors.Info;
            this.comboQuestionType.FormattingEnabled = true;
            this.comboQuestionType.Location = new System.Drawing.Point(63, 1032);
            this.comboQuestionType.Name = "comboQuestionType";
            this.comboQuestionType.Size = new System.Drawing.Size(410, 49);
            this.comboQuestionType.TabIndex = 21;
            this.comboQuestionType.Text = "comboQuestionType";
            this.comboQuestionType.SelectedIndexChanged += new System.EventHandler(this.comboQuestionType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1760, 1210);
            this.Controls.Add(this.comboQuestionType);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboDifficulty);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.comboCorrectAnswer);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.ComboBox comboCorrectAnswer;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox comboQuestionType;
    }
}

