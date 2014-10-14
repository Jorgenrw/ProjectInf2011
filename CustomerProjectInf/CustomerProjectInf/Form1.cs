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
            this.passwordTextbox.KeyPress += new KeyPressEventHandler(Keypressed);
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
        public string getUsername()
        {
            return username;
        }
        private void Keypressed(object sender, KeyPressEventArgs key)
        {
            if (key.KeyChar == (char)13)
            {
                loginButton_Click(sender, key);
            }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkLogin(username, password) == true)
            {
                //adminForm newForm = new adminForm(usernameTextbox.Text);
                adminForm newForm = new adminForm();
                this.Visible = false;
                newForm.Show();
                
            }
            else
            {
                passwordTextbox.Clear();
                passwordTextbox.Focus();
                loginALabel.Visible = true;
            }
        }
    }
}
