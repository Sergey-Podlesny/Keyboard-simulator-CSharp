using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace kursaCH
{
    public partial class InfoForm : Form
    {
        int complex = -1;
        Point moveStart;
        string textInfo;
        public string Login { get; set; }
        public InfoForm()
        {
            InitializeComponent();
            using(StreamReader sr = File.OpenText("TextInfo.txt"))
            {
                textInfo = sr?.ReadToEnd() ?? "";
            }
            DataBase.SetData("keyboard_simulator", "admin", "root", "localhost", "words");
            DataBase.SetConnection();
            DataBase.OpenConnection();

        }

        private void easyRadioB_CheckedChanged(object sender, EventArgs e)
        {
            complex = 0;
            complError.Clear();
        }

        private void mediumRadioB_CheckedChanged(object sender, EventArgs e)
        {
            complex = 1;
            complError.Clear();
        }

        private void hardRadioB_CheckedChanged(object sender, EventArgs e)
        {
            complex = 2;
            complError.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (complex != -1)
            {
                DataBase.SetCommandString($"SELECT word FROM words WHERE hard = '{complex}'");
                MySqlDataReader dataReader = DataBase.Select();
                List<string> words = new List<string>();
                while(dataReader.Read())
                {
                    words.Add(dataReader.GetValue(0).ToString());
                }
                this.Hide();
                Simulator simulator = new Simulator(words);
                simulator.Login = Login;
                simulator.Show();
            }
            else
            {
                complError.SetError(hardRadioB ,"Select the complexity");
            }
        }

      

        private void InfoForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }
        private void InfoForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point delta = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                Location = new Point(Location.X + delta.X, Location.Y + delta.Y);
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textInfo, "Info", MessageBoxButtons.OK);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
