using System;

namespace 内嵌函数
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            printWhat();
        }

        static void printWhat()
        {
            string printWhat_1()
            {
                return "111";
            }

            string printWhat_2()
            {
                return "222";
            }

            string printWhat_3()
            {
                return "333";
            }

            Console.WriteLine($"我想{printWhat_1()}吧又想{printWhat_2()}");
        }
    }
}