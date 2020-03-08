using System;

namespace T123_Hard_Array_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxProfit(int[] prices)
        {
            //第0~n-1天，已经最多完成的笔数，是否持有
            //交易以买入时刻计算
            var dp_max1_unhold = 0;
            var dp_max1_hold = int.MinValue;
            var dp_max2_unhold = 0;
            var dp_max2_hold = int.MinValue;

            for (var i = 0; i < prices.Length; i++)
            {
                dp_max1_unhold = Math.Max(dp_max1_unhold, dp_max1_hold + prices[i]);//持续未持有状态 OR 当天卖出
                dp_max1_hold = Math.Max(dp_max1_hold, -prices[i]);//持续持有 OR 当天买入(之前交易数=0）
                dp_max2_unhold = Math.Max(dp_max2_unhold, dp_max2_hold + prices[i]);//持续未持有状态 OR 当天卖出
                dp_max2_hold = Math.Max(dp_max2_hold, dp_max1_unhold - prices[i]);//持续持有 OR 当天买入(之前交易数=1）
            }
            return dp_max2_unhold;
        }
    }
}
