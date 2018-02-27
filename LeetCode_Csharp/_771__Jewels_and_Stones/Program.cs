using System;
using System.Collections.Generic;
using System.Linq;

namespace _771__Jewels_and_Stones
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string J = "A";
            string S = "aAAbbbb";
            Console.WriteLine(NumJewelsInStones(J, S));
        }


        public static int NumJewelsInStones(string J, string S)
        {
            List<char> JJ = J.ToList();
            List<char> SS = S.ToList();
            int Final = 0;
            for (int i = 0; i < JJ.Count; i++)
            {
                for (int j = 0; j < SS.Count; j++)
                {
                    if (JJ[i] == SS[j])
                    {
                        Final++;
                    }
                }
            }

            return Final;
        }
    }
}