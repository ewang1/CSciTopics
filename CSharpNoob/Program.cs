using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	 class Program
	 {
		  public static bool matchRegEx(String input, String pattern)
		  {
				bool match = false;
				int inputLen = input.Length;
				int patLen = pattern.Length;

				for (int i = 0; i < inputLen; i++)
				{
					 int temp = i;
					 for (int j = 0; j < patLen; j++)
					 {
						  System.Console.WriteLine("Current character of Input String is " + input[temp]);
						  if (j + 1 < patLen && pattern[j + 1] == '*')
						  {
								System.Console.WriteLine("  Found '*' character after " + input[j]);
								while (input[temp] == pattern[j] && inputLen - temp >= patLen - j)
								{
									 temp++;
									 match = true;
								}
								j++;
						  }
						  else if (input[temp] == pattern[j] || pattern[j] == '.')
						  {
								System.Console.WriteLine("  Found '.' character ");
								temp++;
								match = true;
						  }
						  else
						  {
								System.Console.WriteLine("No match at " + temp);
								match = false;
								break;
						  }
					 }
					 if (match) return match;
				}
				return match;
		  }
		  static void Main(string[] args)
		  {
				System.Console.WriteLine("Howdy\n");
			 if (CSci.Program.matchRegEx("aaacbbbb", "a.b")) {
				 System.Console.WriteLine("Regex returned true");
			 } else {
				 System.Console.WriteLine("Regex returned false");
			 }
				int y = 10;
				int x = Greedy.findMinSteps(y);
				System.Console.WriteLine("This greedy algorithm says it'll take " + x + " steps to get from " + y + " to 0");

				int[] memo  = null;
				memo = new int[y + 1];

				x = Memoization.getMinSteps(y, memo);
				System.Console.WriteLine("This memoization approach says it'll take " + x + " steps to get from " + y + " to 0");

				x = DynProgramming.getMinSteps(y);
				System.Console.WriteLine("This dynamic programming approach says it'll take " + x + " steps to get from " + y + " to 0");


				int[] val = new int[] { 50, 3, 500, 20, 7 };
				int[] wt = new int[] {10, 16, 30, 50, 4};

				/*
				maxval = LngComSeq.lcs("abcdefxztgh", "beasvbfzh");
				System.Console.WriteLine("The longest common sequence between abcdefxztgh and beasvbfzh is length " + maxval);
				*/
				/*
				int[] listest = new int[] { 7, 10, 6, 4, 17, 13, 20};
				maxval = LngIncSeq.lis(listest);
				*/

				int[,] costPath = new int[3,3] { { 1, 2, 3 }, { 4, 8, 2 }, { 1, 5, 3 } };
				for (int a = 0; a < 3; a++)
				{
					 System.Console.WriteLine("For a = " + a);
					 for (int b = 0; b < 3; b++)
					 {   
						  System.Console.Write(" " + costPath[a,b] + " ");
					 }
					 System.Console.WriteLine("");
				}
				int minval = MinCostPath.minCostPath(costPath, 2, 2);
				System.Console.WriteLine("The min value for the given MinCostPath problem is " + minval);


				BTNode test = new BTNode();
				test.TestBTNode();

				RunLenEnc.testRLE();
		  }
	 }
}
