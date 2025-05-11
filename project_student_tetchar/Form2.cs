//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.OleDb;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace project_student_tetchar
//{
//    public partial class Form2 : Form
//    {
//        private OleDbConnection connection;
//        private string dbPath = "UsersDB.xlsx";
//        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;'";


  
//        public Form2()
//        {
//            InitializeComponent();

//            string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\UsersDB.xlsx");
//            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UsersDB.xlsx");

//            // אם הקובץ לא קיים - נעתיק אותו מהתיקיה הראשית
//            if (!File.Exists(destPath))
//            {
//                try
//                {
//                    File.Copy(sourcePath, destPath);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"שגיאה בהעתקת הקובץ: {ex.Message}", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    Application.Exit();
//                    return;
//                }
//            }

//            // בדיקה אם הקובץ נעול (למשל פתוח באקסל)
//            if (IsFileLocked(new FileInfo(destPath)))
//            {
//                MessageBox.Show("הקובץ UsersDB.xlsx פתוח או נעול. אנא סגור אותו לפני הפעלת המערכת.", "File Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                Application.Exit();
//                return;
//            }

//            // שרשור מחרוזת החיבור
//            this.connectionString = string.Format(connectionString, destPath);

//            InitializeDatabase();
//            ApplyDesign();

//            // הוספת כפתור בדיקה למעבר ישיר לסטודנט (לצורך פיתוח)
//            AddTestStudentButton();
//        }

//        private void AddTestStudentButton()
//        {
//            Button btnTestStudent = new Button
//            {
//                Text = "Test Student Login",
//                Location = new Point(40, 420),
//                Width = 250,
//                BackColor = Color.LightGray
//            };
//            btnTestStudent.Click += (s, e) => {
//                // הזנה אוטומטית של פרטי סטודנט
//                ((TextBox)this.Controls["textBox1"]).Text = "test_student";
//                ((TextBox)this.Controls["textBox2"]).Text = "student123";
//                ((RadioButton)this.Controls["rbStudent"]).Checked = true;

//                // לחיצה אוטומטית על כפתור ההתחברות
//                button3_Click(s, e);
//            };
//            this.Controls.Add(btnTestStudent);
//        }


//        private bool IsFileLocked(FileInfo file)
//        {
//            FileStream stream = null;
//            try
//            {
//                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
//            }
//            catch (IOException)
//            {
//                return true; // הקובץ נעול
//            }
//            finally
//            {
//                stream?.Close();
//            }
//            return false; // הקובץ לא נעול
//        }

//        private void InitializeDatabase()
//        {
//            try
//            {
//                connection = new OleDbConnection(connectionString);
//                if (!TableExists("Users"))
//                {
//                    CreateUsersTable();
//                    // הוספת משתמש סטודנט לדוגמה אם הטבלה נוצרה חדשה
//                    AddTestStudentUser();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Database init error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void AddTestStudentUser()
//        {
//            try
//            {
//                using (OleDbConnection conn = new OleDbConnection(connectionString))
//                {
//                    conn.Open();
//                    string insert = "INSERT INTO [Users$] (Username, Password, ID, Email, UserType) VALUES (?, ?, ?, ?, ?)";
//                    OleDbCommand cmd = new OleDbCommand(insert, conn);
//                    cmd.Parameters.AddWithValue("?", "test_student");
//                    cmd.Parameters.AddWithValue("?", "student123");
//                    cmd.Parameters.AddWithValue("?", "123456789");
//                    cmd.Parameters.AddWithValue("?", "student@test.com");
//                    cmd.Parameters.AddWithValue("?", "Student");
//                    cmd.ExecuteNonQuery();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error adding test student: {ex.Message}");
//            }
//        }

//        private bool TableExists(string tableName)
//        {
//            using (OleDbConnection conn = new OleDbConnection(connectionString))
//            {
//                conn.Open();
//                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
//                foreach (DataRow row in dt.Rows)
//                {
//                    if (row["TABLE_NAME"].ToString() == tableName + "$")
//                        return true;
//                }
//                return false;
//            }
//        }

