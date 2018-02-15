using System;
using PhoneBook.Repository;
using System.Drawing;
using System.IO;
using PhoneBook.Service;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyDatabase;

namespace PhoneBook.Tester {
	public class Program {
		static void Main(string[] args) {
			Database db = new Database();
			//var table = db.GetTable("select * from Contacts");




			string response;
			int result;
			#region UserActionTest
			UserService user = new UserService();
			result=user.Login("test0123", "atu12345", out response);
			//result = user.Insert("admin", "admin", "admin124", "tester1234", "tester123@gmail.com", out response);
			//result = user.Update(35, "test", "test123", "tester101515001", "tester1234", "tester123@gmail.com", out response);
			//result = user.Delete(29,out response);
			//var tb = user.Search("user1", out response);

			//if(tb.Rows.Count == 0) {
			//	Console.WriteLine("Not found");
			//}
			#endregion

			#region ContactTest
			//      DateTime date = new DateTime(2010, 7, 14);
			//      FileStream fs = new FileStream(@"D:\northwnd.png", FileMode.Open, FileAccess.Read);
			//      BinaryReader binaryrd = new BinaryReader(fs);
			//      byte[] image = binaryrd.ReadBytes((int)fs.Length);
			//      image = File.ReadAllBytes(@"D:\northwnd.png");

			//      ContactService contact = new ContactService();
			//result=contact.Insert("ika", "atu", date, image, "megobari", 54,out response);
			//result = contact.Update(11, "nika", "feradze", date, image, "megobari", 27, out response);
			//result = contact.Delete(11, out response);
			//result = contact.AssignGroup(10, 5, out response);
			//result = contact.UnAssignGroup(10, 5, out response);

			#endregion
			//if (result == 0)
			//{
			//    Console.WriteLine(response);
			//}
			//else
			//{
			Console.WriteLine(response);
			Console.WriteLine(result);
			//}
			Console.ReadKey();
		}
	}
}
