using System;

namespace T309_Middle_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res3 = MaxProfit(new int[] { 1, 2, 3, 0, 2 });
        }

        //输入: [1,2,3,0,2]
        //输出: 3
        public static int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
                return 0;
            var dp_hold = int.MinValue;
            var dp_unhold = 0;
            var dp_pre_unhold = 0;
            for(var i = 0; i < prices.Length; i++)
            {
                var temp = dp_unhold;
                dp_hold = Math.Max(dp_hold, dp_pre_unhold - prices[i]); //继续持有OR前天卖出当天买入
                dp_unhold = Math.Max(dp_unhold, dp_hold + prices[i]);//继续未持有或当天卖出
                dp_pre_unhold = temp;
            }
            return dp_unhold;
        }
    }
}
