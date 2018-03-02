using System;
using System.Collections.Generic;

namespace _500__Keyboard_Row
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] sss = {"Hello", "Alaska", "Dad", "Peace"};
            Console.WriteLine(FindWords(sss));
        }

        static public string[] FindWords(string[] words)
        {
//            string[] res = new string[words.Length];
            List<string> res = new List<string>();
            int intintint = -1;

            int GetType(char xx)
            {
                if (xx == 'q' || xx == 'w' || xx == 'e' || xx == 'r' || xx == 't' || xx == 'y' || xx == 'u' ||
                    xx == 'i' || xx == 'o' || xx == 'p' ||
                    xx == 'Q' || xx == 'W' || xx == 'E' || xx == 'R' || xx == 'T' || xx == 'Y' || xx == 'U' ||
                    xx == 'I' || xx == 'O' || xx == 'P')
                {
                    Console.WriteLine(xx + "\t1");
                    return 1;
                }

                if (xx == 'a' || xx == 's' || xx == 'd' || xx == 'f' || xx == 'g' || xx == 'h' || xx == 'j' ||
                    xx == 'k' || xx == 'l' ||
                    xx == 'A' || xx == 'S' || xx == 'D' || xx == 'F' || xx == 'G' || xx == 'H' || xx == 'J' ||
                    xx == 'K' || xx == 'L')
                {
                    Console.WriteLine(xx + "\t2");
                    return 2;
                }

                if (xx == 'z' || xx == 'x' || xx == 'c' || xx == 'v' || xx == 'b' || xx == 'n' || xx == 'm' ||
                    xx == 'Z' || xx == 'X' || xx == 'C' || xx == 'V' || xx == 'B' || xx == 'N' || xx == 'M')
                {
                    Console.WriteLine(xx + "\t3");
                    return 3;
                }

                Console.WriteLine("error");
                return 0;
            }

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("start:\t" + (i + 1));
                int trigger = -1;
                bool isAdd = true;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j == 0)
                    {
                        trigger = GetType(words[i][j]);
                        Console.WriteLine(trigger);
                    }
                    else
                    {
                        if (trigger != GetType(words[i][j]))
                        {
                            isAdd = false;
                            Console.WriteLine(233);
                            break;
                        }
                    }
                }

                Console.WriteLine("end:\t" + (i + 1));

                if (isAdd)
                {
//                    intintint++;
//                    res[intintint] = words[i];

                    intintint++;
                    res.Add(words[i]);
                }
            }

            string[] ress = new string[res.Count];
            for (int i = 0; i < res.Count; i++)
            {
                if (res[i] != null)
                    ress[i] = res[i];
            }

            return ress;
        }
    }
}

/*
 * Given a List of words, return the words that can be typed using letters of alphabet on only one row's of American keyboard like the image below.


American keyboard


Example 1:
Input: ["Hello", "Alaska", "Dad", "Peace"]
Output: ["Alaska", "Dad"]
Note:
You may use one character in the keyboard more than once.
You may assume the input string will only contain letters of alphabet.

 */