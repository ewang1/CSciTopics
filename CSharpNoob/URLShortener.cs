using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	class URLShortener
	{
		/* The simplest way to think of a URL Shortener is to think of it as a base conversion
		  to either base-36 (upper case ignored) or base-62 (upper and lower case)
		  0-9 (10), a-z (26) A-Z (26)
		  with the URL id stored in the database as the number (hence why the common assumption
		  a URL database with id is usually involved).
		  The reason why it is usually assumed the URL shortener will be at most 6 char's length:
			The URL ID is assumed to be a 32-bit signed integer, which means a max of 2^31
			which rounds up to ~2.147 billion possible unique ID's
			and even in base-36 @ 6 char's ==> 36^6 will round up to ~2.17 billion
			while in base 62 @ 6 char's ==> 62^6 will round up to 56.8 billion
		
		  Most URL shorteners actually do not work on the actual long URL; they work with the 
		  URL ID and shorten it enough to be memorizable.  Since this requires an addtional 
		  lookup on the database to match the URL ID to the actual full URL, it has been noted
		  that shortened URLs have an extra delay as a performance disadvantage.
		*/
		

		public static string idToShortURL(UInt32 n)
		{
			string result = "";
			string[] map = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
							"o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
							"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
			while (n != 0)
			{
				result = result + map[n % 36];
				n = n / 36;
				//System.Console.WriteLine("Result String:" + result);
			}

			return result;

		}

		public static void testURLShortener()
		{
			System.Console.WriteLine("Printing the URL Shortender example:  " + idToShortURL(99999999));
			System.Console.WriteLine("Printing the URL Shortender example:  " + idToShortURL(19227999));
		}
	}
}
