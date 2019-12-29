using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace leetcodePlay
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            var res1 = Trap(height);
        }

        private static int res;
        private static List<int> heightList;
        public static int Trap(int[] height)
        {
            res = 0;

            heightList = height.ToList();

            if (heightList != null && heightList.Count() > 1)
                TrapTwo(0, heightList.Count() - 1);

            return res;
        }

        private static void TrapTwo(int start, int end)
        {
            if (end - start < 2)
                return;
            else
            {
                var left = heightList.IndexOfMax(start, end);
                var right = heightList.LastIndexOfMax(start, end);

                if(left == right)  
                {
                    if (left == start)
                        right = heightList.LastIndexOfMax(start + 1, end);
                    else if (right == end)
                        left = heightList.IndexOfMax(start, end - 1);

                }

                if(right - left > 1)
                {
                    res += (right - left - 1) * Math.Min(heightList[left], heightList[right]);
                    for (var i = left + 1; i < right; i++)
                        res -= heightList[i];
                }
                
                TrapTwo(start, left);
                TrapTwo(right, end);

            }
        }


        ///**************************************/
        //private static List<IList<int>> res;
        //private static List<int> singleRes = new List<int>();

        //public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        //{
        //    res = new List<IList<int>>();

        //    if (candidates.Count() == 0 || target < 0)
        //        return res;
        //    else
        //    {
        //        List<int> orderInput = candidates.Where(i => i <= target).OrderBy(i => i).ToList();
        //        orderInput.Reverse();    // { max, ... , min }

        //        if(orderInput.Count() != 0)
        //            Combined(orderInput, 0, target, singleRes);

        //        return res;
        //    }

        //}

        //public static void Combined(List<int> orderInput, int start, int target, List<int> singleRes)
        //{
        //    if (target < 0)
        //        return;
        //    else if (target == 0)
        //    {
        //        res.Add( new List<int>( singleRes ));
        //    }
        //    else
        //    {
        //        for (var i = start; i < orderInput.Count; i++)
        //        {
        //            singleRes.Add(orderInput[i]);
        //            Combined(orderInput, i, target - orderInput[i], singleRes);
        //            singleRes.RemoveAt(singleRes.Count() - 1);  //MRAK
        //        }
        //    }
        //}
        ///**************************************/

    }

    public static class ArrayHelper
    {
        public static int IndexOfMax(this List<int> list, int start_index, int end_index)
        {
            if (start_index > end_index)
                return -1;

            var sublist = list.Skip(start_index).Take(end_index - start_index + 1).ToList();
            var max = sublist.Max();
            
            return sublist.IndexOf(max) + start_index;
        }

        public static int LastIndexOfMax(this List<int> list, int start_index, int end_index)
        {
            if (start_index > end_index)
                return -1;

            var sublist = list.Skip(start_index).Take(end_index - start_index + 1).ToList();
            var max = sublist.Max();

            return sublist.LastIndexOf(max) + start_index;
        }
    }
}
