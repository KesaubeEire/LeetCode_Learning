using System;
using System.Security.Policy;

namespace _520__Detect_Capital
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string test = "FFFFFFFFFFFFFFFFFFFFf";
            Console.WriteLine(DetectCapitalUse(test));
        }

        static public bool DetectCapitalUse(string word)
        {
            int position = 0;
            if (word.Length == 1) return true;
            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0)
                {
                    if (Char.IsUpper(word[i]))
                    {
                        position = 1;
                        if (Char.IsUpper(word[1]))
                        {
                            position = 1;
                            Console.WriteLine(position);
                        }

                        if (Char.IsLower(word[1]))
                        {
                            position = 2;
                            Console.WriteLine(position);
                        }
                    }

                    if (Char.IsLower(word[i]))
                    {
                        position = 3;
                        Console.WriteLine(position);
                    }
                }
                else
                {
                    if (position == 1)
                    {
                        if (!Char.IsUpper(word[i]))
                        {
                            return false;
                        }
                    }

                    if (position == 2)
                    {
                        if (!Char.IsLower(word[i]))
                        {
                            return false;
                        }
                    }

                    if (position == 3)
                    {
                        if (!Char.IsLower(word[i]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
/*
 * Given a word, you need to judge whether the usage of capitals in it is right or not.

We define the usage of capitals in a word to be right when one of the following cases holds:

All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital if it has more than one letter, like "Google".
Otherwise, we define that this word doesn't use capitals in a right way.
Example 1:
Input: "USA"
Output: True
Example 2:
Input: "FlaG"
Output: False
Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters.


 */

// Done