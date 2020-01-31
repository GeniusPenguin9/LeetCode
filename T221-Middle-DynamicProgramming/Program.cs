using System;

namespace T221_Middle_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            var res = 0;
            var row = matrix.Length;
            var colum = matrix[0].Length;
            int[][] dp = new int[row][];
            for (var i = 0; i < row; i++)
                dp[i] = new int[colum];

            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < colum; j++)
                {
                    if (matrix[i][j] == '0')
                        dp[i][j] = 0;
                    else
                    {
                        if (i == 0 || j == 0)
                            dp[i][j] = 1;
                        else
                            dp[i][j] = Math.Min(Math.Min(dp[i][j - 1], dp[i - 1][j]), dp[i - 1][j - 1]) + 1;
                        res = Math.Max(res, dp[i][j] * dp[i][j]);
                    }
                }
            }
            return res;
        }
    }
}
