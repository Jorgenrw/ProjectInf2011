using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerProjectInf
{
     
    public partial class LoginScreen : Form
    {

        public LoginScreen()
        {
            InitializeComponent();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            String username = usernameTextbox.Text;
            String password = passwordTextbox.Text;

            if (username.Equals("Admin") && password.Equals("password"))
            {
                MessageBox.Show("Login Sucess");
            }
            else
            {
                passwordTextbox.Clear();
                passwordTextbox.Focus();
            }
        }
    }
}
