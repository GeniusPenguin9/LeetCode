using System;

namespace T72_Hard_String_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            var res3 = MinDistance("horse", "ros");
            var res5 = MinDistance("intention", "execution");
        }

        static public int MinDistance(string word1, string word2)
        {
            var n1 = word1.Length;
            var n2 = word2.Length;
            var dp = new int[n1 + 1, n2 + 1];
            dp[0, 0] = 0;
            for (var i = 1; i < n1 + 1; i++)
                dp[i, 0] = dp[i - 1, 0] + 1;
            for (var i = 1; i < n2 + 1; i++)
                dp[0, i] = dp[0, i - 1] + 1;

            for(var i = 1;i<n1+1;i++)
            {
                for(var j = 1;j<n2+1;j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j - 1], dp[i - 1, j]), dp[i, j - 1]) + 1;
                }
            }
            return dp[n1,n2];
        }
    }
}
