using System;
using System.Collections.Generic;

namespace T300_Middle_BinarySearch_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res4 = LengthOfLIS(new int[] { 2, 10, 3, 4, 5 });
            var res4_2 = LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            var res6 = LengthOfLIS(new int[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 });
        }

        //O(n^2)
        //public static int LengthOfLIS(int[] nums)
        //{
        //    if (nums.Length <= 1)
        //        return nums.Length;

        //    int[] dp = new int[nums.Length];
        //    dp[0] = 1;
        //    var res = 1;
        //    for(var i = 1; i < nums.Length; i++)
        //    {
        //        dp[i] = 1;
        //        for(var j = 0; j < i; j++)
        //        {
        //            if (nums[j] < nums[i])
        //                dp[i] = Math.Max(dp[i], dp[j] + 1);
        //        }
        //        res = Math.Max(res, dp[i]);
        //    }
        //    return res;
        //}

        public static int LengthOfLIS(int[] nums)
        {
            List<int> ls = new List<int>();
            foreach(var num in nums)
            {
                Replace(ls, num);
            }
            return ls.Count;
        }
        private static void Replace(List<int>ls, int num)
        {
            if (ls.Count == 0 || ls[ls.Count - 1] < num)
                ls.Add(num);
            else
            {
                var left = 0;
                var right = ls.Count - 1;
                var mid = 0;
                while (left != right )
                {
                    mid = (left + right) / 2;
                    if (ls[mid] == num)
                        return;
                    else if (ls[mid] < num)
                    {
                        left = mid+1;
                    }
                    else
                        right = mid;
                }
                ls[left] = num;
            }
        }
        
    }
}
