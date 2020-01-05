using System;
using System.Collections.Generic;
using System.Linq;

namespace T56_Middle_Sort_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var res = Merge(input);
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Count() <= 1)
                return intervals;
            else
            {
                List<int[]> res = new List<int[]>();
                var ordered = intervals.ToList().OrderBy(item => item[0]).ToList();

                List<int> single = new List<int>();
                for(var i = 0; i < intervals.Count(); i++)
                {
                    if(single.Count() == 0)
                    {
                        single.Add(ordered[i][0]);
                        single.Add(ordered[i][1]);
                    }
                    else
                    {
                        if(ordered[i][0] > single.Last())
                        {
                            res.Add(single.ToArray());
                            single.RemoveAt(1);
                            single.RemoveAt(0);
                            single.Add(ordered[i][0]);
                            single.Add(ordered[i][1]);
                        }
                        else
                        {
                            single[0] = Math.Min(single[0], ordered[i][0]);
                            single[1] = Math.Max(single[1], ordered[i][1]);
                        }
                    }
                }
                res.Add(single.ToArray());
                return res.ToArray();
            }

        }

        
    }
}
