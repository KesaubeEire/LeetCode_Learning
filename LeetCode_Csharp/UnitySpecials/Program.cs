using System;

namespace UnitySpecials
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                char[] a = Console.ReadLine().ToCharArray();
                char[] b = new char[a.Length];


                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == '3')
                    {
                        b[i] = '0';
                    }
                    else if (a[i] == '0')
                    {
                        b[i] = '3';
                    }
                    else
                    {
                        b[i] = a[i];
                    }
                }

                foreach (var VARIABLE in b)
                {
                    Console.Write(VARIABLE);
                }
            }
        }
    }
}