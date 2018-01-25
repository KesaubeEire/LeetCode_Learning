using System;
using System.Collections.Generic;
using System.Net.Security;

namespace _763__Partition_Labels
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = "ababcbacadefegdehijhklij";
            Console.WriteLine(PartitionLabels(s));
        }

        public static IList<int> PartitionLabels(string S)
        {
            IList<int> EE = new List<int>(1);

            void constructure(string sss)
            {
                char[] ss = sss.ToCharArray();

                int GetEnd(char s) //搞到某个字符的尾数
                {
                    int markend = -1;
                    for (int i = 1; i < ss.Length; i++)
                    {
                        if (ss[i] == ss[0])
                        {
                            markend = i;
                        }
                    }

                    return markend;
                }

                int E = GetEnd(ss[0]);
                for (int i = 0; i < E; i++)
                {
                    if (GetEnd(ss[i]) > E) E = GetEnd(ss[i]);
                }

                EE.Add(E + 1);
                Console.WriteLine(E + 1);
                if ((E + 1) != ss.Length)
                {
                    string ssss = sss.Remove(0, E + 1);
                }
            }

            constructure(S);
            return EE;
        }
    }
}
/*A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, and return a list of integers representing the size of these parts.

Example 1:
Input: S = "ababcbacadefegdehijhklij"
Output: [9,7,8]
Explanation:
The partition is "ababcbaca", "defegde", "hijhklij".
This is a partition so that each letter appears in at most one part.
A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
Note:

S will have length in range [1, 500].
S will consist of lowercase letters ('a' to 'z') only.
*/