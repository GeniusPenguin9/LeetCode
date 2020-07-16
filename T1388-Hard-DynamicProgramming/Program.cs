using System;

namespace T1388_Hard_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxSizeSlices(int[] slices)
        {
            var n = slices.Length;
            var dp = new int[n, n/3+1,2];
            //[a,b,c]：在[0,a]范围，一共取b块时候的最大值
            //c=0不取第a块，c=1取第a块

            for(var i = 0; i<n;i++)
            {
                dp[i, 0, 0] = 0;
                dp[i, 1, 1] = slices[i];
            }
            for(var a = 1; a < n; a++)
            {
                for(var b = 0; b < a/2; b++)
                {
                    dp[a,b,0]=
                }
            }

            return Math.Max(dp[n - 1, n / 3,0], dp[n - 1, n / 3, 1]);
        }
    }
}
