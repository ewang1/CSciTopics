using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
    /*  Given an integer 'n', 3 possible ways to move down, each way counts as a step:
     *  1. n = n - 1
     *  2. if n % 2 == 0, then n = n / 2
     *  3. if n % 3 == 0, then n = n / 3
     * 
     *   Find the minimal steps needed for an integer 'n' to get to 0.
     */
    class Memoization
    {
        public static int getMinSteps(int n, int[] memo)
        {
            int x;
            if (n <= 1)
            {
                return 0;
            }
            if (memo[n] > 0) return memo[n];

            x = 1 + getMinSteps(n - 1, memo);

            if (n % 2 == 0)
            {
                x = Math.Min(x, 1 + getMinSteps(n / 2, memo));
            }
            if (n % 3 == 0)
            {
                x = Math.Min(x, 1 + getMinSteps(n / 3, memo));
            }
            memo[n] = x;

            return x;

        }
    }
}
