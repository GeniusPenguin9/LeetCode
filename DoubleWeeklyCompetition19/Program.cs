using System;
using System.Collections.Generic;

namespace DoubleWeeklyCompetition19
{
    class Program
    {
        static void Main(string[] args)
        {
            var res3 = MinJumps(new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 });
            var res3_1 = MinJumps(new int[] { 11, 22, 7, 7, 7, 7, 7, 7, 7, 22, 13 });

        }
        public static int NumberOfSteps(int num)
        {
            var count = 0;
            while(num != 0)
            {
                if (num % 2 == 1)
                    num -= 1;
                else
                    num /= 2;

                count++;
            }
            return count;
        }

        public static int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            if (arr == null || arr.Length < k)
                return 0;
            else
            {
                if (threshold == 0)
                    return arr.Length-k+1;
                var sum_thr = k * threshold;
                var res = 0;

                var tempsum = 0;
                for (var i = 0; i < k; i++)
                    tempsum += arr[i];

                if (tempsum >= sum_thr)
                    res++;
                tempsum -= arr[0];

                for(var i = 1; i < arr.Length-k+1;i++)
                {
                    tempsum += arr[i + k - 1];
                    if (tempsum >= sum_thr)
                        res++;
                    tempsum -= arr[i];
                }
                return res;

            }
        }

        public static double AngleClock(int hour, int minutes)
        {
            if (hour == 12)
                hour = 0;
            
            double angle_min = minutes * 6 ;
            double angle_hour = hour * 30 + 30*((double)minutes/60);
            double res = Math.Abs(angle_hour - angle_min);
            if (res >= 180)
                res = 360 - res;

            return res;
        }

        public static int MinJumps(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                return 0;
            if (arr.Length == 2 || arr[arr.Length-1] == arr[0])
                return 1;

            var dp = new int[arr.Length];
            var step = 0;
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();  //element, List(index)
            for(var i = 0; i < arr.Length;i++)
            {
                if (dic.ContainsKey(arr[i]))
                    dic[arr[i]].Add(i);
                else
                    dic.Add(arr[i], new List<int> { i });
            }

            Queue<int> q = new Queue<int>();//index
            q.Enqueue(0);
            q.Enqueue(-1);
            while(q.Count>0 && dic.Count>0)
            {
                var index = q.Dequeue();

                if (index == arr.Length - 1)
                    break;

                if (index == 0)
                {
                    dp[index] = 0;
                    q.Enqueue(1);
                    foreach(var temp in dic[arr[index]])
                    {
                        if (temp != index && dp[temp] == 0)
                            q.Enqueue(temp);
                    }
                    dic.Remove(arr[0]);
                    q.Enqueue(-1);
                    continue;
                }

                if (index == -1)
                { 
                    step++;
                    continue;
                }
                dp[index] = step;
                if (index >= 1 && dp[index - 1] != 0)
                    q.Enqueue(index - 1);
                if (index <= arr.Length - 2 && dp[index + 1] != 0)
                    q.Enqueue(index + 1);
                if(dic.ContainsKey(arr[index]))
                {
                    foreach (var temp in dic[arr[index]])
                    {
                        if (temp != index && dp[temp] == 0)
                            q.Enqueue(temp);
                    }
                    dic.Remove(arr[index]);
                }

                
            }

            return step;
        }
    }
}
