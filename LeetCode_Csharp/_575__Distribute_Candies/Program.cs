using System;
using System.Collections.Generic;

namespace _575__Distribute_Candies
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] candle =
                {1, 1, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 4, 5, 6, 7, 6, 5, 4, 8};
            Console.WriteLine(DistributeCandies2(candle));
        }

        //我的方法时间复杂度超了
//        static public int DistributeCandies(int[] candies)
//        {
//            List<int> kind = new List<int>();
//            for (int i = 0; i < candies.Length; i++)
//            {
//                if (!kind.Contains(candies[i]))
//                {
//                    kind.Add(candies[i]);
//                }
//
//                if (kind.Count == candies.Length / 2)
//                    return kind.Count;
//            }
//
//            if (kind.Count > candies.Length / 2)
//                return candies.Length / 2;
//            else
//                return kind.Count;
//        }

        /// <summary>
        /// 还是人家的方法好啊,学到了 Hashset智能储存不重复的元素
        /// </summary>
        /// <param name="candies"></param>
        /// <returns></returns>
        static public int DistributeCandies2(int[] candies)
        {
            HashSet<int> kinds = new HashSet<int>();

            List<int> kind = new List<int>();
            for (int i = 0;
                i < candies.Length;
                i++)
            {
                kinds.Add(candies[i]);
            }

            return Math.Min(kinds.Count, candies.Length / 2);
        }
    }
}

//Given an integer array with even length, where different numbers in this array represent different kinds of candies. Each number means one candy of the corresponding kind. You need to distribute these candies equally in number to brother and sister. Return the maximum number of kinds of candies the sister could gain.
//Example 1:
//Input: candies = [1,1,2,2,3,3]
//Output: 3
//Explanation:
//There are three different kinds of candies (1, 2 and 3), and two candies for each kind.
//Optimal distribution: The sister has candies [1,2,3] and the brother has candies [1,2,3], too. 
//The sister has three different kinds of candies. 
//Example 2:
//Input: candies = [1,1,2,3]
//Output: 2
//Explanation: For example, the sister has candies [2,3] and the brother has candies [1,1]. 
//The sister has two different kinds of candies, the brother has only one kind of candies. 
//Note:
//
//The length of the given array is in range [2, 10,000], and will be even.
//The number in given array is in range [-100,000, 100,000].

//finai

/// tips: Hashset 只能储存不重复的元素,非常便利的东西,减少时间复杂度的大杀器