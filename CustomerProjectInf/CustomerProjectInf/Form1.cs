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
     
    public partial class LoginScreenForm : Form
    {
        private String username;
        private String password;
        public LoginScreenForm()
        {
            InitializeComponent();
        }
        public Boolean checkLogin(String username, String password)
        {
            this.username = username;
            this.password = password;

            username = usernameTextbox.Text;
            password = passwordTextbox.Text;

            if (username.Equals("Admin") && password.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkLogin(username, password) == true)
            {
                adminForm newForm = new adminForm();
                this.Visible = false;
                newForm.Show();
            }
            else
            {
                passwordTextbox.Clear();
                passwordTextbox.Focus();
            }
        }
    }
}
