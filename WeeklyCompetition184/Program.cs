using System;
using System.Collections.Generic;
using System.Linq;


namespace WeeklyCompetition184
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static public int[] ProcessQueries(int[] queries, int m)
        {
            var res = Enumerable.Range(1,m).ToList();
            var resindex = new List<int>();
            for(var i = 0; i < queries.Length; i++)
            {
                var target = queries[i];
                var index = res.IndexOf(target);
                res.RemoveAt(index);
                res.Insert(0, target);
                resindex.Add(index);
            }
            return resindex.ToArray();
        }
        public int NumOfWays(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 12;
            var temp = 1000000007;
            long  repeat = 6;
            long  unrepeat = 6;
            for(int i = 2; i <=n; i++)
            {
                long  newrep = (repeat * 3) % temp + unrepeat * 2 % temp;
                long  newunrep = repeat * 2 % temp + unrepeat * 2 % temp;
                repeat = newrep;
                unrepeat = newunrep;
            }
            return (int)((repeat + unrepeat)%temp);
        }
    }
    
}