//        private void CreateUsersTable()
//        {
//            using (OleDbConnection conn = new OleDbConnection(connectionString))
//            {
//                conn.Open();
//                OleDbCommand cmd = new OleDbCommand();
//                cmd.Connection = conn;
//                cmd.CommandText = "CREATE TABLE [Users$] ([Username] TEXT, [Password] TEXT, [ID] TEXT, [Email] TEXT, [UserType] TEXT)";
//                cmd.ExecuteNonQuery();
//            }
//        }

//        private void ApplyDesign()
//        {
//            this.Text = "Exam Login System";
//            this.Size = new Size(350, 550);
//            this.FormBorderStyle = FormBorderStyle.FixedSingle;
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.BackColor = Color.White;

//            Label lblTitle = new Label
//            {
//                Text = "Log In",
//                Font = new Font("Arial", 20, FontStyle.Bold),
//                ForeColor = Color.DarkSlateBlue,
//                Location = new Point(110, 20),
//                AutoSize = true
//            };
//            this.Controls.Add(lblTitle);

//            Label label3 = new Label { Text = "Username", Location = new Point(40, 80) };
//            TextBox textBox1 = new TextBox { Name = "textBox1", Location = new Point(40, 100), Width = 250 };
//            this.Controls.Add(label3);
//            this.Controls.Add(textBox1);

//            Label label5 = new Label { Text = "Password", Location = new Point(40, 140) };
//            TextBox textBox2 = new TextBox { Name = "textBox2", Location = new Point(40, 160), Width = 250, PasswordChar = '*' };
//            this.Controls.Add(label5);
//            this.Controls.Add(textBox2);

//            Label lblType = new Label { Text = "User Type", Location = new Point(40, 200) };
//            RadioButton rbStudent = new RadioButton { Name = "rbStudent", Text = "Student", Checked = true, Location = new Point(40, 220) };
//            RadioButton rbTeacher = new RadioButton { Name = "rbTeacher", Text = "Teacher", Location = new Point(140, 220) };
//            this.Controls.Add(lblType);
//            this.Controls.Add(rbStudent);
//            this.Controls.Add(rbTeacher);

//            Button button3 = new Button
//            {
//                Name = "button3",
//                Text = "Login",
//                Location = new Point(40, 270),
//                Width = 250,
//                BackColor = Color.SteelBlue,
//                ForeColor = Color.White
//            };
//            button3.Click += button3_Click;
//            this.Controls.Add(button3);

//            Label lblForgot = new Label
//            {
//                Text = "Forgot password?",
//                ForeColor = Color.Blue,
//                Location = new Point(40, 320),
//                Cursor = Cursors.Hand
//            };
//            lblForgot.Click += (s, e) => MessageBox.Show("Contact admin to reset password.", "Info");
//            this.Controls.Add(lblForgot);

//            Button btnCreate = new Button
//            {
//                Name = "button3_1",
//                Text = "Create New Account",
//                Location = new Point(40, 370),
//                Width = 250,
//                BackColor = Color.DarkGreen,
//                ForeColor = Color.White
//            };
//            btnCreate.Click += button3_Click_1;
//            this.Controls.Add(btnCreate);

//            Panel panel2 = new Panel { Name = "panel2", Location = new Point(40, 220), Size = new Size(250, 30) };
//            panel2.Controls.Add(rbStudent);
//            panel2.Controls.Add(rbTeacher);
//            panel2.Paint += panel2_Paint;
//            this.Controls.Add(panel2);
//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            string username = ((TextBox)this.Controls["textBox1"]).Text.Trim();
//            string password = ((TextBox)this.Controls["textBox2"]).Text;
//            string userType = ((RadioButton)this.Controls["rbStudent"]).Checked ? "Student" : "Teacher";

//            if (username == "" || password == "")
//            {
//                MessageBox.Show("Enter username and password.", "Error");
//                return;
//            }

//            try
//            {
//                using (OleDbConnection conn = new OleDbConnection(connectionString))
//                {
//                    conn.Open();
//                    string query = "SELECT * FROM [Users$] WHERE Username = ? AND Password = ? AND UserType = ?";
//                    OleDbCommand cmd = new OleDbCommand(query, conn);
//                    cmd.Parameters.AddWithValue("?", username);
//                    cmd.Parameters.AddWithValue("?", password);
//                    cmd.Parameters.AddWithValue("?", userType);

