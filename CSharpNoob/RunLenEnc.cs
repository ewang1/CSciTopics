using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
    class RunLenEnc
    {
        static char[] delimiters = {',', ' '};
        public static int isRLE(String input, String rle)
        {

            int i = 0;
            string[] inputs = input.Split(delimiters);
            string[] tokens = rle.Split(delimiters);
            /* Since every other token in RLE is the count, the actual # of characters in
             * the sequence is half the total length */
            int rleChars = tokens.Length / 2;

            /* 
             * Overall, the runtime should be O(n) with a space complexity of O(1)
             * Because while we have a nested-loop design, we're really just going through
             * the length of the input string (and shifting the RLE string to update the
             * comparison) until we see a mismatch
             */
            for (int j = 0; j < rleChars; j++)
            {
                int count = 0;
                int seqLen = int.Parse(tokens[2*j]);
                while (i < inputs.Length && inputs[i].Equals(tokens[2 * j + 1]))
                {
                    count++;
                    i++;
                    if (count > seqLen) {
                        break;
                    }
                }
                if (count != seqLen)
                {
                    System.Console.WriteLine("Mismatch found for '" + tokens[2 * j + 1] +
                        "' & " + inputs[i]);
                    return i;
                }
            }
            System.Console.WriteLine("Encoding matches input!");
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
            System.Console.WriteLine("Test case 3:\n  'a,b,b,b,b,b,b,b,b,b,b,c,c,c,d,d,d,d' \n  & '1,a,10,b,3,c,4,d' returned:   "
                + status);

        }
    }
}
