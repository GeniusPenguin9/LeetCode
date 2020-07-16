using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace WeeklyCompetition183
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = MinSubsequence(new int[] { 4, 3, 10, 9, 8 });
            //var b = MinSubsequence(new int[] { 4, 4, 7, 6, 7 });
            //var c = MinSubsequence(new int[] { 6});

            var res = LongestDiverseString(1, 1, 7);
            var res2 = LongestDiverseString(2, 2, 1);
            var res3 = LongestDiverseString(7, 1, 0);
        }

        static public IList<int> MinSubsequence(int[] nums)
        {
            Array.Sort(nums);
            var newnums = nums.Reverse().ToList();

            var sum = newnums.Sum();
            var sum2 = 0;
            for(var i = 0; i < newnums.Count(); i++)
            {
                sum2 += newnums[i];
                if (sum2 > sum / 2)
                    return newnums.ToList().Take(i + 1).ToList();
            }
            
                return newnums.ToList();
        }

        static public BigInteger convertBinaryToDecimal(BigInteger n)
        {
            BigInteger decimalNumber = 0,  remainder;
            int i = 0;
            while (n != 0)
            {
                remainder = n % 10;
                n /= 10;
                decimalNumber += remainder * (BigInteger)Math.Pow(2, i);
                ++i;
            }
            return decimalNumber;
        }

         public int NumSteps(string s)
        {
            BigInteger i = BigInteger.Parse(s);
            BigInteger newi = convertBinaryToDecimal(i);
            int step = 0;
            while (newi != 1)
            {
                if (newi % 2 == 0)
                {
                    newi /= 2;
                }
                else
                {
                    newi += 1;
                }
                step++;
            }
            return step;
        }

        static public string LongestDiverseString(int a, int b, int c)
        {
            List<char> res = new List<char>();

            var count = new List<int> { (a + 1) / 2, (b + 1) / 2, (c + 1) / 2 };
            var num = new List<int> { a, b, c };
            var chr = new char[] { 'a', 'b', 'c' };
            var index = count.IndexOf(count.Max());
            var minindex = count.LastIndexOf(count.Min());
            var midindex = 3 - index - minindex;
            while(true)
            {
                if (num[index] > 0)
                { res.Add(chr[index]); num[index]--; }
                if (num[index] > 0)
                { res.Add(chr[index]); num[index]--; }
                if (num[midindex] > 0)
                { res.Add(chr[midindex]); num[midindex]--; }
                if (num[index] > 0)
                { res.Add(chr[index]); num[index]--; }
                if (num[index] > 0)
                { res.Add(chr[index]); num[index]--; }
                if (num[minindex] > 0)
                { res.Add(chr[minindex]); num[minindex]--; }

                if (num.Sum() == 0)
                    break;
            }
            string pattern = @"(a+|b+|c+)$";
            
            var str = new string(res.ToArray());

            var match = Regex.Match(str, pattern);

            var cutlen = match.Length > 2?match.Length - 2:0;
            return str.Substring(0,str.Length-cutlen);
        }
        //static public string StoneGameIII(int[] stoneValue)
        //{
        //    var sum = stoneValue.Sum();
        //    var n = stoneValue.Length;
        //    var dp_hold_1 = new int[n];
        //    var dp_hold_2 = new int[n];
        //    var dp_hold_3 = new int[n];
        //    var dp_unhold = new int[n];

        //    var b_unhold = new int[n];
        //    var b_hold_1=new int[n];
        //    var b_hold_2= new int[n];
        //    var b_hold_3= new int[n];

        //    dp_hold_1[0] = stoneValue[0];
        //    dp_hold_2[0] = 0;
        //    dp_hold_3[0] = 0;
        //    dp_unhold[0] = 0;

        //    b_unhold[0] = 0;
        //    b_hold_1[0] = 0;
        //    b_hold_2[0] = 0;
        //    b_hold_3[0] = 0;

        //    for (var i = 1;i < n;i++)
        //    {

        //        dp_hold_1[i] = dp_unhold[i - 1] + stoneValue[i];
        //        dp_hold_2[i] = dp_hold_1[i - 1] + stoneValue[i];
        //        dp_hold_3[i] = dp_hold_2[i - 1] + stoneValue[i];
        //        dp_unhold[i] = 
        //    }
        //    var alicemax = Math.Min(Math.Min(dp_unhold[n - 1], dp_hold_1[n - 1]), Math.Min(dp_hold_2[n - 1], dp_hold_3[n - 1]));
        //    if (alicemax > (sum - alicemax))
        //        return "Alice";
        //    else if (alicemax == (sum - alicemax))
        //        return "Tie";
        //    else
        //        return "Bob";
        //}


    }
}
