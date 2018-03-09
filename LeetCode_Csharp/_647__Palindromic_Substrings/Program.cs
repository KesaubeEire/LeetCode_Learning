using System;

namespace _647__Palindromic_Substrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int l = 990;
            int r = 1048;
            Console.WriteLine(CountPrimeSetBits(l, r));
        }

        static public int CountPrimeSetBits(int L, int R)
        {
            bool sushu(int value)
            {
                if (value == 1 || value == 0)
                {
                    return false;
                }

                double n = Math.Round(Math.Sqrt(value));
                // MessageBox.Show(n.ToString());
                for (int i = 2; i <= n; i++)
                {
                    if (value % i == 0)
                        return false;
                }

                return true;
            }

            int res = 0;
            for (int i = L; i <= R; i++)
            {
                string asss = Convert.ToString(i, 2);
//                Console.WriteLine(asss);
                int pp = 0;
                for (int j = 0; j < asss.Length; j++)
                {
                    if (asss[j] == '1')
                    {
                        pp++;
                    }

//                    Console.WriteLine("asss{0}:" + asss[j], j);
                }

//                Console.WriteLine("pp:" + pp);
//                Console.WriteLine(pp + "是否是质数:" + sushu(pp));
                if (sushu(pp))
                {
                    res++;
                }
            }

            return res;
        }
    }
}