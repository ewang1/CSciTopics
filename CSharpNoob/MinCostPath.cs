using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
    class MinCostPath
    {
        public static int minCostPath(int[,] cost, int x, int y) {
            int[,] tc;
            tc = new int[x+1, y+1];
            tc[0, 0] = cost[0, 0];

            for (int i = 1; i <= x; i++)
            {
                tc[i, 0] = tc[i - 1, 0] + cost[i, 0];
            }

            for (int j = 1; j <= y; j++)
            {
                tc[0, j] = tc[0, j - 1] + cost[0, j];
            }

            for (int m = 1; m <= x; m++)
            {
                for (int n = 1; n <= y; n++)
                {
                    int min1 = Math.Min(tc[m - 1, n], tc[m, n - 1]);
                    tc[m, n] = Math.Min(min1, tc[m - 1, n - 1]) + cost[m, n];
                }
            }

                return tc[x, y];
        }

        public bool numMatch(int[] x, int[] y)
        {
            //attempts to figure this out by counting the number of matches
            //if the number of matches is equal to 'y', 
            //that means all of 'y' found a match
            int match = 0;
            for (int i = 0; i < y.Length; i++) {

                for (int j = 0; j < x.Length; j++) {
                    //found a match, add a count
                    //and move to the next number to check on 'y'
                    if (y[i] == x[j]) {
                        match++;
                        break;
                    }
                }
                //ran into a case where a number in y didn't get a match
                if (match < i) {
                    return false;
                }
            }
            //if it made it this far, then all numbers had a match
            return true;
        }
    }
}
