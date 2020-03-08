using System;

namespace T322_Middle_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res3 = CoinChange(new int[] { 1, 2, 5 }, 11);
            var res_1 = CoinChange(new int[] { 2 }, 3);
            var res20=CoinChange(new int[] { 186, 419, 83, 408 }, 6249);
        }
        public static int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount+1]; //dp[i]即：总金额为i时，需要硬币的数量
            dp[0] = 0;
            for(var i = 1; i<amount+1;i++)
            {
                dp[i] = -1;

                foreach(var coin in coins)
                {
                    if (i - coin >= 0 && dp[i - coin] != -1)
                    {
                        if (dp[i] == -1)
                            dp[i] = dp[i - coin] + 1;
                        else
                            dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }
            return dp[amount];
        }
    }
}
