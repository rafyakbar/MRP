using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMRP
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text == "marketing" && passwordTextBox.Text == "mrkt")
            {
                this.Hide();
                (new MarketingGUI(this)).ShowDialog();
            }
            else
            {
                this.Hide();
                (new MarketingGUI(this)).ShowDialog();
                //MessageBox.Show("Username atau password salah!");
            }
        }
    }
}
