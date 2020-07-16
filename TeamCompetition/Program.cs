using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace TeamCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res2 = SplitArray(new int[] { 2, 3, 3, 2, 3, 3 });
            //var res4 = SplitArray(new int[] { 2, 3, 5, 7 });
            //var res6 = SplitArray(new int[] { 2, 19, 7, 13, 17, 3 });
            //var res = SplitArray(new int[] { 2, 2, 2 });
            //var res1 = SplitArray(new int[] { 1 });
            //var res3 = SplitArray(new int[] { 2, 3, 6, 87, 23 });
            //var res_2 = SplitArray(new int[] { 2, 19, 7, 6, 2, 6, 13, 17, 3 });
            var res3 = MinTime(new int[] { 1, 2, 3, 3 }, 2);
            var res0 = MinTime(new int[] { 999, 9999, 999 }, 4);
        }
        static public Dictionary<Tuple<int, int, int>, int> dicTime;
        static public int MinTime(int[] time, int m)
        {
            dicTime = new Dictionary<Tuple<int, int, int>, int>();
            int n = time.Length;
            if (n <= m)
                return 0;

            return mintimehelp(time, 0, n-1, m);

        }
        static public int mintimehelp(int[] time, int startindex, int endindex, int restday)
        {
            if(dicTime.ContainsKey(new Tuple<int, int, int>(startindex, endindex, restday)))
            {
                return dicTime[new Tuple<int, int, int>(startindex, endindex, restday)];
            }
            if (endindex - startindex + 1 <= restday)
                return 0;
            var res = int.MaxValue;
            if (restday <= 0)
                return res;
            for(int curindex = startindex; curindex <= endindex; curindex++)
            {
                var today = time.Skip(startindex).Take(curindex - startindex + 1);
                var todayavg = today.Sum() - today.Max();
                if (todayavg > res)
                    continue;

                var rest = mintimehelp(time, curindex + 1, endindex, restday - 1);
                res = Math.Min(Math.Max(rest, todayavg), res);
            }
            dicTime.Add(new Tuple<int, int, int>(startindex, endindex, restday), res);
            return res;
        }

        static public int SplitArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            var n = nums.Length;
            var dp = new int[n, n];//lindex,rindex
            for (var i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }

            for (var len = 2; len <= n; len++)
            {
                for (var lindex = 0; (lindex + len) <= n; lindex++)
                {
                    var rindex = lindex + len - 1;
                    if (gcd(nums[lindex], nums[rindex]) > 1)
                        dp[lindex, rindex] = 1;
                    else
                    {
                        dp[lindex, rindex] = len;
                        for (var cur = lindex; cur < rindex; cur++)
                        {
                            dp[lindex, rindex] = Math.Min(dp[lindex, rindex], dp[lindex, cur] + dp[cur + 1, rindex]);
                        }
                    }
                }

            }

            return dp[0, n - 1];
        }


        static public int gcd(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 = num1 - num2;

                if (num2 > num1)
                    num2 = num2 - num1;
            }
            return num1;
        }
    }
}
