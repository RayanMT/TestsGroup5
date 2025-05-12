using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WindowsFormsApp1
{
    public partial class Student_Grades : Form
    {
        DataTable allData;

        public Student_Grades()
        {
            InitializeComponent();
            this.Load += Student_Grades_Load;
        }

        private void Student_Grades_Load(object sender, EventArgs e)
        {
            LoadExcelToGrid();
        }

        private void LoadExcelToGrid()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "Data", "student_grades11.xlsx");

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("קובץ student_grades11.xlsx לא נמצא בנתיב:\n" + filePath);
                    return;
                }

                allData = new DataTable();

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    bool firstRow = true;

                    foreach (var row in worksheet.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (var cell in row.Cells())
                                allData.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                        {
                            var newRow = allData.NewRow();
                            int i = 0;
                            foreach (var cell in row.Cells())
                                newRow[i++] = cell.Value.ToString();
                            allData.Rows.Add(newRow);
                        }
                    }
                }

                RecalculateAveragesByID();
                dataGridView1.DataSource = allData;
                UpdateOverallAverage();
                ShowAverageChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הקובץ: " + ex.Message);
            }
        }

        private void RecalculateAveragesByID()
        {
            if (allData == null || !allData.Columns.Contains("ID") || !allData.Columns.Contains("Average"))
                return;

            var idGroups = allData.AsEnumerable()
                .Where(row => !string.IsNullOrEmpty(row["ID"].ToString()))
                .GroupBy(row => row["ID"].ToString());

            foreach (var group in idGroups)
            {
                var grades = group
                    .Select(row => double.TryParse(row["Average"].ToString(), out double g) ? g : (double?)null)
                    .Where(g => g.HasValue)
                    .Select(g => g.Value)
                    .ToList();

                if (grades.Count == 0)
                    continue;

                double average = grades.Average();

                foreach (var row in group)
                {
                    row["Average"] = average.ToString("0.00");
                }
            }
        }

        private void UpdateOverallAverage()
        {
            if (allData == null || allData.Rows.Count == 0)
                return;

            var avgByID = allData.AsEnumerable()
                .GroupBy(r => r["ID"].ToString())
                .Select(g =>
                {
                    var grade = g.First()["Average"].ToString();
                    return double.TryParse(grade, out double val) ? val : (double?)null;
                })
                .Where(g => g.HasValue)
                .Select(g => g.Value)
                .ToList();

            if (avgByID.Count > 0)
            {
                double overallAvg = avgByID.Average();
                textBox2.Text = overallAvg.ToString("0.00");
            }
            else
            {
                textBox2.Text = "אין נתונים";
            }
        }

        private void ShowAverageChart()
        {
            if (allData == null || allData.Rows.Count == 0)
            {
                MessageBox.Show("אין נתונים להצגה.");
                return;
            }

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chart1.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "ממוצעים לפי סטודנט",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };

            var grouped = allData.AsEnumerable()
                .GroupBy(row => row["ID"].ToString());

            foreach (var group in grouped)
            {
                string name = group.First()["Name"].ToString();
                string id = group.Key;
                string label = $"{name} ({id})";

                string avgStr = group.First()["Average"].ToString();
                if (double.TryParse(avgStr, out double avg))
                {
                    series.Points.AddXY(label, avg);
                }
            }

            chart1.Series.Add(series);
        }

        private void btnSearchGreade_Click(object sender, EventArgs e)
        {
            if (allData == null || allData.Rows.Count == 0)
            {
                MessageBox.Show("לא נטענו נתונים.");
                return;
            }

            string searchName = textBox1.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchName))
            {
                dataGridView1.DataSource = allData;
                return;
            }

            var filteredRows = allData.AsEnumerable()
                .Where(row => row["Name"].ToString().ToLower().Contains(searchName));

            if (filteredRows.Any())
            {
                dataGridView1.DataSource = filteredRows.CopyToDataTable();
            }
            else
            {
                MessageBox.Show("לא נמצא סטודנט עם השם שחיפשת.");
                dataGridView1.DataSource = allData;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            ShowAverageChart();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("אנא בחר שורה לעדכון או הוסף חדשה לטבלה.");
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string name = selectedRow.Cells["Name"].Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("שדה 'Name' חובה.");
                    return;
                }

                DataRow existingRow = allData.AsEnumerable()
                    .FirstOrDefault(row => row["Name"].ToString().Equals(name, StringComparison.OrdinalIgnoreCase));

                if (existingRow != null)
                {
                    foreach (DataColumn col in allData.Columns)
                    {
                        existingRow[col.ColumnName] = selectedRow.Cells[col.ColumnName].Value?.ToString() ?? "";
                    }
                }
                else
                {
                    DataRow newRow = allData.NewRow();
                    foreach (DataColumn col in allData.Columns)
                    {
                        newRow[col.ColumnName] = selectedRow.Cells[col.ColumnName].Value?.ToString() ?? "";
                    }
                    allData.Rows.Add(newRow);
                }

                RecalculateAveragesByID();

                string filePath = Path.Combine(Application.StartupPath, "Data", "student_grades11.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    for (int i = 0; i < allData.Columns.Count; i++)
                        worksheet.Cell(1, i + 1).Value = allData.Columns[i].ColumnName;

                    for (int i = 0; i < allData.Rows.Count; i++)
                    {
                        for (int j = 0; j < allData.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = allData.Rows[i][j]?.ToString();
                        }
                    }

                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("הנתונים נשמרו בהצלחה.");
                UpdateOverallAverage();
                ShowAverageChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בשמירה: " + ex.Message);
            }
        }

        // === פונקציות שנדרשות בגלל חיבורים מה-Designer ===

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // אופציונלי: פעולות בזמן שינוי הטקסט
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // פעולה מיותרת – הנתונים כבר נטענים בפונקציה LoadExcelToGrid()
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // לא דרוש כרגע
        }
    }
}
