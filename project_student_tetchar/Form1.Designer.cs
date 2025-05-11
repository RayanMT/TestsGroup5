using System;
using System.Drawing;
using System.Windows.Forms;



namespace project_student_tetchar.Data
{


    partial class Form1
    {


        private Panel panelPassword;
        //private TextBox textBox2;
        private Button btnTogglePassword;

        private System.ComponentModel.IContainer components = null;
        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }


        private void comboBoxPasswordVisibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBoxPasswordVisibility.SelectedItem.ToString();
            textBox2.UseSystemPasswordChar = selected == "🙈";
        }


        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPasswordVisibility = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(129, 416);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(122, 16);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "create new account";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Location = new System.Drawing.Point(72, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Ivory;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Image = global::project_student_tetchar.Properties.Resources.l1;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(69, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.BackColor = System.Drawing.Color.Silver;
            this.comboBoxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "student",
            "teacher"});
            this.comboBoxUserType.Location = new System.Drawing.Point(72, 295);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(256, 24);
            this.comboBoxUserType.TabIndex = 15;
            this.comboBoxUserType.SelectedIndexChanged += new System.EventHandler(this.comboBoxUserType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Ivory;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Image = global::project_student_tetchar.Properties.Resources.l1;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Location = new System.Drawing.Point(69, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "student / teacher";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox2.Location = new System.Drawing.Point(72, 214);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(256, 22);
            this.textBox2.TabIndex = 13;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Image = global::project_student_tetchar.Properties.Resources.l1;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(69, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "User name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(132, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hello";
            // 
            // comboBoxPasswordVisibility
            // 
            this.comboBoxPasswordVisibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPasswordVisibility.FormattingEnabled = true;
            this.comboBoxPasswordVisibility.Items.AddRange(new object[] {
            "👁",
            "🙈"});
            this.comboBoxPasswordVisibility.Location = new System.Drawing.Point(306, 212);
            this.comboBoxPasswordVisibility.Name = "comboBoxPasswordVisibility";
            this.comboBoxPasswordVisibility.Size = new System.Drawing.Size(22, 24);
            this.comboBoxPasswordVisibility.TabIndex = 16;
            this.comboBoxPasswordVisibility.SelectedIndexChanged += new System.EventHandler(this.comboBoxPasswordVisibility_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.BackgroundImage = global::project_student_tetchar.Properties.Resources.l;
            this.button1.ForeColor = System.Drawing.Color.Goldenrod;
            this.button1.Location = new System.Drawing.Point(135, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 44);
            this.button1.TabIndex = 9;
            this.button1.Text = "log in";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::project_student_tetchar.Properties.Resources.l;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxPasswordVisibility);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.comboBoxUserType);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(37, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 531);
            this.panel1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::project_student_tetchar.Properties.Resources.l1;
            this.ClientSize = new System.Drawing.Size(1001, 860);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Wellcom ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private LinkLabel linkLabel1;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBoxUserType;
        private Label label4;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxPasswordVisibility;
        private Button button1;
        private Panel panel1;
    }
}
