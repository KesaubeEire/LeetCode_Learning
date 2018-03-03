using System;
using System.Collections.Generic;

namespace _442__Find_All_Duplicates_in_an_Array
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] sss = {4, 3, 2, 7, 8, 2, 3, 1};
            Console.WriteLine(FindDuplicates(sss));
        }

        static public IList<int> FindDuplicates(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>();
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int lenen = hs.Count;
                hs.Add(nums[i]);
                if (hs.Count == lenen) res.Add(nums[i]);
            }

            return res;
        }
    }
}
/*Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

Find all the elements that appear twice in this array.

Could you do it without extra space and in O(n) runtime?

Example:
Input:
[4,3,2,7,8,2,3,1]

Output:
[2,3]
*/


/// haha first!!!