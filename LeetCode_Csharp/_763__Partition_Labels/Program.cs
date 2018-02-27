using System;
using System.Collections.Generic;
using System.Net.Security;

namespace _763__Partition_Labels
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = "caedbdedda";
            Console.WriteLine(PartitionLabels(s));
            ;
        }

        public static IList<int> PartitionLabels(string S)
        {
            IList<int> EE = new List<int>(1);

            string constructure(string sss)
            {
                char[] ss = sss.ToCharArray();

                int GetEnd(char s) //搞到某个字符的尾数
                {
                    char theOne = new char();
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (ss[i] == s)
                        {
                            theOne = ss[i];
                        }
                    }

                    int markend = -1;
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (ss[i] == theOne)
                        {
                            markend = i;
                        }
                    }

                    if (markend == -1) Console.WriteLine("fuck");
                    return markend;
                }

                int E = 0;
                for (int i = 0; i < ss.Length; i++)
                {
                    E = i;
                    if (GetEnd(ss[i]) != i)
                    {
                        E = GetEnd(ss[i]);
                        break;
                    }
                    else if (i == 0)
                    {
                        E = 0;
                        break;
                    }
                }

                //---
                Console.WriteLine("E_origin = " + E);

                for (int i = 1; i < ss.Length; i++)
                {
                    if (i < E)
                    {
                        if (GetEnd(ss[i]) > E)
                        {
                            E = GetEnd(ss[i]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //---
                Console.WriteLine("E_final = " + E);

                EE.Add(E + 1);
                Console.WriteLine("这组结果是:\t" + (E + 1));
                if ((E + 1) != ss.Length)
                {
                    string ssss = sss.Remove(0, E + 1);
                    Console.WriteLine(ssss);
                    constructure(ssss);
                    return ssss;
                }

                return null;
            }


            S = constructure(S);


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


////看看人家的Java代码 1 ms 耶
//class Solution {
//    public List<Integer> partitionLabels(String S) {
//        int[] last = new int[26];
//        for (int i = 0; i < S.length(); ++i)
//            last[S.charAt(i) - 'a'] = i;
//        
//        int j = 0, anchor = 0;
//        List<Integer> ans = new ArrayList();
//        for (int i = 0; i < S.length(); ++i) {
//            j = Math.max(j, last[S.charAt(i) - 'a']);
//            if (i == j) {
//                ans.add(i - anchor + 1);
//                anchor = i + 1;
//            }
//        }
//        return ans;
//    }
//}