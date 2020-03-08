using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WeeklyCompetition179
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res3 = NumTimesAllBlue(new int[] { 2, 1, 3, 5, 4 });
            //var res2 = NumTimesAllBlue(new int[] { 3, 2, 4, 1, 5 });
            //var res1 = NumTimesAllBlue(new int[] { 4, 1, 2, 3 });
            //var res3_2 = NumTimesAllBlue(new int[] { 2, 1, 4, 3, 6, 5 });
            //var res6= NumTimesAllBlue(new int[] { 1, 2, 3, 4, 5, 6 });

            //var res0 = NumOfMinutes(1, 0, new int[] { -1 }, new int[] { 0 });
            //var res1 = NumOfMinutes(6, 2, new int[] { 2, 2, -1, 2, 2, 2 }, new int[] { 0, 0, 1, 0, 0, 0 });
            //var res21 = NumOfMinutes(7, 6, new int[] { 1, 2, 3, 4, 5, 6, -1 }, new int[] { 0, 6, 5, 4, 3, 2, 1 });
        }
        public static string GenerateTheString(int n)
        {
            if (n % 2 == 1)
                return new string(Enumerable.Repeat('a', n).ToArray());
            else
                return new string(Enumerable.Repeat('a', n-1).ToArray()+"b");
        }

        public static int NumTimesAllBlue(int[] light)
        {
            BigInteger res = 0;
            BigInteger sum = 0;
            for(BigInteger i = 0; i < light.Length; i++)
            {
                sum = sum + light[(int)i];
                if (sum == (i+1)*(1+i+1)/2)
                    res++;
            }
            return (int)res;
        }

        ////超时QAQ
        //public static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        //{
        //    var engineerID = new List<int>();
        //    for (var i = 0; i < manager.Length; i++)
        //    {
        //        if (manager[i] == headID)
        //            engineerID.Add(i);
        //    }
        //    var time = 0;
        //    foreach(var engineer in engineerID)
        //    {
        //        time = Math.Max(time, informTime[headID] + NumOfMinutes(n, engineer, manager, informTime));
        //    }
        //    return time;
        //}

        
        //参考题解，从底部开始的全遍历，无需递归
        public static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            var res = 0;
            for(var i = 0; i < manager.Length; i++)
            {
                if(informTime[i] == 0)
                {
                    var time = 0;
                    int head = i;
                    while(head!=-1)
                    {
                        time += informTime[head];
                        head = manager[head];
                    }
                    res = Math.Max(res, time);
                }
            }
            return res;
        }

        //fail QAQ
        public double FrogPosition(int n, int[][] edges, int t, int target)
        {
            double res = 1;
            var edgesList = edges.ToList();

            var targetlist = new List<int> { target};
            var fromlist = new List<int>();
            foreach(var edge in edgesList)
            {
                if (targetlist.Contains(edge[0]))
                {
                    fromlist.Add(edge[1]);
                    edgesList.Remove(edge);
                }  
                else if (targetlist.Contains(edge[1]))
                {
                    fromlist.Add(edge[0]);
                    edgesList.Remove(edge);
                }
            }
            res /= fromlist.Count;
        }
    }
}
