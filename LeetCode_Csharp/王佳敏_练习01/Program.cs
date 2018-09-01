using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //输入一个大于3的正整数n
            int n;
            do
            {
                Console.WriteLine("请输入大于三的正整数：");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 3); //不满足大于3的条件时重新输入

            //数组的声明赋值
            int[] Array1 = new int[n * n];
            //数组的遍历赋值
            for (int i = 0; i < n * n; i++)
            {
                Array1[i] = Fibonacci(i + 1);
            }

            //给n-2个矩阵
            for (int m = 3; m <= n; m++)
            {
                Console.WriteLine("输出一个{0}x{1}的矩阵", m, m);
                for (int a = 0; a < m; a++)
                {
                    for (int b = 0; b < m; b++)
                    {
                        Console.Write(Array1[a * m + b] + "\t"); //用斐波那契数列填充矩阵
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        //斐波那契数列实现
        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}