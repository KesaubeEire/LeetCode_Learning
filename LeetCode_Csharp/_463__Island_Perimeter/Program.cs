using System;

namespace _463__Island_Perimeter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] ss = {{0, 1, 0, 0}, {1, 1, 1, 0}, {0, 1, 0, 0}, {1, 1, 0, 0}};
            Console.WriteLine(IslandPerimeter(ss));
        }

        /// 我的答案是看一个格子的上下左右四个格子是否有其他岛 然后用 每个格子输出 (4 - 邻居数)
        /// 但是这样有一个重复计算的问题,会把已经算过一遍的数再算一遍
        /// 如果只算下方和右方,就能避免这个问题,只需要把链接的邻居数 * 2,因为链接是相互的
        /// 所以可以只算 下 和 右, 用 4*格子-2*链接数
        /// 大神的方法
        static public int IslandPerimeter(int[,] grid)
        {
            int ret = 0;
            Console.WriteLine(grid.GetLength(0));
            Console.WriteLine(grid.GetLength(1));
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                    {
                        int trigger = 0;
//                        Console.WriteLine("Found:\t" + i + "," + j);
                        if (i > 0 && grid[i - 1, j] == 1)
                        {
//                            Console.WriteLine("top");
                            trigger++;
                        }

                        if (i < grid.GetLength(0) - 1 && grid[i + 1, j] == 1)
                        {
//                            Console.WriteLine("bottom");
                            trigger++;
                        }

                        if (j > 0 && grid[i, j - 1] == 1)
                        {
//                            Console.WriteLine("left");
                            trigger++;
                        }

                        if (j < grid.GetLength(1) - 1 && grid[i, j + 1] == 1)
                        {
//                            Console.WriteLine("right");
                            trigger++;
                        }

//                        Console.WriteLine("trigger:\t" + trigger);
                        ret += (4 - trigger);
                    }
                }
            }

            return ret;
        }

        static public int IslandPerimeter2(int[,] grid)
        {
            int ret = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                    {
                        int trigger = 0;
//                        Console.WriteLine("Found:\t" + i + "," + j);


                        if (i < grid.GetLength(0) - 1 && grid[i + 1, j] == 1)
                        {
//                            Console.WriteLine("bottom");
                            trigger++;
                        }


                        if (j < grid.GetLength(1) - 1 && grid[i, j + 1] == 1)
                        {
//                            Console.WriteLine("right");
                            trigger++;
                        }

//                        Console.WriteLine("trigger:\t" + trigger);
                        ret += (4 - trigger * 2);
                    }
                }
            }

            return ret;
        }
    }
}

/*You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water. Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells). The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.

Example:

[[0,1,0,0],
 [1,1,1,0],
 [0,1,0,0],
 [1,1,0,0]]

Answer: 16
Explanation: The perimeter is the 16 yellow stripes in the image below:
*/