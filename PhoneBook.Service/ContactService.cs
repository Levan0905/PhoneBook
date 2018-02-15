using PhoneBook.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service {
	public class ContactService : ServiceBase<ContactRepository> {
		public int Update(int id, string firstname, string lastname, DateTime date, byte[] img, string note, int userid, out string response) {
			SqlParameter parameterid = new SqlParameter("ID", id);
			SqlParameter[] parameter = {
				new SqlParameter("Firstname", firstname),
				new SqlParameter("Lastname", lastname),
				new SqlParameter("BirthDay", date),
				new SqlParameter("Photo", img),
				new SqlParameter("Note", note),
				new SqlParameter("UserID", userid),
			};
			return _repository.InsertUpdate(parameterid, out response, parameter);
		}

		public int Insert(string firstname, string lastname, DateTime date, byte[] img, string note, int userid, out string response) {
			return Update(0, firstname, lastname, date, img, note, userid, out response);
		}
		
		public int AssignGroup(int contactID, int groupID, out string responseMessage) {
			return _repository.AssignGroup(contactID, groupID, out responseMessage);
		}

		public int UnAssignGroup(int contactID, int groupID, out string responseMessage) {
			return _repository.UnAssignGroup(contactID, groupID, out responseMessage);
		}
	}
}
