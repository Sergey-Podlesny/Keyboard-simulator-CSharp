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

namespace kursaCH
{
    public partial class RegistrationForm : Form
    {
        Point moveStart;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void regButton_Click(object sender, EventArgs e)
        {
            if(loginBox.Text.Length != 0 && passwordBox.Text.Length != 0)
            {
                DataBase.SetCommandString($"SELECT login FROM users WHERE login = '{loginBox.Text}'");
                bool readerHasRows = false;
                using (MySqlDataReader reader = DataBase.Select())
                {
                    if(reader.HasRows)
                    {
                        readerHasRows = true;
                        MessageBox.Show("This login already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(!readerHasRows)
                {
                    DataBase.SetCommandString($"INSERT INTO users (login, password) VALUES ('{loginBox.Text}', '{passwordBox.Text}')");
                    DataBase.Execute();
                    Hide();
                    StartForm form = new StartForm();
                    form.Show();
                }
            }
            ProcessingOfError(loginBox, loginError, "Too short login.");
            ProcessingOfError(passwordBox, passwordError, "Too short password.");
        }


        private void ProcessingOfError(TextBox box, ErrorProvider error, string massage)
        {
            if (box.Text.Length == 0)
            {
                error.SetError(box, massage);
            }
            else
            {
                error.Clear();
            }
        }


        private void RegistrationForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void RegistrationForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point delta = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                Location = new Point(Location.X + delta.X, Location.Y + delta.Y);
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
            StartForm form = new StartForm();
            form.Show();
        }

    }
}
