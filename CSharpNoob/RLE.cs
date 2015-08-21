using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	/*	Practice test of writing a Running-Length Encoding program
	*
		Q:	Given 2 sequence of input in the format of "a, a, b, c, ..."
		determine if the 1st input is a RLE of the 2nd.
		2nd input format would be "1, a, 3, b..." --> abbb

		Ending condition:
		1. The character at position 'x' from the input differs from what is expected
			based on the RLE input.  ==> Return 'x' indicating the position where it
			differed.
		2. The characters all matched.
			==> Return -1
	*/

	class RLE
	{
		public static int isRLE(string input, string rle)
		{
			int pos = 0;
			int count = 0;
			char[] delimiters = { ',' , ' ' };
			//define the delimiters to parse the inputs and store them as tokens
			string[] tokens = input.Split(delimiters);
			string[] rle_tokens = rle.Split(delimiters);

			//get the # of characters expected from the RLE token
			/* Since every other token in RLE is the count, the actual # of characters in
			* the sequence is half the total length */
			for (int j = 0; j < rle_tokens.Length / 2; j++)
			{
				int occurance = int.Parse(rle_tokens[j * 2]);
				count = 0;
				//now traverse through the input and try to see if the count matches
				/*
					The way we evaluate is simply just traverse through the input
					string and just keep counting the # of instances we have a matching
					character until we no longer have a match, and just do a comparison
					of the match count to see if it matches, and if it doesn't, just return
					the position where the condition first became invalid
				*/

				while(pos < tokens.Length && tokens[pos].Equals(rle_tokens[2*j+1]))
				{
					pos++;
					count++;
					if (count > occurance)
					{
						break;
					}
				}

				//ending condition: the # of occurance of a character did not match 
				//what was expected from the RLE
				if (count != occurance)
				{
					return pos;
				}
			}
			//ending condition: the characters' occurance matched in the specified order
			return -1;
		}
		public static void testRLE()
		{
			System.Console.WriteLine("This is a test for Running-Length Encoding");
			int status = isRLE("a,b,b,c,c,c", "1,a,2,b,3,c");
			System.Console.WriteLine("Test case 1:\n  'a,b,b,c,c,c' & '1,a,2,b,3,c' returned:   " + status);
			status = isRLE("a,a,a,b,b,c,c,c", "2,a,1,b,3,c");
			System.Console.WriteLine("Test case 2:\n  'a,a,a,b,b,c,c,c' & '2,a,1,b,3,c' returned:   " + status);
			status = isRLE("a,b,b,b,b,b,b,b,b,b,b,c,c,c,d,d,d,d", "1,a,10,b,3,c,4,d");
			System.Console.WriteLine("Test case 3:\n  'a,b,b,b,b,b,b,b,b,b,b,c" +
				",c,c,d,d,d,d' \n  & '1,a,10,b,3,c,4,d' returned:   "
				+ status);

		}
	}
}
