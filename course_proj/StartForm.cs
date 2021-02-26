using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace kursaCH
{
    public partial class StartForm : Form
    {
        Point moveStart;
        
        public StartForm()
        {
            InitializeComponent();
            DataBase.SetData("keyboard_simulator", "admin", "root", "localhost", "users");
            DataBase.SetConnection();
            DataBase.OpenConnection();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }


        // регестрация нажатия на кнопку Start
 
        private void logInButton_Click(object sender, EventArgs e)
        {
            if (loginBox.Text.Length != 0 && passwordBox.Text.Length != 0)
            {
                DataBase.SetCommandString($"SELECT password FROM users WHERE login = '{loginBox.Text}'");
                using (MySqlDataReader reader = DataBase.Select())
                {
                    if (reader.Read() && reader.GetValue(0).ToString() == passwordBox.Text)
                    {

                        DataBase.CloseConnection();
                        Hide();
                        InfoForm infoForm = new InfoForm();
                        infoForm.Login = loginBox.Text;
                        infoForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong login or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            ProcessingOfError(loginBox, loginError, "Too short login.");
            ProcessingOfError(passwordBox, passwordError, "Too short password.");
        }


        private void regButton_Click(object sender, EventArgs e)
        {
            Hide();
            RegistrationForm f1 = new RegistrationForm();
            f1.Show();
        }


        // обработка ошибок неполного ввода 
        private void ProcessingOfError(TextBox box ,ErrorProvider error, string massage)
        {
            if(box.Text.Length == 0)
            {
                error.SetError(box, massage);
            }
            else
            {
                error.Clear();
            }
        }


        // следующие 2 метода служат для перемещения формы
       
        // следующие 2 метода служат для перемещения формы
        private void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void StartForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point delta = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                Location = new Point(Location.X + delta.X, Location.Y + delta.Y);
            }
        }



        // регестрация завершения программы
        private void bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

