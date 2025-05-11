namespace StudentGradeTracker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblImprovement;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblImprovement = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // btnLoadData
            this.btnLoadData.Location = new System.Drawing.Point(30, 20);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(150, 45);
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(30, 80);
            this.dataGridView1.Size = new System.Drawing.Size(700, 250);

            // lblAverage
            this.lblAverage.Location = new System.Drawing.Point(30, 340);
            this.lblAverage.Size = new System.Drawing.Size(400, 30);
            this.lblAverage.Text = "⭐ Average Score:";

            // lblImprovement
            this.lblImprovement.Location = new System.Drawing.Point(30, 380);
            this.lblImprovement.Size = new System.Drawing.Size(700, 180);
            this.lblImprovement.Text = "Improvement details here...";

            // Form1
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblImprovement);
            this.Text = "Student Grade Tracker";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
