using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	/*	Given problem:	Given 2 input strings, 1 being the input, the other being pattern
	*	return true if the input matches the pattern
	*	return false else-wise.
	*	'*' character, which means 0 - 'n' instances of the previous character, e.g. 
	*	"a*" can be "", or "aaaaaaaaaaaaaaaaaa".
	*	'.' character, which is essentially a wild card, which means any 1 character is acceptable
	*	
	*
		input:	aaabbbccc	pattern:	a.bbc*

		Ending Condition:
			- If we manage to traverse through all the pattern characters before running out of input characters
				return true
			- If we go through all the input characters before traversing through the pattern characters
				return false


	*/

	class StringPattern
	{
		public static bool RegMatch(string input, string pattern)
		{
			bool result = false;
			for (int i = 0; i < input.Length; i++)
			{
				//tmp variable to traverse through in the inner-loop
				int tmp = i;
				for (int j = 0; j < pattern.Length; j++)
				{
					//ending condition:  we traversed through the input string via 'tmp' before
					//completely traversing through the pattern string
					if (tmp >= input.Length)
					{
						return false;
					}

					//Scenario #1:  '*' case where 0-n instances are ok.
					if (j + 1 < pattern.Length && pattern[j+1] == '*')
					{
						//make sure our traversal of input loop doesn't go out of bound
						while (input[tmp] == pattern[j] && tmp < input.Length - 1)
						{
							tmp++;
						}
						result = true;
						j++;
					} //Scenario #2:  Single character match
					else if (pattern[j] == '.' || input[tmp] == pattern[j])
					{
						tmp++;
						result = true;
					}  //Scenario #3:	No match, reset pattern string's starting point
					else
					{
						result = false;
						break;
					}
					
				}
				//ending condition:	we traversed through pattern string before the input string
				//so return true;
				if (result) return result;
			}
			return result;
		}
		public static void testMatch()
		{
			if (RegMatch("aaa", "a"))
			{
				System.Console.WriteLine("Pattern matched!");
			}
			else
			{
				System.Console.WriteLine("Pattern did not match!");
			}
			if (RegMatch("aaa", "a*"))
			{
				System.Console.WriteLine("Pattern matched!");
			}
			else
			{
				System.Console.WriteLine("Pattern did not match!");
			}
			if (RegMatch("aaa", "b*."))
			{
				System.Console.WriteLine("Pattern matched!");
			}
			else
			{
				System.Console.WriteLine("Pattern did not match!");
			}
			if (RegMatch("aaa", "ab"))
			{
				System.Console.WriteLine("Pattern matched!");
			}
			else
			{
				System.Console.WriteLine("Pattern did not match!");
			}
			if (RegMatch("aaa", "a."))
			{
				System.Console.WriteLine("Pattern matched!");
			}
			else
			{
				System.Console.WriteLine("Pattern did not match!");
			}


		}
	}
}
