using System;
using System.Collections.Generic;
using System.Linq;

namespace _476__Number_Complement
{
    internal class Program
    {
        private char _variable;

        public static void Main(string[] args)
        {
            Console.WriteLine(findComplement(5));
        }

        static public int findComplement(int num)
        {
            List<char> s = Convert.ToString(num, 2).ToList();
            List<char> ss = new List<char>();

            foreach (char VARIABLE in s)
            {
                if (VARIABLE == '0')
                {
                    ss.Add('1');
                }

                if (VARIABLE == '1')
                {
                    ss.Add('0');
                }
            }


            return Convert.ToInt32(String.Join("", ss.ToArray()), 2);
        }
    }
}
/*Given a positive integer, output its complement number. The complement strategy is to flip the bits of its binary representation.

Note:
The given integer is guaranteed to fit within the range of a 32-bit signed integer.
You could assume no leading zero bit in the integer’s binary representation.
Example 1:
Input: 5
Output: 2
Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
Example 2:
Input: 1
Output: 0
Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
*/