//                    using (OleDbDataReader reader = cmd.ExecuteReader())
//                    {
//                        if (reader.HasRows)
//                        {
//                            this.Hide(); // הסתרת חלון ההתחברות

//                            if (userType.ToLower() == "student")
//                            {
//                                StudentMainForm studentForm = new StudentMainForm(username);
//                                studentForm.FormClosed += (s, ev) => this.Close();
//                                studentForm.Show();
//                            }
//                            else
//                            {
//                                TeacherForm teacherForm = new TeacherForm(username);
//                                teacherForm.FormClosed += (s, ev) => this.Close();
//                                teacherForm.Show();
//                            }

//                        }
//                        else
//                        {
//                            MessageBox.Show("Login failed. Check credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Login error: {ex.Message}");
//            }
//        }

//        private void button3_Click_1(object sender, EventArgs e)
//        {
//            Form regForm = new Form();
//            regForm.Text = "Register";
//            regForm.Size = new Size(350, 400);
//            regForm.StartPosition = FormStartPosition.CenterParent;

//            Label lblUser = new Label { Text = "Username", Location = new Point(20, 20) };
//            TextBox txtUser = new TextBox { Location = new Point(20, 40), Width = 280 };

//            Label lblPass = new Label { Text = "Password", Location = new Point(20, 70) };
//            TextBox txtPass = new TextBox { Location = new Point(20, 90), Width = 280, PasswordChar = '*' };

//            Label lblId = new Label { Text = "ID", Location = new Point(20, 120) };
//            TextBox txtId = new TextBox { Location = new Point(20, 140), Width = 280 };

//            Label lblEmail = new Label { Text = "Email", Location = new Point(20, 170) };
//            TextBox txtEmail = new TextBox { Location = new Point(20, 190), Width = 280 };

//            Label lblType = new Label { Text = "User Type", Location = new Point(20, 220) };
//            RadioButton rbStudent = new RadioButton { Text = "Student", Checked = true, Location = new Point(20, 240) };
//            RadioButton rbTeacher = new RadioButton { Text = "Teacher", Location = new Point(120, 240) };

//            Button btnRegister = new Button { Text = "Register", Location = new Point(20, 280), Width = 280 };
//            btnRegister.Click += (s, ev) =>
//            {
//                string type = rbStudent.Checked ? "Student" : "Teacher";
//                try
//                {
//                    using (OleDbConnection conn = new OleDbConnection(connectionString))
//                    {
//                        conn.Open();
//                        string insert = "INSERT INTO [Users$] (Username, Password, ID, Email, UserType) VALUES (?, ?, ?, ?, ?)";
//                        OleDbCommand cmd = new OleDbCommand(insert, conn);
//                        cmd.Parameters.AddWithValue("?", txtUser.Text);
//                        cmd.Parameters.AddWithValue("?", txtPass.Text);
//                        cmd.Parameters.AddWithValue("?", txtId.Text);
//                        cmd.Parameters.AddWithValue("?", txtEmail.Text);
//                        cmd.Parameters.AddWithValue("?", type);
//                        cmd.ExecuteNonQuery();
//                        MessageBox.Show("User registered successfully!");
//                        regForm.Close();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Registration error: {ex.Message}");
//                }
//            };

//            regForm.Controls.AddRange(new Control[] {
//                lblUser, txtUser, lblPass, txtPass,
//                lblId, txtId, lblEmail, txtEmail,
//                lblType, rbStudent, rbTeacher,
//                btnRegister
//            });

//            regForm.ShowDialog();
//        }


//        // ===== מתודות נוספות =====

//        private void Form1_Load(object sender, EventArgs e) { }

//        private void textBox1_TextChanged(object sender, EventArgs e)
//        {
//            TextBox txt = sender as TextBox;
//            string input = txt.Text;

