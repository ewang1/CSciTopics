using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	class BitManip
	{
		/* UpdateBits - Given 2 x 32-bit integers 'x', 'y' and 2 bit positions
		*  Set all bits between the 2 positions in 'x' equal to 'y'
		* e.g. given x = 10000000, y = 10101, pos1 = 2, pos2 = 6, output = 11010100
		*/
		public static int UpdateBits(int x, int y, int pos1, int pos2)
		{
			//start with all 1's
			int max = ~0;
			//1's up to position 2, then 0's afterward
			int left = max - ((1 << pos2) - 1);
			//1's after position 1
			int right = (1 << pos1) - 1;
			//1's with 0's between pos1 and pos2
			int mask = left | right;
			//clear pos1 through pos2, then put 'y' in
			return (x & mask) | (y << pos1);

		}
	}
}
