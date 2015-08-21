using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	/*	Given a set of dishes and a list of people with their own individual preferences
	*	Find the minimal # of dishes it takes to satisfy everyone
	*
	*	This example attempts to do-away with a 2D array by using a 32-bit integer (max
	*	total of 32 people so to speak) as a proof of concept
	*
	*	This can probably be further optimized for DP / memoization...
	*	Idea #1:	With the 32-bit approach, store each starting 'n' dishes as the OR-bit
	*				total; e.g. dish[1,2] = 0011, or 3, so subsequent 3-dish combos that start 
					with [1,2] can just do a OR op with 3 to get the # of bits for people
					satisfied, and [1,2,3] can be used for 4-dish combos, etc.
	*	Idea #2:	With the 32-bit approach, store the max ppl bit value for each dish level
					e.g. #1 dish max = 11011 (4 ppl, but 27 dec), subsequent 2-dish max just
					needs to see if it OR with that to see if it can something like 11111
	*/
	class DishesForPeople
	{
		int max;
		int totalops;

		public int PeopleServed(int[] dishes)
		{
			int bits = 0;
			int total = 0;
			//do an OR bit op to get 1 combined value of 1's
			for (int i = 0; i < dishes.Length; i++)
			{
				bits = dishes[i] | bits;
			}

			// count total number of '1' bits for actual head count
			while (bits > 0)
			{
				total += bits & 1;
				bits >>= 1;
			}
			//System.Console.WriteLine("The # of unique people served by this combo is " + total);
			return total;
		}

		public void GetDishCombos(int[] dishes, int picks, int index, int[] data, int w)
		{
			totalops++;
			if (index == picks)
			{

				if (PeopleServed(data) > max)
				{
					max = PeopleServed(data);
                }
				//this prints the combination
				for (int x = 0; x < data.Length; x++)
				{
					System.Console.Write(" " + data[x] + " ");
				}
				System.Console.WriteLine();
				return;
			}

			if (w >= dishes.Length)
			{
				return;
			}

			data[index] = dishes[w];
			GetDishCombos(dishes, picks, index + 1, data, w + 1);

			GetDishCombos(dishes, picks, index, data, w + 1);
		}

		public int FindMinDishes(int[] dishes, int ppl)
		{
			int current = 0;
			int[] data;
			while (max < ppl && current < dishes.Length)
			{
				current++;
				data = new int[current];
				GetDishCombos(dishes, current, 0, data, 0);
				System.Console.WriteLine("The max ppl satisfied with " + current +
					" dish(es) is " + max);
 
			}
			System.Console.WriteLine("Total Ops to find this solution: " + totalops);
			return current;
		}

		public void testDishes()
		{

			/*
				Too lazy to write a full 2D array, so using a 32-bit int as the bit sequence
				instead so I can get away with a 1D array
				Test Data:	
				[			p1	p2	p3	p4	p5	p6	p7
				Dish #1		0	0	1	1	1	0	0	==> 28 in dec
				Dish #2		1	1	0	0	1	1	0	==>	102 in dec
				Dish #3		0	1	1	0	0	0	1	==>	49 in dec
				Dish #4		0	0	1	1	0	1	0	==>	26 in dec
				Dish #5		1	0	1	1	0	0	0	==>	88 in dec
				Dish #6		0	0	0	1	0	0	1	==>	9 in dec
				]
			*/
			int[] dishes = {28, 102, 49, 26, 88, 9};

			int val = FindMinDishes(dishes, 7);

			System.Console.WriteLine("The # of dishes it takes to satisfy everyone is " + val);
		}

	}
}
