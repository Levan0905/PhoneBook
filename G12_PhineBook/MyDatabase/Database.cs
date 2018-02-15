using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyDatabase {
	public class Database {
		public static string ConnectionString {
			get {
				return ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
			}
		}

		public SqlConnection GetConnection(string connectionString) {
			var connection = new SqlConnection(connectionString);
			return connection;
		}

		public SqlConnection GetConnection() {
			return GetConnection(ConnectionString);
		}

		public SqlCommand GetCommand(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			var command = new SqlCommand();
			command.Connection = GetConnection(connectionString);
			command.CommandType = commandType;
			command.CommandText = commandText;
			foreach(var p in parameters) {
				command.Parameters.Add(p);
			}
			return command;
		}

		public SqlCommand GetCommand(string commandText, CommandType commandType, params SqlParameter[] parameters) {
			return GetCommand(ConnectionString, commandText, commandType, parameters);
		}

		public SqlCommand GetCommand(string commandText, params SqlParameter[] parameters) {
			return GetCommand(commandText, CommandType.Text, parameters);
		}

		public int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			var command = GetCommand(connectionString, commandText, commandType, parameters);
			try {
				command.Connection.Open();
				return command.ExecuteNonQuery();
			} finally {
				command.Connection.Close();
			}
		}

		public int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters) {
			return ExecuteNonQuery(ConnectionString, commandText, commandType, parameters);
		}

		public int ExecuteNonQuery(string commandText, params SqlParameter[] parameters) {
			return ExecuteNonQuery(commandText, CommandType.Text, parameters);
		}

		public SqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			var command = GetCommand(connectionString, commandText, commandType, parameters);
			try {
				command.Connection.Open();
				return command.ExecuteReader();
			} finally {
				command.Connection.Close();
			}
		}

		public SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters) {
			return ExecuteReader(ConnectionString, commandText, commandType, parameters);
		}

		public SqlDataReader ExecuteReader(string commandText, params SqlParameter[] parameters) {
			return ExecuteReader(commandText, CommandType.Text, parameters);
		}

		public object ExecuteScalar(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			var command = GetCommand(connectionString, commandText, commandType, parameters);
			try {
				command.Connection.Open();
				return command.ExecuteScalar();
			} finally {
				command.Connection.Close();
			}
		}

		public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters) {
			return ExecuteScalar(ConnectionString, commandText, commandType, parameters);
		}

		public object ExecuteScalar(string commandText, params SqlParameter[] parameters) {
			return ExecuteScalar(commandText, CommandType.Text, parameters);
		}

		public DataTable GetTable(string connectionString, string commandText, CommandType commandType, params SqlParameter[] parameters) {
			return null;
		}

		//Todo: gavaketot igive GetTable-istvis
	}
}