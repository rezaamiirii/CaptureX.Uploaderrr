using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureX.Uploader
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AdminUser == UsernameTextBox.Text && Properties.Settings.Default.AdminPassword == PasswordTextBox.Text)
            {
                MainForm mainForm = new MainForm();
                mainForm.Closed += MainForm_Closed;
                mainForm.ShowDialog();
                this.Hide();

            }
        }
        private void MainForm_Closed(object sender, EventArgs e)
        {
            // Close the login form when the main form is closed
            this.Close();
        }
    }
}
