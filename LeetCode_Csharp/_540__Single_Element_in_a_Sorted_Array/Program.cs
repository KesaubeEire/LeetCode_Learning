using System;

namespace _540__Single_Element_in_a_Sorted_Array
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(233);
        }

        public int SingleNonDuplicate(int[] nums)
        {
            /// 别人家的优秀算法
            /// 异或运算就是这么NB

            int n = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                n ^= nums[i];
            }

            return n;
        }
    }
}
//Given a sorted array consisting of only integers where every element appears twice except for one element which appears once. Find this single element that appears only once.
//
//Example 1:
//Input: [1,1,2,3,3,4,4,8,8]
//Output: 2
//Example 2:
//Input: [3,3,7,7,10,11,11]
//Output: 10
//Note: Your solution should run in O(log n) time and O(1) space.