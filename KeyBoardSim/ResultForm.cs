using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursaCH
{
    public partial class ResultForm : Form
    {
        Point moveStart;
        public string Login { get; set; }
        public ResultForm(string time, string mist, int curSpeed, int overSpeed)
        {
            InitializeComponent();
            timeLable.Text = time;
            mistLable.Text = mist;
            curAvSpeedLable.Text = curSpeed.ToString();
            overAvSpeedLable.Text = overSpeed.ToString();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

            InfoForm infoForm = new InfoForm();
            this.Hide();
            infoForm.Login = Login;
            infoForm.Show();
        }


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
        private void сloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
