using System;

namespace T714_Middle_Greedy_Array_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res8 = MaxProfit(new int[] { 1, 3, 2, 8, 4, 9 }, 2);
        }

        public static int MaxProfit(int[] prices, int fee)
        {
            var dp_hold = int.MinValue;
            var dp_unhold = 0;
            for(var i = 0; i < prices.Length; i++)
            {
                var temp = dp_hold;
                dp_hold = Math.Max(dp_hold, dp_unhold - prices[i] - fee);
                dp_unhold = Math.Max(dp_unhold, dp_hold + prices[i]);
            }
            return dp_unhold;
        }
    }
}
