using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBook.Repository {
	public class ContactRepository : RepositoryBase {
		
        public int AssignGroup(int contactID, int groupID, out string responseMessage) {
			return AssignGroup(contactID, groupID, out responseMessage, true);
		}

		public int UnAssignGroup(int contactID, int groupID, out string responseMessage) {
			return AssignGroup(contactID, groupID, out responseMessage, false);
		}

		private int AssignGroup(int contactID, int groupID, out string responseMessage, bool assign) {
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 250 };
			var returnParam = new SqlParameter("Return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };

			_database.ExecuteNonQuery(assign ? "AssignGroupSP" : "UnAssignGroupSP", CommandType.StoredProcedure,
					new SqlParameter("ContactID", contactID),
					new SqlParameter("GroupID", groupID),
					responseMessageParam,
					returnParam
			);

			responseMessage = responseMessageParam.Value.ToString();
			return Convert.ToInt32(returnParam.Value);
		}
	}
}
