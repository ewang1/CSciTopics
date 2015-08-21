using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	class InterleaveStrings
	{
		public static List<string> AllInterleavings(string s, string t)
		{
			char[] tmp = new char[s.Length + t.Length];

			List<string> allInter = new List<string>();
			AllInterleavings(s, t, tmp, 0, 0, 0, allInter);
			return allInter;
		}

		private static void AllInterleavings(string s, string t,
					char[] curStr, int i, int s1, int s2, List<string> allInter)
		{
			if (s1 == s.Length && s2 == t.Length)
				allInter.Add(new string(curStr));
			if (s1 != s.Length)
			{
				curStr[i] = s[s1];
				AllInterleavings(s, t, curStr, i + 1, s1 + 1, s2, allInter);
			}
			if (s2 != t.Length)
			{
				curStr[i] = t[s2];
				AllInterleavings(s, t, curStr, i + 1, s1, s2 + 1, allInter);
			}
		}
	}
}
