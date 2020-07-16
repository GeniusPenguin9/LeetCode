using System;
using System.Collections.Generic;
using System.Linq;

namespace T312_Hard_DivideAndConquer_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res35 = MaxCoins(new int[] { 3,1,5 });
            var res167 = MaxCoins(new int[] { 3, 1, 5, 8 });
            var res12 = MaxCoins(new int[] { 1,0, 2, 3 });
            var res1358 = MaxCoins(new int[] { 7, 9, 8, 0, 7, 1, 3, 5 });
        }
        public static int MaxCoins(int[] nums)
        {
            var nums_ls = nums.ToList();
            nums_ls.Insert(0, 1);
            nums_ls.Add(1);
            var len = nums_ls.Count();

            //dp[start,end]代表从start到end范围可获得最大硬币，其中start&end为虚拟气球
            //包括start&end的气球个数=contains
            var dp = new int[len, len];
            for (var i = 0; i < len - 1; i++)
                dp[i,i + 1] = 0;

            for(var contains = 3; contains <= len; contains++)
            {
                for(var start = 0; start <= len - contains; start++)
                {
                    var end = start + contains - 1;
                    var max = 0;
                    for(var take = start + 1; take < end; take++)
                    {
                        max = Math.Max(max, dp[start, take] + nums_ls[start] * nums_ls[take] * nums_ls[end] + dp[take, end]);
                    }
                    dp[start, end] = max;
                }
            }
            return dp[0, len - 1];
        }

        //private static int maxCoins(List<int> nums, int leftVal, int rightVal)
        //{
        //    if (nums.Count == 0)
        //        return 0;
        //    else if (nums.Count == 1)
        //    {
        //        return nums[0];
        //    }
        //    else
        //    {
        //        var count = nums.Count;
        //        var max = Math.Max(leftVal * nums[0] * nums[1] + maxCoins(nums.Skip(1).ToList(), leftVal, rightVal),
        //                          nums[count - 2] * nums[count - 1] * rightVal + maxCoins(nums.Take(count - 1).ToList(), leftVal, rightVal));
        //        for (var i = 1; i < count - 1; i++)
        //        {
        //            var takei = nums[i - 1] * nums[i] * nums[i + 1] +
        //                            maxCoins(nums.Take(i).Union(nums.Skip(i + 1).Take(count - i - 1)).ToList(), leftVal, rightVal);
        //            max = Math.Max(max, takei);
        //            Console.WriteLine("nums = {0},take element = {1}, takei={2},max = {2}",string.Join(',',nums), nums[i],takei, max);
        //        }

        //        return max;
        //    }
        //}
    }

}
