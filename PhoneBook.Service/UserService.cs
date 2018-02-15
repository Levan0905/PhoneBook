using System;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using PhoneBook.Helpers;
using PhoneBook.Repository;


namespace PhoneBook.Service {
	public class UserService : ServiceBase<UserRepository> {
        public event Action<string> OnLogin;
		public event Action<string> OnLoginFail;
		protected int result;

		public int Login(string username, string password, out string responseMessage) {
			result = _repository.Login(username, password, out responseMessage);
			if(result != 1 && OnLogin != null)
				OnLogin(username);
			if(result == 1 && OnLoginFail != null)
				OnLoginFail(username);
			return result;
		}

		public int Update(int id, string firstname, string lastname, string username, string password, string mail, out string response) {

			SqlParameter parameterid = new SqlParameter("id", id);
			SqlParameter[] parameter =  {
				new SqlParameter("Firstname",firstname),
				new SqlParameter("Lastname",lastname),
				new SqlParameter("Username",username),
				new SqlParameter("Password",password),
				new SqlParameter("Email",mail)
			};
			//if(mail.IsValidEmail() == true) {
				result = _repository.InsertUpdate(parameterid, out response, parameter);
			//} else {
				response = "Please  Enter Valid Email Adrres :  " + mail + " is not correct";
			//}
			return result;
		}

		public int Insert(string firstname, string lastname, string username, string password, string mail, out string response) {
			return result = Update(0, firstname, lastname, username, password, mail, out response);
		}
	}
}
