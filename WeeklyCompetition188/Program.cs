using System;
using System.Collections.Generic;

namespace WeeklyCompetition188
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Ways(new string[] { "A..", "AAA", "..." }, 3);
        }
        static public IList<string> BuildArray(int[] target, int n)
        {
            List<string> res = new List<string>();
            int index = 0;
            int len = target.Length;

            for(var i =0;i<=n;i++)
            {
                if (index >= len)
                    break;
                if (i == target[index])
                { 
                    res.Add("Push");
                    index++;
                }
                else
                {
                    res.Add("Push");
                    res.Add("Pop");
                }
            }
            return res;
        }
        public int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            if (!hasApple.Contains(true))
                return 0;

            
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            foreach(var edge in edges)
            {
                if (dic.ContainsKey(edge[0]))
                    dic[edge[0]].Add(edge[1]);
                else
                    dic.Add(edge[0], new List<int> { edge[1] });
            }
            return MinTimeHelp(0, dic, hasApple);
        }
        public int MinTimeHelp(int node, Dictionary<int, List<int>>dic, IList<bool> hasApple)
        {
            
            if (dic.ContainsKey(node))
            {
                int res = 0;
                foreach(var subnode in dic[node])
                {
                    res += MinTimeHelp(subnode, dic, hasApple);
                }
                if(node == 0)
                {
                    return res;
                }
                else
                {
                    if (res == 0)
                        res += hasApple[node] == true ? 2 : 0;
                    else
                        res += 2;
                    return res;
                }
            }
            else
                return hasApple[node]==true?2:0;
        }

        public int CountTriplets(int[] arr)
        {
            int n = arr.Length;
            int[,] dp = new int[n,n];//dp[a,b]=>包括arr[a],arr[b]
            for (var a=0;a<n;a++)
            {
                for(var b = a; b<n;b++)
                {
                    if (a == b)
                        dp[a, b] = arr[a];
                    else
                        dp[a, b] = dp[a, b - 1] ^ arr[b];
                }
            }
            int res = 0;
            for(var j = 1; j<=n;j++)
            {
                for(var i = 0; i<j;i++)
                {
                    for(var k=j;k<n;k++)
                    {
                        if (dp[i, j - 1] == dp[j, k])
                            res += 1;
                    }
                }
            }
            return res;
        }
        static public int Ways(string[] pizza, int k)
        {
            var row = pizza.Length;
            var col = pizza[0].Length;
            var piz_arr = new int[row, col];
             
            for(var line =row-1; line >=0; line--)
            {
                var piz_row = new int[col];
                for (var c = col - 1; c >= 0; c--)
                {
                    if (c == col - 1)
                        piz_row[c] = pizza[line][c] == 'A' ? 1 : 0;
                    else
                        piz_row[c]= piz_row[c+1] + (pizza[line][c] == 'A' ? 1 : 0);

                    if (line == row - 1)
                        piz_arr[line, c] = piz_row[c];
                    else
                        piz_arr[line, c] = piz_arr[line + 1, c] + piz_row[c];
                }
            }
            return WaysHelp(piz_arr, k, 0, 0, row, col);

        }
        static public int WaysHelp(int[,]piz_arr, int size,int line, int c, int row, int col)
        {
            if (line >= row || c >= col)
                return 0;
            if (piz_arr[line, c] < size)
                return 0;
            if (size == 0)
                return 1;


            int res = 0;
            for (var newline = line + 1; newline < row; newline++)
            { 
                res += WaysHelp(piz_arr, size - 1, newline, c, row, col);
                res %= 100000007;
            }

            for (var newc = c + 1; c < col; c++)
            { 
                res += WaysHelp(piz_arr, size - 1, line, newc, row, col);
                res %= 100000007;
            }
            return res;
        }
    }
}
