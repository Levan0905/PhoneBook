using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository {
	public class UserRepository : RepositoryBase {
		public int Login(string username, string password, out string responseMessage) {
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 250 };
			var returnParam = new SqlParameter("Return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
			_database.ExecuteNonQuery("LoginCheckSP", CommandType.StoredProcedure,
					new SqlParameter("UserName", username),
					new SqlParameter("Password", password),
					responseMessageParam,
					returnParam
			);
			responseMessage = responseMessageParam.Value.ToString();
			return Convert.ToInt32(returnParam.Value);
		}
	}
}
