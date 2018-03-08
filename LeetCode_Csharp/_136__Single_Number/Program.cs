using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _136__Single_Number
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public int SingleNumber(int[] nums)
        {
            /// 别人的XOR运算
            int singleNumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                singleNumber = singleNumber ^ nums[i];
            }

            return singleNumber;
        }

        //最快的哥们的算法
        public class Solution
        {
            public int SingleNumber(int[] nums)
            {
                int n = nums[0];
                for (int i = 1; i < nums.Length; ++i)
                {
                    n ^= nums[i];
                }

                return n;
            }
        }
    }
}
/*Given an array of integers, every element appears twice except for one. Find that single one.

Note:
Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

*/

//XOR 异或运算真神奇啊