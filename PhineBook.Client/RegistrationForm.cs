using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneBook.Repository;
using PhoneBook.Helpers;
using PhoneBook.Service;


namespace PhineBook.Client {
	public partial class RegistrationForm : Form {
		public RegistrationForm() {
			InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            UserService user = new UserService();
            user.firstname = txb_Firstname.Text;
            user.lastname = txb_Lastname.Text;
            user.username = txb_Username.Text;
            user.password= txb_Passwd.Text;
            user.email= txb_Email.Text;

            user.Insert(user.firstname, user.lastname, user.username, user.password, user.email, out string response);
            
        }
    }
}
