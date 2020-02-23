using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DoubleWeeklyCompetition20
{
    class Program
    {
        static void Main(string[] args)
        {
            ////[0,1,2,4,8,3,5,6,7]
            //var res1 = SortByBits(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

            ////[1,2,4,8,16,32,64,128,256,512,1024]
            //var res2 = SortByBits(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 });

            ////[10000,10000]
            //var res3 = SortByBits(new int[] { 10000, 10000 });

            ////[2,3,5,17,7,11,13,19]
            //var res4 = SortByBits(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

            ////[2,3,5,17,7,11,13,19]
            //var res5 = SortByBits(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

            ////[10,100,10000,1000]
            //var res6 = SortByBits(new int[] { 10, 100, 1000, 10000 });

            //var res10 = NumberOfSubstrings("abcabc");
            //var res3 = NumberOfSubstrings("aaacb");
            //var res1 = NumberOfSubstrings("abc");

            var res90 = CountOrders(3);
            var res6 = CountOrders(2);
            //368349166
            var resx = CountOrders(18);
        }
        public static int[] SortByBits(int[] arr)
        {
            var res = arr.OrderBy(i => CalOne(i)).ThenBy(i => i).ToArray();
            return res;
        }

        public static int CalOne(int x)
        {
            int count = 0;
            for(int i=31;i>=0;i--)
            {
                int mask = 1 << i;
                count += (x & mask) != 0 ? 1 : 0;
            }
            return count;
        }

        public static int NumberOfSubstrings(string s)
        {

            if (s.Length <= 2)
                return 0;
            else
            {
                var res = 0;
                var a = -1;
                var b = -1;
                var c = -1;
                for(var i = 0; i<s.Length-2;i++)
                {
                    if(a < i)
                        a = Findindex(s, 'a', i);
                    if(b<i)
                        b = Findindex(s, 'b', i);
                    if(c<i)
                        c = Findindex(s, 'c', i);
                    if (a != -1 && b != -1 && c != -1)
                        res += s.Length - Math.Max(a, Math.Max(b, c));
                }
                return res;
            }
                
        }
        public static int Findindex(string s, char x, int start_index)
        {
            for(var i = start_index; i< s.Length;i++)
            {
                if (s[i] == x)
                    return i;
            }
            return -1;
        }


        public static int CountOrders(int n)
        {
            BigInteger x = n;
            if (n == 1)
                return 1;
            else
            {
                var res = CountOrders2(x);
                return (int)(res % (BigInteger)(Math.Pow(10, 9) + 7));
            }

        }
        public static BigInteger CountOrders2(BigInteger n)
        {
            if (n == 1)
                return 1;
            else
                return n * (CountOrders2(n - 1) * ((n - 1) * 2 + 1));
        }
    }

    public class Cashier
    {
        private int num;
        private int n;
        private int discount;
        private Dictionary<int, int> dic;//product,price
        public Cashier(int n, int discount, int[] products, int[] prices)
        {
            this.num = 0;
            this.n = n;
            this.discount = discount;
            this.dic = new Dictionary<int, int>();
            for(var i = 0; i < products.Length;i++)
            {
                dic.Add(products[i], prices[i]);
            }
        }

        public double GetBill(int[] product, int[] amount)
        {
            double res = 0;
            double sumres = 0;

            for(var i = 0; i<product.Length;i++)
            {
                sumres += dic[product[i]] * amount[i];
            }

            this.num++;
            if(this.num==this.n)
            {
                res = sumres - (this.discount * sumres) / 100;
                this.num = 0;
            }
            else
            {
                res = sumres;
            }
            return res;
        }
    }
}
