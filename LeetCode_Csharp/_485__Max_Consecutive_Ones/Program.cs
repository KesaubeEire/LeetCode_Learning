using System;

namespace _485__Max_Consecutive_Ones
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] aa = {1, 0, 1, 1, 0, 1};
            Console.WriteLine(FindMaxConsecutiveOnes(aa));
        }

        static public int FindMaxConsecutiveOnes(int[] nums)
        {
            string[] resrin0 = String.Join("", nums).Split('0');
            int max0 = 0;
            for (int i = 0; i < resrin0.Length; i++)
            {
                if (resrin0[i].Length > max0) max0 = resrin0[i].Length;
            }

            return max0;
        }

        //别人的
        public int FindMaxConsecutiveOnes1(int[] nums)
        {
            int max = 0;

            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }

            max = Math.Max(max, count);

            return max;
        }

        //别人的2
        public int FindMaxConsecutiveOnes2(int[] nums)
        {
            int res = 0;
            int current = 0;
            foreach (int i in nums)
            {
                if (i == 1)
                {
                    current++;
                    res = Math.Max(res, current);
                }
                else
                {
                    current = 0;
                }
            }

            return res;
        }
    }
}
/*Given a binary array, find the maximum number of consecutive 1s in this array.

Example 1:
Input: [1,1,0,1,1,1]
Output: 3
Explanation: The first two digits or the last three digits are consecutive 1s.
    The maximum number of consecutive 1s is 3.
Note:

The input array will only contain 0 and 1.
The length of input array is a positive integer and will not exceed 10,000*/