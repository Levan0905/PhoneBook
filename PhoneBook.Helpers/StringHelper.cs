using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.Helpers {
	public static class StringHelper {
		private static bool _invalidEmail = false;

		public static bool IsValidEmail(this string str) {
			_invalidEmail = false;
			if(string.IsNullOrEmpty(str))
				return false;
			try {
				str = Regex.Replace(str, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
			} catch(RegexMatchTimeoutException) {

				return false;
			}

			if(_invalidEmail) {
				return false;
			}
			try {
				return Regex.IsMatch(str,
						 @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
						 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

			} catch(RegexMatchTimeoutException) {
				return false;
			}
		}

		private static string DomainMapper(Match match) {
			IdnMapping idn = new IdnMapping();
			string domainame = match.Groups[2].Value;
			try {
				domainame = idn.GetAscii(domainame);
			} catch(ArgumentException) {
				_invalidEmail = true;
			}
			return match.Groups[1].Value + domainame;
		}
	}
}
