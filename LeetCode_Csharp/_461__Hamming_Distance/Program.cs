using System;

namespace _461__Hamming_Distance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(HammingDistance(1, 4));
        }

        public static int HammingDistance(int x, int y)
        {
            int xc = x;
            int yc = y;
            int diff = 0;
            int t = Math.Max(x, y);
            int trigger = 1;

            for (int i = 0; i < trigger; i++)
            {
                if ((xc % 2) != (yc % 2))
                {
//                    Console.WriteLine("xc:" + xc % 2);
//                    Console.WriteLine("yc:" + yc % 2);
                    diff++;
                }

                xc = xc / 2;
                yc = yc / 2;
                if (xc == 0 && yc == 0) break;
                else
                {
                    trigger++;
                }
            }

            return diff;
        }
    }
}
/*
The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Given two integers x and y, calculate the Hamming distance.

Note:
0 ≤ x, y < 231.

Example:

Input: x = 1, y = 4

Output: 2

Explanation:
1   (0 0 0 1)
4   (0 1 0 0)
       ↑   ↑

The above arrows point to positions where the corresponding bits are different.
*/