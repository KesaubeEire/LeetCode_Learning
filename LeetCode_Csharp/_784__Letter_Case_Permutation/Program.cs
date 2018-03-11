using System;
using System.Collections.Generic;

namespace _784__Letter_Case_Permutation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = "a1b2";
            Console.WriteLine(LetterCasePermutation(s));
        }

        // 我的方法是二维数组
        static public IList<string> LetterCasePermutation(string S)
        {
            char[] ss = S.ToCharArray();
            List<string> res = new List<string>();
            List<char[]> newbee = new List<char[]>();
            List<int> con = new List<int>();
            int count = 0;
            for (int i = 0; i < S.Length; i++)
            {
                char[] ass = new Char[3];
                if (Char.IsLetter(S[i]))
                {
                    ass[0] = S[i];
                    if (Char.IsLower(S[i]))
                    {
                        ass[1] = char.ToUpper(S[i]);
                    }

                    if (Char.IsUpper(S[i]))
                    {
                        ass[1] = char.ToLower(S[i]);
                    }

                    newbee.Add(ass);
                    con.Add(i);
                    Console.WriteLine(i);
                    Console.WriteLine(ass[0]);
                    Console.WriteLine(ass[1]);
                    count++;
                }
            }

            Console.WriteLine("Count:" + count);

            for (int i = 0; i < (2 ^ count); i++)
            {
                string code = Convert.ToString(i, 2);
                for (int j = 0; j < count; j++)
                {
                    if (j < code.Length)
                    {
                        newbee[con[j]][2] = newbee[con[j]][code[j]];
                    }
                    else
                    {
                        newbee[con[j]][2] = newbee[con[j]][0];
                    }
                }

                for (int j = 0; j < con.Count; j++)
                {
                    ss[con[j]] = (char) newbee[con[j]][2];
                }

                Console.WriteLine(ss);
                res.Add(ss.ToString());
            }

            return res;
        }
    }
} /*Given a string S, we can transform every letter individually to be lowercase or uppercase to create another string.  Return a list of all possible strings we could create.

Examples:
Input: S = "a1b2"
Output: ["a1b2", "a1B2", "A1b2", "A1B2"]

Input: S = "3z4"
Output: ["3z4", "3Z4"]

Input: S = "12345"
Output: ["12345"]
Note:

S will be a string with length at most 12.
S will consist only of letters or digits.
*/

/// 没搞出来,希望能弄出来