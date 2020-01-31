using System;
using System.Linq;

namespace LeetCode_WeeklyCompetition171
{
    class Program
    {
        static void Main(string[] args)
        {
            //var f = ContainsZero(5917);
            //var t = ContainsZero(1109);
            //var t2 = ContainsZero(0);

            //var a1 = GetNoZeroIntegers(10000);
            //var a2 = GetNoZeroIntegers(1010);
            //var a3 = GetNoZeroIntegers(69);

            //var min3 = MinFlips(2, 6, 5);
            //var min1 = MinFlips(4, 2, 7);
            //var min0 = MinFlips(1, 2, 3);
            //var minunknown = MinFlips(8, 3, 5);

        }

        100
var a =[[17, 51],[33, 83],[53, 62],[25, 34],[35, 90],[29, 41],[14, 53],[40, 84],[41, 64],[13, 68],[44, 85],[57, 58],[50, 74],[20, 69],[15, 62],[25, 88],[4, 56],[37, 39],[30, 62],[69, 79],[33, 85],[24, 83],[35, 77],[2, 73],[6, 28],[46, 98],[11, 82],[29, 72],[67, 71],[12, 49],[42, 56],[56, 65],[40, 70],[24, 64],[29, 51],[20, 27],[45, 88],[58, 92],[60, 99],[33, 46],[19, 69],[33, 89],[54, 82],[16, 50],[35, 73],[19, 45],[19, 72],[1, 79],[27, 80],[22, 41],[52, 61],[50, 85],[27, 45],[4, 84],[11, 96],[0, 99],[29, 94],[9, 19],[66, 99],[20, 39],[16, 85],[12, 27],[16, 67],[61, 80],[67, 83],[16, 17],[24, 27],[16, 25],[41, 79],[51, 95],[46, 47],[27, 51],[31, 44],[0, 69],[61, 63],[33, 95],[17, 88],[70, 87],[40, 42],[21, 42],[67, 77],[33, 65],[3, 25],[39, 83],[34, 40],[15, 79],[30, 90],[58, 95],[45, 56],[37, 48],[24, 91],[31, 93],[83, 90],[17, 86],[61, 65],[15, 48],[34, 56],[12, 26],[39, 98],[1, 48],[21, 76],[72, 96],[30, 69],[46, 80],[6, 29],[29, 81],[22, 77],[85, 90],[79, 83],[6, 26],[33, 57],[3, 65],[63, 84],[77, 94],[26, 90],[64, 77],[0, 3],[27, 97],[66, 89],[18, 77],[27, 43]];
        public static int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1) 
                return -1;
            else
            {
                var newone = connections.SelectMany(i => i).Distinct();

                return n-newone.Count();
            }
        }

        public static int MinFlips(int a, int b, int c)
        {

            var a_s = Convert.ToString(a, 2).ToCharArray();
            Array.Reverse(a_s);
            var b_s = Convert.ToString(b, 2).ToCharArray();
            Array.Reverse(b_s);
            var c_s = Convert.ToString(c, 2).ToCharArray();
            Array.Reverse(c_s);
            var count = 0;
            for (var i = 0; i < Math.Max(Math.Max(a_s.Length, b_s.Length), c_s.Length); i++)
            {
                if (i >= c_s.Length || c_s[i] == '0')
                {
                    count += (i < a_s.Length && a_s[i] == '1') ? 1 : 0;
                    count += (i < b_s.Length && b_s[i] == '1') ? 1 : 0;
                }
                else
                    count += ((i >= a_s.Length || a_s[i] == '0') && (i >= b_s.Length || b_s[i] == '0')) ? 1 : 0;
            }
            return count;
        }


            public static int[] GetNoZeroIntegers(int n)
        {
            for(var first = 1; first < n; first++)
            {
                if (ContainsZero(first) == false && ContainsZero(n - first) == false)
                    return new int[] { first, n - first };
            }
            return null;
        }

        public static bool ContainsZero(int n)
        {
            string s = "" + n;
            if (s.Contains("0"))
                return true;
            else
                return false;
        }
    }
}
