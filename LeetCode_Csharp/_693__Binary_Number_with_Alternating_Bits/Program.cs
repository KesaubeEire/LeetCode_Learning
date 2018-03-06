using System;

namespace _693__Binary_Number_with_Alternating_Bits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public bool HasAlternatingBits(int n)
        {
            string a = System.Convert.ToString(n, 2);

            bool res = true;
            if (a.Length == 1) return true;
            for (int i = 0; i < a.Length; i++)
            {
                if (i != 0)
                {
                    if (a[i] == a[i - 1])
                        res = false;
                }
            }

            return res;
        }

        /// 别人的,没看懂
//        public bool HasAlternatingBits(int n)
//        {
//            int remainder = n % 2;
//            while (n > 0)
//            {
//                n /= 2;
//                if (remainder == n % 2) return false;
//                remainder = n % 2;
//            }
//
//            return true;
//        }
    }
}
/*Given a positive integer, check whether it has alternating bits: namely, if two adjacent bits will always have different values.

Example 1:
Input: 5
Output: True
Explanation:
The binary representation of 5 is: 101
Example 2:
Input: 7
Output: False
Explanation:
The binary representation of 7 is: 111.
Example 3:
Input: 11
Output: False
Explanation:
The binary representation of 11 is: 1011.
Example 4:
Input: 10
Output: True
Explanation:
The binary representation of 10 is: 1010.*/