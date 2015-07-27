using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	 class DynProgramming
	 {
		  public static int getMinSteps(int n)
		  {
				int[] dp;
				dp = new int[n + 1];
				dp[1] = 0;

				for (int i = 2; i <= n; i++)
				{
					 dp[i] = 1 + dp[i - 1];
					 if (i % 2 == 0)
					 {
						  dp[i] = Math.Min(dp[i], 1 + dp[i / 2]);
					 }
					 if (i % 3 == 0)
					 {
						  dp[i] = Math.Min(dp[i], 1 + dp[i / 3]);
					 }
				}

				return dp[n];
		  }

		  public static int knapsack(int max_wt, int[] wt, int[] val, int n)
		  {
				int[,] maxval;
				maxval = new int[n + 1, max_wt + 1];

				if (n == 0 || max_wt == 0) {
					 return 0;
				}
				for (int i = 0; i <= n; i++) {
					 for (int j = 0; j <= max_wt; j++) {
						  if (i == 0 || j == 0) {
								maxval[i, j] = 0;
						  }
						  else if (wt[i - 1] <= j) {
								maxval[i, j] = Math.Max(val[i - 1] + maxval[i - 1, j - wt[i - 1]], maxval[i - 1, j]);
						  }
						  else {
								maxval[i, j] = maxval[i - 1, j];
						  }
					 }
				}
				return maxval[n, max_wt];
		  }

		  public static int lis(int[] list1)
		  {
				int[] maxlen;
				int maxval = 0;
				maxlen = new int[list1.Length];

				for (int m = 0; m < list1.Length; m++) {
					 maxlen.SetValue(1, m);
				}
				for (int i = 1; i < list1.Length; i++) {
					 for (int j = 0; j < i; j++) {
						  if (list1[i] > list1[j] && maxlen[i] < maxlen[j] + 1) {
								maxlen[i] = maxlen[j] + 1;
						  }
					 }
				}
				for (int x = 0; x < maxlen.Length; x++) {
					 if (maxval < maxlen[x]) {
						  maxval = maxlen[x];
					 }
				}
				System.Console.WriteLine("The length of the longest increasing sequence for the given array is " + maxval);
				return maxval;
		  }
	 }
}
