using System;
using System.Collections.Generic;
using System.Linq;

namespace _496__Next_Greater_Element_I
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] aiai = {4, 1, 2};
            int[] aiai2 = {1, 3, 4, 2};
            Console.WriteLine(NextGreaterElement(aiai, aiai2));
        }

        static public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            List<int> numss = nums.ToList();
            List<int> res = new List<int>();
            for (int i = 0; i < findNums.Length; i++)
            {
                int index = numss.IndexOf(findNums[i]);
                if (index == numss.Count - 1) res.Add(-1);
                else
                {
                    bool isDone = false;
                    for (int j = index + 1; j < numss.Count; j++)
                    {
                        if (nums[j] > findNums[i])
                        {
                            res.Add(nums[j]);
                            isDone = true;
                            break;
                        }
                    }

                    if (!isDone)
                        res.Add(-1);
                }
            }

            return res.ToArray();


            /*
             List<int> numss = nums.ToList();
            List<int> res = new List<int>();
            for (int i = 0; i < findNums.Length; i++)
            {
                int index = numss.IndexOf(findNums[i]);
                if (index == numss.Count - 1) res.Add(-1);
                else
                {
                    for (int j = index + 1; j < numss.Count; j++)
                    {
                        if (nums[j] > findNums[i])
                        {
                            res.Add(nums[j]);
                            break;
                            ;
                        }
                    }

                    res.Add(-1);
                }
            }

            int[] ress = new int[res.Count];
            for (int i = 0; i < res.Count; i++)
            {
                ress[i] = res[i];
            }

            return ress;
            */
        }
    }
}
/*You are given two arrays (without duplicates) nums1 and nums2 where nums1’s elements are subset of nums2. Find all the next greater numbers for nums1's elements in the corresponding places of nums2.

The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2. If it does not exist, output -1 for this number.

Example 1:
Input: nums1 = [4,1,2], nums2 = [1,3,4,2].
Output: [-1,3,-1]
Explanation:
    For number 4 in the first array, you cannot find the next greater number for it in the second array, so output -1.
    For number 1 in the first array, the next greater number for it in the second array is 3.
    For number 2 in the first array, there is no next greater number for it in the second array, so output -1.
Example 2:
Input: nums1 = [2,4], nums2 = [1,2,3,4].
Output: [3,-1]
Explanation:
    For number 2 in the first array, the next greater number for it in the second array is 3.
    For number 4 in the first array, there is no next greater number for it in the second array, so output -1.
Note:
All elements in nums1 and nums2 are unique.
The length of both nums1 and nums2 would not exceed 1000.*/