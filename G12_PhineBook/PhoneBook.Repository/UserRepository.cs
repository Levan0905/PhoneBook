using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository {
	public class UserRepository : RepositoryBase {
		public bool Login(string username, string password, out string responseMessage) {
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output };
			var returnParam = new SqlParameter("Return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };

			_database.ExecuteNonQuery("LoginCheckSP", CommandType.StoredProcedure,
				new SqlParameter("UserName", username),
				new SqlParameter("Password", password),
				responseMessageParam,
				returnParam
			);

			responseMessage = responseMessageParam.Value.ToString();
			return Convert.ToInt32(returnParam.Value) == 0;
		}

		public int InsertUpdate(string firstname, string lastname, string username, string password, string email, out string responseMessage) {
			return InsertUpdate(0, firstname, lastname, username, password, email, out responseMessage);
		}

		public int InsertUpdate(int id, string firstname, string lastname, string username, string password, string email, out string responseMessage) {
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 250 };
			var returnParam = new SqlParameter("Return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };

			_database.ExecuteNonQuery("InsertUpdateUserSP", CommandType.StoredProcedure,
				new SqlParameter("ID", id),
				new SqlParameter("Firstname", firstname),
				new SqlParameter("Lastname", lastname),
				new SqlParameter("UserName", username),
				new SqlParameter("Password", password),
				new SqlParameter("Email", email),
				responseMessageParam,
				returnParam
			);

			responseMessage = responseMessageParam.Value.ToString();
			return Convert.ToInt32(returnParam.Value);
		}

		public void Delete(int id) {
			//gamovidzaxot shesabamisi proceduarb bazashi rom chaamatos shesabamisi chanaweri
		}
	}
}
