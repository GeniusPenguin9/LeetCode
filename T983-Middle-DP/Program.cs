using System;

namespace T983_Middle_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MincostTickets(int[] days, int[] costs)
        {
            var n = days.Length;
            var maxday = days[n - 1];
            var minday = days[0];
            var dp = new int[maxday + 31];
            int i = n - 1;
            for(var day = maxday; day >= minday;day--)
            {
                if (day == days[i])
                {
                    dp[day] = Math.Min(dp[day + 1] + costs[0], Math.Min(dp[day + 7] + costs[1], dp[day + 30] + costs[2]));
                    i--;
                }
                else
                    dp[day] = dp[day + 1];
            }
            return dp[minday];
        }
    }
}
