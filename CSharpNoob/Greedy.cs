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
    *   Find the quickest way for an integer 'n' to get to 0 using as few steps as possible in.
    */
    class Greedy
    {
        public static int findMinSteps(int n)
        {
            int x = 0;
            if (n <= 1)
            {
                return 0;
            }
            if (n % 3 == 0)
            {
                x = 1 + findMinSteps(n / 3);
            }
            else if (n % 2 == 0)
            {
                x = 1 + findMinSteps(n / 2);
            }
            else
            {
                x = 1 + findMinSteps(n - 1);
            }

            return x;
        }
    }
}
