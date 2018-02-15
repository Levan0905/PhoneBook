using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Repository;

namespace PhoneBook.Tester {
	class Program {
		static void Main(string[] args) {
			UserRepository userRepository = new UserRepository();
			string response;
			int result = userRepository.InsertUpdate("Goga", "Gogotchuri", "Gogotcha", "Goga123", "G.gogochuri97@gmail.com", out response);

			Console.WriteLine(response);
			Console.WriteLine(result);

			Console.ReadKey();
		}
	}
}
