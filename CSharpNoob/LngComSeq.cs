using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
    class LngComSeq
    {
        public static int lcs(String str1, String str2)
        {
            int[,] tbl;
            int m = str1.Length;
            int n = str2.Length;
            char[] test;
            test = new char[m];
            tbl = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        //if either string is length 0, then lcs is automatically 0
                        tbl[i,j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        tbl[i, j] = 1 + tbl[i - 1, j - 1];
                        test[tbl[i, j] - 1] = str1[i-1];
                    }
                    else
                    {
                        tbl[i, j] = Math.Max(tbl[i - 1, j], tbl[i, j - 1]);
                    }
                }
            }
            string test2 = new string(test);
            System.Console.WriteLine("The longest common subsequence string is " + test2);
                return tbl[m, n];
        }
    }
}
