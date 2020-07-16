using System;
using System.Collections.Generic;
using System.Linq;

namespace DoubleWeeklyCompetition22
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res2 = FindTheDistanceValue(new int[] { 4, 5, 8 }, new int[] { 10, 9, 1, 8 }, 2);
            //var res2_2= FindTheDistanceValue(new int[] { 1, 4, 2, 3 }, new int[] { -4, -3, 6, 10, 20, 30 }, 3);
            //var res1=FindTheDistanceValue(new int[] { 2, 1, 100, 3 }, new int[] { -5, -2, 10, -3, 7 }, 6);

            //var res13 = GetKth(12, 15, 2);
            //var res1 = GetKth(1, 1, 1);
            //var res7 = GetKth(7, 11, 4);
            //var res13_2 = GetKth(10, 20, 5);
            //var res570 = GetKth(1, 1000, 777);
            int[][] arr = new int[3][];
            arr[0] = new int[] { 2, 1 };
            arr[1] = new int[] { 1, 8 };
            arr[2] = new int[] { 2, 6 };
            var res2 = MaxNumberOfFamilies(2, arr);
        }

        public int MaxSizeSlices(int[] slices)
        {
            var sliceslist = slices.ToList();
            var res = 0;
            while(true)
            {
                var max = sliceslist.Max();
                var maxindex = sliceslist.IndexOf(max);
                var lindex = maxindex == 0 ? sliceslist.Count - 1 : maxindex - 1;
                var rindex = maxindex == sliceslist.Count - 1 ? 0 : maxindex + 1;
                var other = slices.OrderBy(i => i).Skip(1).Take(2).Sum();
                if(sliceslist [lindex] + sliceslist [rindex]== other && other > max)
                {
                    if(sliceslist[lindex] > sliceslist[rindex])
                    { 
                        res += l;
                        sliceslist.Remove(l);
                        sliceslist.RemoveAt(maxindex);
                        sliceslist.RemoveAt(maxindex);
                    }
                    else
                    {
                        res += r;
                        sliceslist.Remove(r);
                    }
                }
                else
                {
                    res += max;
                    sliceslist.Remove
                }
            }
        }

        

        public static int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            var res = 0;
            
            foreach(var a1 in arr1)
            {
                res += 1;
                foreach(var a2 in arr2)
                {
                    if (Math.Abs(a1 - a2) <= d)
                    {
                        res -= 1;
                        break;
                    }
                }
            }
            return res;
        }
        public static int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            //var seat = new int[n,4];//2-3,4-5,6-7,8-9
            //foreach(var one in reservedSeats)   //one[0]=row,one[1]=col
            //{
            //    if (one[1] == 2 || one[1] == 3)
            //        seat[one[0] - 1, 0] = 1;
            //    else if (one[1] == 4 || one[1] == 5)
            //        seat[one[0] - 1, 1] = 1;
            //    else if (one[1] == 6 || one[1] == 7)
            //        seat[one[0] - 1, 2] = 1;
            //    else if (one[1] == 8 || one[1] == 9)
            //        seat[one[0] - 1, 3] = 1;
            //}
            var seats = reservedSeats.OrderBy(i => i[0]).ToArray();
            var seat_index = 0;
            var res = 0;
            for(var row = 0; row < n; row++)
            {
                if (seats[seat_index][0] > row+1)
                    res += 2;
                else
                {
                    var l = false;
                    var lm = false;
                    var rm = false;
                    var r = false;
                    while(seat_index < seats.Length && seats[seat_index][0] == row + 1)
                    {
                        if (seats[seat_index][1] == 2 || seats[seat_index][1] == 3)
                            l = true;
                        else if (seats[seat_index][1] ==4 || seats[seat_index][1] == 5)
                            lm = true;
                        else if (seats[seat_index][1] == 6 || seats[seat_index][1] == 7)
                            rm = true;
                        else if (seats[seat_index][1] == 8|| seats[seat_index][1] == 9)
                            r = true;

                        seat_index++;
                    }

                    if (l == false && lm == false)
                    {
                        res++;
                        if (r == false && rm == false)
                            res++;
                    }
                    else if (r == false && rm == false)
                        res++;
                    else if (lm == false && rm == false)
                        res++;
                }
            }
            return res;

        }

        public static  int GetKth(int lo, int hi, int k)
        {
            var origin = new List<long>();
            for (var i = lo; i <= hi; i++)
                origin.Add(i);
            int res =(int)origin.OrderBy(i => Step(i)).Skip(k - 1).First();
            return res;
        }

        private static int Step(long a)
        {
            var step = 0;
            while(a!=1)
            {
                step++;
                if (a % 2 == 0)
                    a = a / 2;
                else
                    a = 3 * a + 1;
            }
            return step;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
