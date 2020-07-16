using System;
using System.Collections.Generic;

namespace T1162_Middle_BFS_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxDistance(int[][] grid)
        {
            var ls = new List<Tuple<int, int>>();
            var n = grid.Length;

            for(var i = 0; i < n; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                        ls.Add(new Tuple<int, int>(i, j));
                }
            }
            var landcount = ls.Count;
            if (landcount == 0 || landcount == n * n)
                return -1;

            var distance = 0;
            var xdir = new int[] { 0, 1, 0, -1 };
            var ydir = new int[] { 1, 0, -1, 0 };
            while(true)
            {
                if (landcount == n * n)
                    break;
                var curls = new List<Tuple<int, int>>();

                foreach(var land in ls)
                {
                    for (var dir = 0; dir < 4; dir++)
                    {
                        var x = land.Item1 + xdir[dir];
                        var y = land.Item2 + ydir[dir];
                        if (x < 0 || x > n - 1 || y < 0 || y > n - 1 || grid[x][y] == 1)
                            continue;
                        else
                        {
                            grid[x][y] = 1;
                            landcount++;
                            curls.Add(new Tuple<int, int>(x, y));
                        }
                    }
                }
                ls = curls;
                distance++;
            }
            return distance;
        }
    }
}
