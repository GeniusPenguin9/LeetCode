using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WeeklyCompetition182
{
    class Program
    {
        static void Main(string[] args)
        {
            var res2 = FindLucky(new int[] { 2, 2, 3, 4 });
            var res3= FindLucky(new int[] { 1, 2, 2, 3, 3, 3 });
            var res_1= FindLucky(new int[] { 2, 2, 2, 3, 3 });
            var res_2= FindLucky(new int[] { 5 });
            var res7= FindLucky(new int[] { 7, 7, 7, 7, 7, 7, 7 });
        }
        static public int FindLucky(int[] arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(var i in arr)
            {
                if (dic.ContainsKey(i))
                    dic[i] += 1;
                else
                    dic.Add(i, 1);
            }
            var ls = new List<int>();
            foreach(var i in dic.Keys)
            {
                if (dic[i] == i)
                    ls.Add(i);
            }
            return ls.Count > 0 ? ls.Max() : -1;
        }

        public class UndergroundSystem
        {
            Dictionary<int, Tuple<string, int>> CurrentCustom;//id,<inname,intime>
            Dictionary<Tuple<string, string>, List<int>> Time;//<start,end><time1,time2,...>
            public UndergroundSystem()
            {
                CurrentCustom = new Dictionary<int, Tuple<string, int>>();
                Time = new Dictionary<Tuple<string, string>, List<int>>();
            }

            public void CheckIn(int id, string stationName, int t)
            {
                CurrentCustom.Add(id, new Tuple<string, int>(stationName, t));
            }

            public void CheckOut(int id, string stationName, int t)
            {
                var instation = CurrentCustom[id].Item1;
                var intime = CurrentCustom[id].Item2;
                CurrentCustom.Remove(id);
                if (Time.ContainsKey(new Tuple<string, string>(instation, stationName)))
                    Time[new Tuple<string, string>(instation, stationName)].Add(t - intime);
                else
                    Time.Add(new Tuple<string, string>(instation, stationName), new List<int> { t - intime });
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                var timels = Time[new Tuple<string, string>(startStation, endStation)];
                return timels.Average();
            }
        }

        public double NumBetweenStrings(int n, string s1, string s2)
        {
            double res = 0;
            for(var i = 0; i < n; i++)
            {
                res += (s2[i] - s1[i]) * MyPow(26, n - i - 1);
                
                if (res < 0)
                    return 0;

                res %= 1000000007;
            }
            return res;
        }
        public double MyPow(int x, int y)
        {
            var res = 1;
            for(var i = 1; i <= y; i++)
            {
                res *= x;
                res %= 1000000007;
            }
            return res;
        }
    }
}
