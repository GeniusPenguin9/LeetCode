using System;

namespace T188_Hard_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res15 = MaxProfit(4, new int[] { 1,2,4,2,5,7,2,4,9,0});
        }

        public static int MaxProfit(int k, int[] prices)
        {
            if (k >= prices.Length / 2)
                return MaxProfitWithoutK(prices);
            if (prices.Length <= 1 || k <= 0)
                return 0;

            //第0~k-1天，0~k笔已经发生的最大交易数（buy的时刻+1），两种状态（0未持有/1持有）
            var dp = new int[prices.Length, k + 1, 2];

            for (var maxbuy = 0; maxbuy <= k; maxbuy++)
            {
                dp[0, maxbuy, 0] = 0;
                dp[0, maxbuy, 1] = maxbuy == 0 ? int.MinValue : -prices[0]; //第0天持有，maxbuy = 1~k次全都赋值，因为最优解不一定是把k次用完的
            }

            for (var day = 1; day < prices.Length; day++)
            {
                for(var maxbuy = 1; maxbuy <= k; maxbuy++)
                {
                    dp[day, maxbuy, 0] = Math.Max(dp[day - 1, maxbuy, 0], dp[day - 1, maxbuy, 1] + prices[day]);//继续未持有 OR 当天卖出
                    dp[day, maxbuy, 1] = Math.Max(dp[day - 1, maxbuy, 1], dp[day - 1, maxbuy - 1, 0] - prices[day]);//继续未持有 OR 当天买入（+1交易）
                }
            }
            return dp[prices.Length - 1, k, 0];
        }
        private static int MaxProfitWithoutK(int[] prices)
        {
            var dp_unhold = 0;
            var dp_hold = int.MinValue;
            for(var i = 0; i < prices.Length; i++)
            {
                var temp = dp_hold;
                dp_hold = Math.Max(dp_hold, dp_unhold - prices[i]);
                dp_unhold = Math.Max(dp_unhold, temp + prices[i]);
            }
            return dp_unhold;
        }
    }
}
