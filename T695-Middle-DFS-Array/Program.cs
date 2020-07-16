using System;

namespace T695_Middle_DFS_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxAreaOfIsland(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            var res = 0;
            for(var i = 0; i < m; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    var area = maxarea(grid, i, j);
                    res = Math.Max(res, area);
                }
            }
            return res;
        }

        private int maxarea(int[][]grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
                return 0;
            else
                return 1 + maxarea(grid, i + 1, j) + maxarea(grid, i - 1, j) + maxarea(grid, i, j + 1) + maxarea(grid, i, j - 1);
        }
    }
}
