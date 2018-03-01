using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;

namespace _557__Reverse_Words_in_a_String_III
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReverseWords("2323 adsf dsa ads fasd fas"));
        }

        static public string ReverseWords(string s)
        {
            string[] sp = s.Split();
            string result = "";
            for (int i = 0; i < sp.Length; i++)
            {
                char[] c = sp[i].ToCharArray();
                Array.Reverse(c);
                sp[i] = new string(c);
            }

            return String.Join(" ", sp);
        }
    }
}

//Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
//
//Example 1:
//Input: "Let's take LeetCode contest"
//Output: "s'teL ekat edoCteeL tsetnoc"
//Note: In the string, each word is separated by single space and there will not be any extra space in the string.

/// (string)string = new string(char[]  char[]) 是一个非常好的char[] 转 string
/// 值得铭记