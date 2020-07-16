using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DoubleWeeklyCompetition24
{
    class Program
    {
        static void Main(string[] args)
        {
            //var resc = GetHappyString(1, 3);
            //var resemp = GetHappyString(1, 4);
            //var rescab = GetHappyString(3, 9);
            //var resx = GetHappyString(10, 100);
            var res2 = FindMinFibonacciNumbers(7);
            var res2_1 = FindMinFibonacciNumbers(10);
            var res3 = FindMinFibonacciNumbers(19);
            
        }
        public int MinStartValue(int[] nums)
        {
            int sum = 0;
            int min = int.MaxValue;
            foreach(var num in nums)
            {
                sum += num;
                min = Math.Min(sum, min);
            }
            if (min >= 1)
                return 0;
            else
                return min * (-1)+1;
        }

        static public int FindMinFibonacciNumbers(int k)
        {
            var fibonacci = new int[] {1,2,3
,5
,8
,13
,21
,34
,55
,89
,144
,233
,377
,610
,987
,1597
,2584
,4181
,6765
,10946
,17711
,28657
,46368
,75025
,121393
,196418
,317811
,514229
,832040
,1346269
,2178309
,3524578
,5702887
,9227465
,14930352
,24157817
,39088169
,63245986
,102334155
,165580141
,267914296
,433494437
,701408733
};
            return CoinChange(fibonacci, k);
        }
        static public int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount + 1]; //dp[i]即：总金额为i时，需要硬币的数量
            dp[0] = 0;
            for (var i = 1; i < amount + 1; i++)
            {
                dp[i] = -1;

                foreach (var coin in coins)
                {
                    if (i - coin >= 0 && dp[i - coin] != -1)
                    {
                        if (dp[i] == -1)
                            dp[i] = dp[i - coin] + 1;
                        else
                            dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }
            return dp[amount];
        }


        static public string GetHappyString(int n, int k)
        {
            var maxn = Math.Pow(3, n);//0~ 3^n - 1
            var startn = Math.Pow(3, n - 2) ;
            var resls = new List<int>();
            for(var i = startn; i < maxn; i++)
            {
                if (isHappy(i, n))
                {
                    resls.Add((int)i);
                }
            }
            if (resls.Count < k)
                return "";
            else
            {
                var num = resls[k-1];
                List<int> num3 = new List<int>();
                while (num != 0)
                {
                    num3.Add((int)num % 3);
                    num /= 3;
                }
                if (num3.Count == n - 1)
                    num3.Add(0);
                string sb ="";
                foreach( var b in num3)
                {
                    if (b == 0)
                        sb = 'a' + sb;
                    else if (b == 1)
                        sb = 'b' + sb;
                    else if (b == 2)
                        sb = 'c' + sb;
                }
                return sb;
            }
        }

        static public bool isHappy(double num,int n)
        {
            int intnum = (int)num;
            List<int> num3 = new List<int>();

            int bitcur= (int)intnum % 3;
            intnum /= 3;
            num3.Add(bitcur);

            while (intnum != 0)
            {
                if ((int)intnum % 3 == bitcur)
                    return false;

                bitcur = (int)intnum % 3;
                num3.Add(bitcur);
                intnum /= 3;
            }
            if (num3.Count == n || (num3.Count == n - 1 && bitcur != 0))
                return true;
            else
                return false;
        }

        //public int NumberOfArrays(string s, int k)
        //{

        //}
    }
}