//            // בדיקה: שם משתמש חייב להכיל רק אותיות ומספרים (ללא רווחים, סימנים וכו׳)
//            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9]*$"))
//            {
//                txt.BackColor = Color.MistyRose;
//                ToolTip tip = new ToolTip();
//                tip.Show("Username must contain only letters and numbers.", txt, 0, -20, 2000);
//            }
//            else if (input.Length > 0 && input.Length < 4)
//            {
//                txt.BackColor = Color.LightYellow;
//            }
//            else
//            {
//                txt.BackColor = Color.White;
//            }
//        }


//        private void textBox2_TextChanged(object sender, EventArgs e)
//        {

//        }
//        /*----------------------------------------------------********************************************************************/

//        private void label5_Click(object sender, EventArgs e)
//        {
           
//            MessageBox.Show(
//                "Password must be at least 6 characters.\nUse letters, numbers, and symbols.",
//                "Password Tips",
//                MessageBoxButtons.OK,
//                MessageBoxIcon.Information
//            );
//        }


//        private void label3_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show(
//                "Your username is what you use to log in.\nUsually it's your ID or email.",
//                "Username Info",
//                MessageBoxButtons.OK,
//                MessageBoxIcon.Information
//            );
//        }



//        private void panel2_Paint(object sender, PaintEventArgs e)
//        {
//            Panel panel = sender as Panel;
//            Graphics g = e.Graphics;

//            // רקע עדין בצבע בהיר
//            using (SolidBrush backgroundBrush = new SolidBrush(Color.WhiteSmoke))
//            {
//                g.FillRectangle(backgroundBrush, panel.ClientRectangle);
//            }

//            // מסגרת דקה מסביב לפאנל
//            using (Pen borderPen = new Pen(Color.Gray, 1))
//            {
//                g.DrawRectangle(borderPen, 0, 0, panel.Width - 1, panel.Height - 1);
//            }

//            // קו תחתון מודגש (עיצוב)
//            using (Pen linePen = new Pen(Color.SteelBlue, 2))
//            {
//                g.DrawLine(linePen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
//            }
//        }



//        /*------------------------------------------------------------------***************************************************************/

//        //private void button1_Click(object sender, EventArgs e)
//        //{
//        //    Button button1 = new Button();
//        //    button1.Name = "button1"; // חשוב
//        //    button1.Text = "X";
//        //    button1.Font = new Font("Arial", 10, FontStyle.Bold);
//        //    button1.ForeColor = Color.White;
//        //    button1.BackColor = Color.DarkRed;
//        //    button1.FlatStyle = FlatStyle.Flat;
//        //    button1.FlatAppearance.BorderSize = 0;
//        //    button1.Size = new Size(30, 30);
//        //    button1.Location = new Point(this.ClientSize.Width - 40, 10);
//        //    button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
//        //    button1.Click += button1_Click;
//        //    this.Controls.Add(button1);
//        //    this.Close();

//        //}

//        private void panel1_Paint(object sender, PaintEventArgs e)
//        {

//            /**************************
//             using (Brush b = new SolidBrush(Color.FromArgb(80, Color.White)))
//    {
//        e.Graphics.FillRectangle(b, this.ClientRectangle);
//    }

//             *************************/
//            Panel panel = sender as Panel;
//            Graphics g = e.Graphics;

//            // צבע רקע
//            using (SolidBrush brush = new SolidBrush(Color.LightSteelBlue))
//            {
//                g.FillRectangle(brush, panel.ClientRectangle);
//            }

//            // קו תחתון (קו שחור ברוחב 2 פיקסלים)
//            using (Pen pen = new Pen(Color.DarkSlateGray, 2))
//            {
//                g.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
//            }

//            // אפשרות: כיתוב באמצע (אם רוצים טקסט מותאם)
//            string title = "Welcome to Exam System";
//            using (Font font = new Font("Arial", 12, FontStyle.Bold))
//            using (SolidBrush textBrush = new SolidBrush(Color.White))
//            {
//                SizeF textSize = g.MeasureString(title, font);
//                PointF location = new PointF((panel.Width - textSize.Width) / 2, (panel.Height - textSize.Height) / 2);
//                g.DrawString(title, font, textBrush, location);
//            }
//        }


