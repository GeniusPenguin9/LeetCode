using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WeeklyCompetition180
{
    class Program
    {
        static void Main(string[] args)
        {
            var res60 = MaxPerformance(6, new int[] { 2, 10, 3, 1, 5, 8 }, new int[] { 5, 4, 3, 9, 7, 2 }, 2);
            var res56=MaxPerformance(3, new int[] { 2, 8, 2 }, new int[] { 2, 7, 1 }, 2);
            var res51 = MaxPerformance(4, new int[] { 2, 5, 5, 5 }, new int[] { 3, 3, 3, 5 }, 4);
            var res80 = MaxPerformance(3, new int[] { 4, 6, 8 }, new int[] { 4, 5, 10 },4);

//            4
//[2, 5, 5, 5]
//[3, 3, 3, 5]
//4


                //3
                //[2, 8, 2]
                //[2, 7, 1]
                //2
        }

        public static IList<int> LuckyNumbers(int[][] matrix)
        {
            List<int> res = new List<int>();
            var m = matrix.Length;
            var n = matrix[0].Length;
            var dpm = Enumerable.Repeat(0, m).ToArray();
            var dpn = Enumerable.Repeat(10001, n).ToArray();
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    dpm[i] = Math.Min(dpm[i], matrix[i][j]);
                    dpn[j] = Math.Max(dpn[j], matrix[i][j]);
                }
            }
            foreach(var item in dpm)
            {
                if (dpn.Contains(item))
                    res.Add(item);
            }
            Console.WriteLine(string.Join(',', dpm));
            Console.WriteLine(string.Join(',', dpn));
            return res;
        }
        public static int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            if (k >= n)
            {
                BigInteger max = 0;
                //dp[i,k,s]=>截至第1~i个工程师，k=0：不带第i个，k=1:带第i个；s=0;速度和，s=1:效率最小值，s=2团队表现
                var dp = new BigInteger[n, 2, 3];
                for (var s = 0; s < 3; s++)
                {
                    dp[0, 0, s] = 0;
                }
                dp[0, 1, 0] = speed[0];
                dp[0, 1, 1] = efficiency[0];
                dp[0, 1, 2] = dp[0, 1, 0] * dp[0, 1, 1];
                max = dp[0, 1, 2];

                for (var i = 1; i < n; i++)
                {

                    dp[i, 0, 0] = dp[i - 1, 0, 2] > dp[i - 1, 1, 2] ? dp[i - 1, 0, 0] : dp[i - 1, 1, 0];
                    dp[i, 0, 1] = dp[i - 1, 0, 2] > dp[i - 1, 1, 2] ? dp[i - 1, 0, 1] : dp[i - 1, 1, 1];
                    dp[i, 0, 2] = dp[i - 1, 0, 2] > dp[i - 1, 1, 2] ? dp[i - 1, 0, 2] : dp[i - 1, 1, 2];
                    max = max > dp[i, 0, 2] ? max : dp[i, 0, 2];

                    dp[i, 1, 0] = dp[i, 0, 0] + speed[i];
                    dp[i, 1, 1] = dp[i, 0, 1] < efficiency[i] ? dp[i, 0, 1] : efficiency[i];
                    dp[i, 1, 2] = dp[i, 1, 0] * dp[i, 1, 1];
                    max = max > dp[i, 1, 2] ? max : dp[i, 1, 2];

                }
                return (int)(max % 1000000007);
            }
            else
            {
                BigInteger max = 0;
                   //dp[i,k,s]=>截至第1~i个工程师，t=最多已经带了t个人；s=0;速度和，s=1:效率最小值，s=2团队表现
                   var dp = new BigInteger[n+1, k + 1, 3];

                for (var t = 0; t < k + 1; t++)
                {
                        dp[0, t, 0] = 0;
                        dp[0, t, 1] = 0;
                        dp[0, t, 2] = 0;
                }


                for (var i = 1; i < n+1; i++)
                {
                    for (var t = 0; t < k + 1; t++)
                    {
                        if (t == 0)
                        {
                            dp[i, t, 0] = dp[i - 1, 0, 0];
                            dp[i, t, 1] = dp[i - 1, 0, 1];
                            dp[i, t, 2] = dp[i - 1, 0, 2];
                        }
                        else
                        {
                            var spd = dp[i - 1, t - 1, 0] + speed[i-1];
                            var eff = (dp[i - 1, t - 1, 1] > 0 && dp[i - 1, t - 1, 1] < efficiency[i-1]) ? dp[i - 1, t - 1, 1] : efficiency[i-1];
                            var temp = spd * eff;
                            if (temp > dp[i - 1, t, 2])
                            {
                                dp[i, t, 0] = spd;
                                dp[i, t, 1] = eff;
                                dp[i, t, 2] = temp;
                            }
                            else
                            {
                                dp[i, t, 0] = dp[i - 1, t, 0];
                                dp[i, t, 1] = dp[i - 1, t, 1];
                                dp[i, t, 2] = dp[i - 1, t, 2];
                            }
                        }
                        max = max>dp[i, t, 2]?max: dp[i, t, 2];
                    }

                }

                return (int)(max% 1000000007);
            
            }
        }
        public class CustomStack
        {
            public int[] arr;
            public int maxSize;
            public int realsize;    //=1,[0]
            public CustomStack(int maxSize)
            {
                realsize = 0;
                this.maxSize = maxSize;
                arr = new int[maxSize];
            }

            public void Push(int x)
            {
                if(realsize<maxSize)
                {
                    arr[realsize] = x;
                    realsize++;
                }
            }

            public int Pop()
            {
                if (realsize > 0)
                {
                    realsize--;
                    return arr[realsize];
                }
                else
                    return -1;
            }

            public void Increment(int k, int val)
            {
                var inc = Math.Min(k, realsize);
                for (var i = 0; i < inc; i++)
                    arr[i] += val;
            }
        }
    }
}
