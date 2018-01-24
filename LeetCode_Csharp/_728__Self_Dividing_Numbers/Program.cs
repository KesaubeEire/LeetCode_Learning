using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;

namespace _728__Self_Dividing_Numbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = 1;
            int b = 243;
            IList<int> c = SelfDividingNumbers(a, b);
            foreach (var VARIABLE in c)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> nums = new List<int>();
            for (int i = left; i <= right; i++)
            {
                bool isDivided = true;
                int k = i;
                if ((k % 10) == 0)
                {
                    isDivided = false;
                }

                while (k % 10 != 0)
                {
                    if ((i % (k % 10)) != 0)
                    {
                        isDivided = false;
                        break;
                    }

                    k = k / 10;
                    if (k == 0)
                    {
                        break;
                    }

                    if ((k % 10) == 0)
                    {
                        isDivided = false;
                        break;
                    }
                }

                if (isDivided)
                {
                    nums.Add(i);
                }
            }

            return nums;
        }

        /// <summary>
        /// 学到的不多，也有一点吧，别人写的就是简洁，考虑条件比较宽泛但是抓住了实质
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public IList<int> SelfDividingNumbers2(int left, int right)
        {
            var lst = new List<int>();
            for (int i = left; i <= right; i++)
            {
                int nr = i;
                bool divisable = true;
                while (nr > 0)
                {
                    int digit = nr % 10;
                    if (digit == 0 || i % digit != 0)
                    {
                        divisable = false;
                        break;
                    }

                    nr = nr / 10;
                }

                if (divisable)
                    lst.Add(i);
            }

            return lst;
        }
    }
}

/*
A self-dividing number is a number that is divisible by every digit it contains.

For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0.

Also, a self-dividing number is not allowed to contain the digit zero.

Given a lower and upper number bound, output a list of every possible self dividing number, including the bounds if possible.

Example 1:
Input: 
left = 1, right = 22
Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
Note:

The boundaries of each input argument are 1 <= left <= right <= 10000.
*/