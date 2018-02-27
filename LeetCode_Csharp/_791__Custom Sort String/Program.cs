using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _791__Custom_Sort_String
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const string S = "cba";
            const string T = "abcd";
            Console.WriteLine(CustomSortString(S, T));
        }

        private static string CustomSortString(string S, string T)
        {
            var char_s = S.ToList(); //S的char化
            var char_t = T.ToList(); //S的char化
            var char_s_num = new int[char_s.Count]; // 记录每个char的个数
            var rest = new List<char>();
            for (var i = 0; i < T.Length; i++)
            {
                if (!char_s.Contains(char_t[i]))
                {
                    rest.Add(char_t[i]);
                }
                else
                {
                    var index = char_s.ToList().IndexOf(char_t[i]);
                    char_s_num[index]++;
                }
            }

            var output = new List<char>();
            for (var i = 0; i < char_s.Count; i++)
            {
                if (char_s_num[i] == 0) continue;
                for (var j = 0; j < char_s_num[i]; j++)
                {
                    output.Add(char_s[i]);
                }
            }

            foreach (var VARIABLE in rest)
            {
                output.Add(VARIABLE);
            }

            return String.Join("", output);
        }
    }
}
//S and T are strings composed of lowercase letters. In S, no letter occurs more than once.
//
//S was sorted in some custom order previously. We want to permute the characters of T so that they match the order that S was sorted. More specifically, if x occurs before y in S, then x should occur before y in the returned string.
//
//Return any permutation of T (as a string) that satisfies this property.
//
//Example :
//Input: 
//S = "cba"
//T = "abcd"
//Output: "cbad"
//Explanation: 
//"a", "b", "c" appear in S, so the order of "a", "b", "c" should be "c", "b", and "a". 
//Since "d" does not appear in S, it can be at any position in T. "dcba", "cdba", "cbda" are also valid outputs.
// 
//
//Note:
//
//S has length at most 26, and no character is repeated in S.
//T has length at most 200.
//S and T consist of lowercase letters only.

///Tips:
/// 泛型 转 String 必须要 String.Join("",output)
/// 引号内的东西是相邻list元素之间的间隔物,不写就是没有