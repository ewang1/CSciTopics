using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	class Combinations
	{
		public static UInt32 CountCombos(UInt32 set, UInt32 size)
		{
			UInt32 combos = 1;
			UInt32 subcombo = 1;
			UInt32 bigoff = Math.Max(set - size, size);
			UInt32 smalloff = Math.Min(set - size, size);
			for (UInt32 i = set; i > 0; i--)
			{
				if (i > bigoff) {
					combos = i * combos;
				}
			}
			System.Console.WriteLine("The top count is " + combos);
			for (UInt32 j = 1; j <= smalloff; j++)
			{
				subcombo = j * subcombo;
			}
			System.Console.WriteLine("The bottom count is " + subcombo);

			combos = combos / subcombo;

			return combos;
		}

		public static void PrintCombination(int[] arr, int n, int r)
		{
			int[] data = new int[r];
			ComboUtils(arr, n, r, 0, data, 0);
		}

		public static void ComboUtils(int[] arr, int n, int r, int index, int[] data, int i)
		{
			//when combination is done
			if (index == r)
			{
				for (int j = 0; j < r; j++)
				{
					System.Console.Write(data[j] + " ");
				}
				System.Console.WriteLine();
				return;
			}
			//no more elements to put into data[]
			if (i >= n)
			{
				return;
			}

			//current is included, and put next at next + 1
			//
			data[index] = arr[i];
			ComboUtils(arr, n, r, index + 1, data, i + 1);
			//current is excluded, and replace with next (note index does not change)
			ComboUtils(arr, n, r, index, data, i + 1);
		}

		public static void testThis()
		{
			int[] test = {1, 2, 3, 4, 5 };
			UInt32 x = CountCombos(5, 2);
			System.Console.WriteLine("Given 5 numbers and 2 choices, there are a total of " + x + 
				" combinations");
			x = CountCombos(15, 4);
			System.Console.WriteLine("Given 15 numbers and 4 choices, there are a total of " + x + 
				" combinations");

			PrintCombination(test, 5, 2);
        }

	}
}
