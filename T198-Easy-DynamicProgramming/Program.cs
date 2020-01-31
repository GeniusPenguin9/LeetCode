using System;

namespace T198_Easy_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Rob(new int[] { 1, 2, 3, 1 });
        }
        public static int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            else if (nums.Length == 1)
                return nums[0];
            else if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = nums[1];
            for(var i = 2; i < dp.Length; i++)
            {
                dp[i] = nums[i] + (i == 2 ? dp[i - 2] : Math.Max(dp[i - 2], dp[i - 3]));
            }
            return Math.Max(dp[nums.Length - 1], dp[nums.Length - 2]);
        }
    }
}
