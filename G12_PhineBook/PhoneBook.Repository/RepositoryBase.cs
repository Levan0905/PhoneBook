using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDatabase;

namespace PhoneBook.Repository {
	public abstract class RepositoryBase {
		protected Database _database;

		public RepositoryBase() {
			_database = new Database();
		}

		//public abstract void Load();
		//public abstract void Save();
	}
}
