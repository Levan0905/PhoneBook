using PhoneBook.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service {
	public abstract class ServiceBase<TRepository> where TRepository : RepositoryBase, new() {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        protected readonly TRepository _repository;

		public ServiceBase() {
			_repository = new TRepository();
		}

		public virtual DataTable Search(string text, out string responseMessage) {
			return _repository.Search(text, out responseMessage);
		}
		
		public virtual int Delete(int id, out string responseMessage) {
			return _repository.Delete(id, out responseMessage);
		}
	}
}
