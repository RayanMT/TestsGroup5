using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace StudentGradeTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StyleUI();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadExcelData();
        }

        private void LoadExcelData()
        {
            try
            {
                string excelPath = "StudentGrades.xlsx";
                var dataTable = new DataTable();

                using (var workbook = new XLWorkbook(excelPath))
                {
                    var worksheet = workbook.Worksheet(1);
                    bool firstRow = true;

                    foreach (var row in worksheet.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (var cell in row.Cells())
                                dataTable.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                        {
                            var newRow = dataTable.NewRow();
                            int i = 0;
                            foreach (var cell in row.Cells())
                                newRow[i++] = cell.Value.ToString();
                            dataTable.Rows.Add(newRow);
                        }
                    }
                }

                dataGridView1.DataSource = dataTable;

                CalculateAverageAndDisplay(dataTable);
                HighlightBestAndWorst(dataTable);
                AnalyzeImprovement(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Excel data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateAverageAndDisplay(DataTable table)
        {
            var scores = table.AsEnumerable().Select(r => int.Parse(r["Score"].ToString()));
            double average = scores.Average();
            lblAverage.Text = $"⭐ Average Score: {average:F2}";
        }

        private void HighlightBestAndWorst(DataTable table)
        {
            int maxScore = table.AsEnumerable().Max(r => int.Parse(r["Score"].ToString()));
            int minScore = table.AsEnumerable().Min(r => int.Parse(r["Score"].ToString()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                int score = int.Parse(row.Cells["Score"].Value.ToString());
                row.DefaultCellStyle.BackColor = score == maxScore ? Color.FromArgb(198, 239, 206) :
                                                  score == minScore ? Color.FromArgb(255, 199, 206) :
                                                  Color.White;
            }
        }

        private void AnalyzeImprovement(DataTable table)
        {
            var rows = table.AsEnumerable().OrderBy(r => DateTime.Parse(r["Date"].ToString())).ToList();
            if (rows.Count < 2)
            {
                lblImprovement.Text = "Not enough data to analyze improvement.";
                return;
            }

            string summary = "📈 Improvement Over Time:\n";
            double totalChange = 0;
            double biggestDrop = 0;

            for (int i = 1; i < rows.Count; i++)
            {
                int prevScore = int.Parse(rows[i - 1]["Score"].ToString());
                int currentScore = int.Parse(rows[i]["Score"].ToString());
                int change = currentScore - prevScore;

                summary += $"Exam {i} → Exam {i + 1}: {prevScore} → {currentScore} ({(change >= 0 ? "+" : "")}{change})\n";
                totalChange += change;
                if (change < biggestDrop)
                    biggestDrop = change;
            }

            double avgChange = totalChange / (rows.Count - 1);
            summary += $"\n🔄 Average change per exam: {avgChange:F2} points.\n";
            summary += $"⚠️ Biggest drop: {biggestDrop} points. Keep pushing!";

            lblImprovement.Text = summary;
        }

        private void StyleUI()
        {
            // 🌸 Form styling
            this.BackColor = Color.FromArgb(245, 245, 255);
            this.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // ✨ Button styling
            btnLoadData.FlatStyle = FlatStyle.Flat;
            btnLoadData.BackColor = Color.MediumSlateBlue;
            btnLoadData.ForeColor = Color.White;
            btnLoadData.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLoadData.FlatAppearance.BorderSize = 0;
            btnLoadData.Cursor = Cursors.Hand;
            btnLoadData.Padding = new Padding(5);

            // 🎨 DataGridView styling
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 250);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SlateBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // 📊 Improvement label styling
            lblImprovement.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblImprovement.BackColor = Color.FromArgb(240, 240, 255);
            lblImprovement.BorderStyle = BorderStyle.FixedSingle;
            lblImprovement.Padding = new Padding(10);
        }
    }
}
