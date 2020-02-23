using System;

namespace T300_Middle_BinarySearch_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = LengthOfLIS(new int[] { 2, 10, 3, 4, 5 });
            var res4 = LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
        }

        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length <= 1)
                return nums.Length;

            int[] dp = new int[nums.Length];
            dp[0] = 1;
            var res = 1;
            for(var i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for(var j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }
}
