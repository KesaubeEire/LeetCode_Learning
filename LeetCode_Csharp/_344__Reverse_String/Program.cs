using System;
using System.Collections;
using System.Collections.Generic;

namespace _344__Reverse_String
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReverseString("westgdghjf"));
        }

        static public string ReverseString(string s)
        {
            char[] ss = new char[s.Length];

            //        Array.Reverse(c);
            for (int i = 0; i < s.Length; i++)
            {
                ss[s.Length - 1 - i] = s[i];
            }

            return String.Join("", ss);
        }
    }
}
/*Write a function that takes a string as input and returns the string reversed.

Example:
Given s = "hello", return "olleh".*/

// 大神的代码看看哦

//public class Solution
//{
//    public string ReverseString(string s)
//    {
//        char[] c = s.ToCharArray();
//        Array.Reverse(c);
//
//        return new String(c);
//    }
//}