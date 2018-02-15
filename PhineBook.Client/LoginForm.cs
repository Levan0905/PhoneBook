using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneBook.Service;

namespace PhineBook.Client {
	public partial class LoginForm : Form {
		public LoginForm() {
			InitializeComponent();
		}

        private void btn_singup_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm rf = new RegistrationForm();
            rf.Show();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            UserService user = new UserService();
            user.username = txb_Username.Text;
            user.password = txb_Passwd.Text;

            var login=user.Login(user.username, user.password, out string response);

            if (login>1)
            {
                this.Hide();
                MainForm mn = new MainForm();
                mn.Show();
            }
            else 
            {
                MessageBox.Show("Please enter correct username or password!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}