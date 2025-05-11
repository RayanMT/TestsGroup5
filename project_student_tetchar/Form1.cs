using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace project_student_tetchar.Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
      
        }

        
        bool isPasswordHidden = true;
        /******************************/
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
            btnTogglePassword.Text = textBox2.UseSystemPasswordChar ? "👁" : "🙈";
        }

        /******************************/
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    Panel panelPassword = new Panel
        //    {
        //        Location = textBox2.Location,
        //        Size = new Size(textBox2.Width + 40, textBox2.Height),
        //        BackColor = Color.White
        //    };

        //    // כאן תוסיף:
        //    this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    this.MaximizeBox = true;
        //    this.MinimizeBox = true;
        //    this.ControlBox = true;
        //    textBox2.UseSystemPasswordChar = true;

        //    // כפתור הצגת/הסתרת סיסמה
        //    Button btnTogglePassword = new Button
        //    {
        //        Text = "👁",
        //        Location = new Point(panelPassword.Width - 45, 0),
        //        Size = new Size(40, panelPassword.Height),
        //        FlatStyle = FlatStyle.Flat,
        //        BackColor = Color.LightGray,
        //        Cursor = Cursors.Hand
        //    };
        //    btnTogglePassword.FlatAppearance.BorderSize = 0;

        //    // אירוע לחיצה לכפתור
        //    btnTogglePassword.Click += (s, ev) =>
        //    {
        //        isPasswordHidden = !isPasswordHidden;
        //        textBox2.UseSystemPasswordChar = isPasswordHidden;
        //        btnTogglePassword.Text = isPasswordHidden ? "👁" : "🙈";
        //    };

        //    panelPassword.Controls.Add(btnTogglePassword);
        //    this.Controls.Add(panelPassword);

        //}

       private void Form1_Load(object sender, EventArgs e)
        {

            // כאן תוסיף:
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ControlBox = true;
            textBox2.UseSystemPasswordChar = true;

            // כפתור הצגת/הסתרת סיסמה
            Button btnTogglePassword = new Button
            {
                Text = "👁",
                Location = new Point(textBox2.Right + 10, textBox2.Top),
                Size = new Size(30, textBox2.Height),
                BackColor = Color.LightGray
            };
            this.Controls.Add(btnTogglePassword);

            // אירוע לחיצה על הכפתור
            btnTogglePassword.Click += (s, ev) =>
            {
                isPasswordHidden = !isPasswordHidden;
                textBox2.UseSystemPasswordChar = isPasswordHidden;
                btnTogglePassword.Text = isPasswordHidden ? "👁" : "🙈";
            };

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //TextBox txt = sender as TextBox;
            //string input = txt.Text.Trim();

            //// אם השדה ריק
            //if (string.IsNullOrEmpty(input))
            //{
            //    txt.BackColor = Color.LightGray;
            //    ToolTip tip = new ToolTip();
            //    tip.Show("Username is required.", txt, 0, -20, 2000);
            //    return;
            //}

            //// בדיקה: רק אותיות באנגלית ומספרים (ללא רווחים או תווים מיוחדים)
            //if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
            //{
            //    txt.BackColor = Color.MistyRose;
            //    ToolTip tip = new ToolTip();
            //    tip.Show("Username must contain only letters and numbers.", txt, 0, -20, 2000);
            //}
            //else if (input.Length < 4)
            //{
            //    txt.BackColor = Color.LightYellow;
            //    ToolTip tip = new ToolTip();
            //    tip.Show("Username should be at least 4 characters.", txt, 0, -20, 2000);
            //}
            //else
            //{
            //    txt.BackColor = Color.White; // תקין
            //}
            TextBox txt = sender as TextBox;
            string input = txt.Text.Trim();

            // נבדוק אם השדה ריק
            if (string.IsNullOrWhiteSpace(input))
            {
                txt.BackColor = Color.MistyRose;
                ToolTip tip = new ToolTip();
                tip.Show("נא למלא שם משתמש.", txt, 0, -20, 2000);
            }
            else if (input.Length < 2)
            {
                txt.BackColor = Color.LightYellow;
                ToolTip tip = new ToolTip();
                //tip.Show("שם המשתמש קצר מדי.", txt, 0, -20, 2000);
            }
            // נבדוק שאין תווים אסורים (רק אותיות מכל שפה ומספרים מותרים)
            else if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[\p{L}\p{N}]+$"))
            {
                txt.BackColor = Color.MistyRose;
                ToolTip tip = new ToolTip();
                tip.Show("שם המשתמש יכול להכיל רק אותיות ומספרים.", txt, 0, -20, 2000);
            }
            else
            {
                txt.BackColor = Color.White; // השדה תקין
            }

        }


        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = sender as TextBox;
        //    string password = txt.Text;

        //    // תנאי 1: אורך מינימלי
        //    if (password.Length < 6)
        //    {
        //        txt.BackColor = Color.MistyRose;
        //        ToolTip tip = new ToolTip();
        //        tip.Show("Password must be at least 6 characters.", txt, 0, -20, 2000);
        //        return;
        //    }

        //    // תנאי 2: לפחות אות קטנה, אות גדולה, וספרה
        //    bool hasLower = password.Any(char.IsLower);
        //    bool hasUpper = password.Any(char.IsUpper);
        //    bool hasDigit = password.Any(char.IsDigit);

        //    if (!hasLower || !hasUpper || !hasDigit)
        //    {
        //        txt.BackColor = Color.MistyRose;
        //        ToolTip tip = new ToolTip();
        //        tip.Show("Password must include a lowercase letter, an uppercase letter, and a digit.", txt, 0, -20, 2500);
        //    }
        //    else
        //    {
        //        txt.BackColor = Color.White; // ✅ סיסמה תקינה – רקע לבן
        //    }
        //}
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // רק נבדוק אם הסיסמה ריקה
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.MistyRose;
            }
            else
            {
                txt.BackColor = Color.White;
            }
        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            string input = txt.Text.Trim().ToLower();

            // נבדוק אם המשתמש הקליד בדיוק "student" או "teacher"
            if (input != "student" && input != "teacher")
            {
                txt.BackColor = Color.MistyRose;

                ToolTip tip = new ToolTip();
                tip.Show("User type must be either 'student' or 'teacher' (in English)", txt, 0, -20, 2500);
            }
            else
            {
                txt.BackColor = Color.White;
            }
        }




        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{

        //    Form regForm = new Form
        //    {
        //        Text = "Create New Account",
        //        Size = new Size(400, 500),
        //        StartPosition = FormStartPosition.CenterScreen
        //    };

        //    // שדות
        //    Label lblUser = new Label { Text = "Username", Location = new Point(20, 20) };
        //    TextBox txtUser = new TextBox { Location = new Point(20, 40), Width = 330 };
        //    //

        //    Label lblId = new Label { Text = "ID", Location = new Point(20, 70) };
        //    TextBox txtId = new TextBox { Location = new Point(20, 90), Width = 330 };

        //    Label lblEmail = new Label { Text = "Email (@gmail.com)", Location = new Point(20, 120) };
        //    TextBox txtEmail = new TextBox { Location = new Point(20, 140), Width = 330 };

        //    Label lblPass = new Label { Text = "Password", Location = new Point(20, 170) };
        //    TextBox txtPass = new TextBox { Location = new Point(20, 190), Width = 330 };

        //    Label lblRole = new Label { Text = "User Type", Location = new Point(20, 220) };
        //    RadioButton rbStudent = new RadioButton { Text = "Student", Checked = true, Location = new Point(20, 240) };
        //    RadioButton rbTeacher = new RadioButton { Text = "Teacher", Location = new Point(120, 240) };

        //    Button btnRegister = new Button
        //    {
        //        Text = "New Account",
        //        Location = new Point(20, 290),
        //        Width = 330
        //    };

        //    // 🟡 בדיקה תוך כדי הקלדה: סיסמה חזקה עם צבע אדום
        //    txtPass.TextChanged += (s, ev) =>
        //    {
        //        string password = txtPass.Text;
        //        bool hasLower = password.Any(char.IsLower);
        //        bool hasUpper = password.Any(char.IsUpper);
        //        bool hasDigit = password.Any(char.IsDigit);

        //        if (password.Length < 6 || !hasLower || !hasUpper || !hasDigit)
        //        {
        //            txtPass.BackColor = Color.MistyRose;
        //            ToolTip tip = new ToolTip();
        //            tip.Show("Password must include lowercase, uppercase and digit (min 6 characters)", txtPass, 0, -20, 2500);
        //        }
        //        else
        //        {
        //            txtPass.BackColor = Color.White;
        //        }
        //    };

        //    btnRegister.Click += (s, ev) =>
        //    {
        //        string username = txtUser.Text.Trim();
        //        string password = txtPass.Text;
        //        string email = txtEmail.Text.Trim();
        //        string id = txtId.Text.Trim();
        //        string type = rbStudent.Checked ? "student" : "teacher";

        //        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
        //            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(id))
        //        {
        //            MessageBox.Show("Please fill in all fields.");
        //            return;
        //        }

        //        if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d{9}$"))
        //        {
        //            txtId.BackColor = Color.MistyRose;
        //            MessageBox.Show("ID must be exactly 9 digits.");
        //            return;
        //        }

        //        if (!email.EndsWith("@gmail.com"))
        //        {
        //            txtEmail.BackColor = Color.MistyRose;
        //            MessageBox.Show("Email must end with @gmail.com");
        //            return;
        //        }

        //        bool hasLower = password.Any(char.IsLower);
        //        bool hasUpper = password.Any(char.IsUpper);
        //        bool hasDigit = password.Any(char.IsDigit);

        //        if (password.Length < 6 || !hasLower || !hasUpper || !hasDigit)
        //        {
        //            txtPass.BackColor = Color.MistyRose;
        //            MessageBox.Show("Password must be at least 6 characters and include lowercase, uppercase and digit.");
        //            return;
        //        }

        //        string excelPath = @"C:\Users\saied\OneDrive - ac.sce.ac.il\Desktop\מסך התחברות\project_student_tetchar\project_student_tetchar\bin\Debug\UsersDB.xlsx";
        //        string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelPath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

        //        try
        //        {
        //            using (OleDbConnection conn = new OleDbConnection(connectionString))
        //            {
        //                conn.Open();

        //                // בדיקות כפילויות לפי ID, Email, Username
        //                foreach (string field in new[] { "ID", "Email", "Username" })
        //                {
        //                    string checkQuery = $"SELECT * FROM [Users$] WHERE {field} = ?";
        //                    OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn);
        //                    checkCmd.Parameters.AddWithValue("?", field == "ID" ? id : field == "Email" ? email : username);
        //                    using (OleDbDataReader reader = checkCmd.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            MessageBox.Show($"This {field} already exists.");
        //                            return;
        //                        }
        //                    }
        //                }

        //                string insert = "INSERT INTO [Users$] ([Username], [Password], [ID], [Email], [UserType]) VALUES (?, ?, ?, ?, ?)";
        //                OleDbCommand cmd = new OleDbCommand(insert, conn);
        //                cmd.Parameters.AddWithValue("?", username);
        //                cmd.Parameters.AddWithValue("?", password);
        //                cmd.Parameters.AddWithValue("?", id);
        //                cmd.Parameters.AddWithValue("?", email);
        //                cmd.Parameters.AddWithValue("?", type);
        //                cmd.ExecuteNonQuery();

        //                MessageBox.Show("Account created successfully!");
        //                regForm.Close();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Database error:\n" + ex.Message);
        //        }
        //    };

        //    regForm.Controls.AddRange(new Control[]
        //    {
        //lblUser, txtUser,
        //lblId, txtId,
        //lblPass, txtPass,
        //lblEmail, txtEmail,
        //lblRole, rbStudent, rbTeacher,
        //btnRegister
        //    });

        //    regForm.ShowDialog();
        //}
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form regForm = new Form
            {
                Text = "Create New Account",
                Size = new Size(400, 500),
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblUser = new Label { Text = "Username", Location = new Point(20, 20) };
            TextBox txtUser = new TextBox { Location = new Point(20, 40), Width = 330 };

            Label lblId = new Label { Text = "ID (9 digits)", Location = new Point(20, 70) };
            TextBox txtId = new TextBox { Location = new Point(20, 90), Width = 330 };

            Label lblEmail = new Label { Text = "Email (@gmail.com)", Location = new Point(20, 120) };
            TextBox txtEmail = new TextBox { Location = new Point(20, 140), Width = 330 };

            Label lblPass = new Label { Text = "Password", Location = new Point(20, 170) };
            TextBox txtPass = new TextBox { Location = new Point(20, 190), Width = 330 };

            Label lblRole = new Label { Text = "User Type", Location = new Point(20, 220) };
            RadioButton rbStudent = new RadioButton { Text = "Student", Checked = true, Location = new Point(20, 240) };
            RadioButton rbTeacher = new RadioButton { Text = "Teacher", Location = new Point(120, 240) };

            Button btnRegister = new Button
            {
                Text = "New Account",
                Location = new Point(20, 290),
                Width = 330
            };

            txtPass.TextChanged += (s, ev) =>
            {
                string password = txtPass.Text;
                bool hasLower = password.Any(char.IsLower);
                bool hasUpper = password.Any(char.IsUpper);
                bool hasDigit = password.Any(char.IsDigit);

                if (password.Length < 6 || !hasLower || !hasUpper || !hasDigit)
                {
                    txtPass.BackColor = Color.MistyRose;
                    new ToolTip().Show("Password must include lowercase, uppercase and digit (min 6 characters)", txtPass, 0, -20, 2500);
                }
                else
                {
                    txtPass.BackColor = Color.White;
                }
            };

            btnRegister.Click += (s, ev) =>
            {
                string username = txtUser.Text.Trim();
                string password = txtPass.Text;
                string email = txtEmail.Text.Trim();
                string id = txtId.Text.Trim();
                string type = rbStudent.Checked ? "student" : "teacher";

                // ✅ Validation: All fields required
                if (string.IsNullOrEmpty(username))
                {
                    txtUser.BackColor = Color.MistyRose;
                    MessageBox.Show("Username is required.");
                    return;
                }
                else
                {
                    txtUser.BackColor = Color.White;
                }

                if (string.IsNullOrEmpty(password))
                {
                    txtPass.BackColor = Color.MistyRose;
                    MessageBox.Show("Password is required.");
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    txtEmail.BackColor = Color.MistyRose;
                    MessageBox.Show("Email is required.");
                    return;
                }

                if (string.IsNullOrEmpty(id))
                {
                    txtId.BackColor = Color.MistyRose;
                    MessageBox.Show("ID is required.");
                    return;
                }

                // ✅ Validation: ID must be exactly 9 digits
                if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d{9}$"))
                {
                    txtId.BackColor = Color.MistyRose;
                    MessageBox.Show("ID must be exactly 9 digits.");
                    return;
                }
                else
                {
                    txtId.BackColor = Color.White;
                }

                // ✅ Validation: Email pattern (starts with a letter, only letters and digits before @gmail.com)
                string emailPattern = @"^[A-Za-z][A-Za-z0-9]*@gmail\.com$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
                {
                    txtEmail.BackColor = Color.MistyRose;
                    MessageBox.Show("Email must start with a letter and contain only letters and digits before '@gmail.com'.");
                    return;
                }
                else
                {
                    txtEmail.BackColor = Color.White;
                }

                // ✅ Validation: Password rules
                bool hasLower = password.Any(char.IsLower);
                bool hasUpper = password.Any(char.IsUpper);
                bool hasDigit = password.Any(char.IsDigit);

                if (password.Length < 6 || !hasLower || !hasUpper || !hasDigit)
                {
                    txtPass.BackColor = Color.MistyRose;
                    MessageBox.Show("Password must be at least 6 characters and include lowercase, uppercase, and a digit.");
                    return;
                }
                else
                {
                    txtPass.BackColor = Color.White;
                }

                // ✅ Check Excel for duplicates and insert new record
                string excelPath = @"C:\Users\saied\OneDrive - ac.sce.ac.il\Desktop\מסך התחברות\project_student_tetchar\project_student_tetchar\bin\Debug\UsersDB.xlsx";
                string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelPath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();

                        foreach (string field in new[] { "ID", "Email", "Username" })
                        {
                            string checkQuery = $"SELECT * FROM [Users$] WHERE {field} = ?";
                            using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("?", field == "ID" ? id : field == "Email" ? email : username);
                                using (OleDbDataReader reader = checkCmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        MessageBox.Show($"This {field} already exists.");
                                        return;
                                    }
                                }
                            }
                        }

                        string insert = "INSERT INTO [Users$] ([Username], [Password], [ID], [Email], [UserType]) VALUES (?, ?, ?, ?, ?)";
                        using (OleDbCommand cmd = new OleDbCommand(insert, conn))
                        {
                            cmd.Parameters.AddWithValue("?", username);
                            cmd.Parameters.AddWithValue("?", password);
                            cmd.Parameters.AddWithValue("?", id);
                            cmd.Parameters.AddWithValue("?", email);
                            cmd.Parameters.AddWithValue("?", type);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Account created successfully!");
                        regForm.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error:\n" + ex.Message);
                }
            };

            regForm.Controls.AddRange(new Control[]
            {
        lblUser, txtUser,
        lblId, txtId,
        lblPass, txtPass,
        lblEmail, txtEmail,
        lblRole, rbStudent, rbTeacher,
        btnRegister
            });

            regForm.ShowDialog();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string role = comboBoxUserType.SelectedItem != null ? comboBoxUserType.SelectedItem.ToString() : "";

            bool isValid = true;

            // בדיקת שדה שם משתמש
            if (string.IsNullOrEmpty(username))
            {
                textBox1.BackColor = Color.MistyRose;
                isValid = false;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }

            // בדיקת שדה סיסמה
            if (string.IsNullOrEmpty(password))
            {
                textBox2.BackColor = Color.MistyRose;
                isValid = false;
            }
            else
            {
                textBox2.BackColor = Color.White;
            }

            // בדיקת תפקיד
            if (string.IsNullOrEmpty(role))
            {
                comboBoxUserType.BackColor = Color.MistyRose;
                isValid = false;
            }
            else
            {
                comboBoxUserType.BackColor = Color.White;
            }

            if (!isValid)
            {
                MessageBox.Show("יש למלא את כל השדות החובה!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // המשך תהליך ההתחברות הרגיל
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=UsersDB.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM [Users$] WHERE Username = ? AND Password = ? AND UserType = ?";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);
                    cmd.Parameters.AddWithValue("?", role);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            this.Hide();
                            if (role == "student")
                            {
                                StudentMainForm smf = new StudentMainForm();
                                smf.FormClosed += (s2, ev2) => this.Close();
                                smf.Show();
                            }
                            else
                            {
                                TeacherForm tf = new TeacherForm();
                                tf.FormClosed += (s2, ev2) => this.Close();
                                tf.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("פרטי ההתחברות שגויים. נסה שוב.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעת התחברות: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
