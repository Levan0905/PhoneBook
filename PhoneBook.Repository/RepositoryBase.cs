using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDatabase;
using System.Data.SqlClient;
using System.Data;

namespace PhoneBook.Repository {
	public abstract class RepositoryBase {
        protected Database _database;

		protected string ObjectName {
			get {
				return this.GetType().Name.Replace("Repository", "");
			}
		}

		public RepositoryBase() {
			_database = new Database();
		}

		public virtual DataTable Search(string text, out string responseMessage) {
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 250 };
			var returnParam = new SqlParameter("Return", SqlDbType.NVarChar) { Direction = ParameterDirection.ReturnValue };

			var table = _database.GetTable(
							$"SearchSP",
							CommandType.StoredProcedure,
							new SqlParameter("Text", text),
							responseMessageParam,
							returnParam);
			responseMessage = responseMessageParam.Value.ToString();
			return table;
		}

		public virtual int Delete(int id, out string responseMessage) {
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 250 };
			var returnParam = new SqlParameter("Return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };

			_database.ExecuteNonQuery($"Delete{ObjectName}SP", CommandType.StoredProcedure,
					new SqlParameter("ID", id),
					responseMessageParam,
					returnParam
			);

			responseMessage = responseMessageParam.Value.ToString();
			return Convert.ToInt32(returnParam.Value);
		}

		public int InsertUpdate(out string responseMessage, params SqlParameter[] parameters) {
			SqlParameter parameterid = new SqlParameter("id", 0);
			return InsertUpdate(parameterid, out responseMessage, parameters);
		}

		public int InsertUpdate(SqlParameter id, out string responseMessage, params SqlParameter[] parameters) {
			var pList = new List<SqlParameter>(parameters);
			var responseMessageParam = new SqlParameter("ResponseMessage", SqlDbType.NVarChar) { Direction = ParameterDirection.Output, Size = 250 };
			var returnParam = new SqlParameter("Return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
			pList.Add(responseMessageParam);
			pList.Add(returnParam);
			pList.Add(id);
			_database.ExecuteNonQuery($"InsertUpdate{ObjectName}SP", CommandType.StoredProcedure,
					pList.ToArray()
			);
			responseMessage = responseMessageParam.Value.ToString();
			return Convert.ToInt32(returnParam.Value);
		}

	}
}