//        private void textBox3_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void button2_Click(object sender, EventArgs e)
//        {

//        }

//        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        //{
//        //    // תרחיש פשוט: מציג הודעה סטנדרטית
//        //    MessageBox.Show(
//        //        "To reset your password, please contact the system administrator.",
//        //        "Password Recovery",
//        //        MessageBoxButtons.OK,
//        //        MessageBoxIcon.Information
//        //    );
//        //}

//        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {

//        }




//        private void pictureBox4_Click(object sender, EventArgs e)
//        {

//        }

//        private void button1_Click_1(object sender, EventArgs e)
//        {
//            Button button1 = new Button();
//            button1.Name = "button1"; // חשוב
//            button1.Text = "X";
//            button1.Font = new Font("Arial", 10, FontStyle.Bold);
//            button1.ForeColor = Color.White;
//            button1.BackColor = Color.DarkRed;
//            button1.FlatStyle = FlatStyle.Flat;
//            button1.FlatAppearance.BorderSize = 0;
//            button1.Size = new Size(30, 30);
//            button1.Location = new Point(this.ClientSize.Width - 40, 10);
//            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
//            button1.Click += button1_Click_1;
//            this.Controls.Add(button1);
//            this.Close();
//        }

//        private void Form2_Load(object sender, EventArgs e)
//        {

//        }

//        private void button2_Click_1(object sender, EventArgs e)
//        {

//        }

//        private void textBox1_TextChanged_1(object sender, EventArgs e)
//        {
//            TextBox txt = sender as TextBox;
//            string input = txt.Text;

//            // בדיקה: שם משתמש חייב להכיל רק אותיות ומספרים (ללא רווחים, סימנים וכו׳)
//            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9]*$"))
//            {
//                txt.BackColor = Color.MistyRose;
//                ToolTip tip = new ToolTip();
//                tip.Show("Username must contain only letters and numbers.", txt, 0, -20, 2000);
//            }
//            else if (input.Length > 0 && input.Length < 4)
//            {
//                txt.BackColor = Color.LightYellow;
//            }
//            else
//            {
//                txt.BackColor = Color.White;
//            }
//        }


//        private void textBox2_TextChanged_1(object sender, EventArgs e)
//        {
//            TextBox txt = sender as TextBox;
//            string password = txt.Text;

//            bool hasLetter = System.Text.RegularExpressions.Regex.IsMatch(password, "[a-zA-Z]");
//            bool hasDigit = System.Text.RegularExpressions.Regex.IsMatch(password, "[0-9]");
//            bool hasSymbol = System.Text.RegularExpressions.Regex.IsMatch(password, "[!@#$%^&*]");

//            if (password.Length < 8 || !hasLetter || !hasDigit || !hasSymbol)
//            {
//                txt.BackColor = Color.MistyRose;
//                ToolTip tip = new ToolTip();
//                tip.Show("Password must be at least 8 characters and include letters, digits, and symbols.", txt, 0, -20, 3000);
//            }
//            else
//            {
//                txt.BackColor = Color.White;
//            }
//        }


//        private void textBox3_TextChanged_1(object sender, EventArgs e)
//        {
//            TextBox txt = sender as TextBox;
//            string id = txt.Text;

//            // בדיקה: רק ספרות ואורך של 9 תווים
//            if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d{9}$"))
//            {
//                txt.BackColor = Color.MistyRose;
//                ToolTip tip = new ToolTip();
//                tip.Show("ID must be exactly 9 digits.", txt, 0, -20, 2000);
//            }
//            else
//            {
//                txt.BackColor = Color.White;
//            }
//        }


//        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            // תרחיש פשוט: מציג הודעה סטנדרטית
//            MessageBox.Show(
//                "To reset your password, please contact the system administrator.",
//                "Password Recovery",
//                MessageBoxButtons.OK,
//                MessageBoxIcon.Information
//            );
//        }

//        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
//        {

//        }

//        private void panel2_Paint_1(object sender, PaintEventArgs e)
//        {

//        }
//    }
//}
