using System;
using System.Collections.Generic;

namespace T152_Middle_Array_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = MaxProduct(new int[] { -4, -3, -2 });
        }

        public static int MaxProduct(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            else
            {
                var res = nums[0];
                var max = res;
                var min = res;
                for(var i = 1; i < nums.Length; i++)
                {
                    var tempmax = max;
                    max = Math.Max(Math.Max(nums[i], tempmax * nums[i]), min * nums[i]);
                    min = Math.Min(Math.Min(nums[i], tempmax * nums[i]), min * nums[i]);
                    res = Math.Max(res, max);
                }
                return res;
            }
        }


        /*以下方法超过时间限制
        public int MaxProduct(int[] nums)
        {
            List<int> possibleRes = new List<int>();
            int max_Value = int.MinValue;
            int? temp = null;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    temp = temp == null ? nums[i] : temp * nums[i];
                else
                {
                    if (temp != null)
                    {
                        possibleRes.Add((int)temp);
                        temp = null;
                    }
                    possibleRes.Add(nums[i]);
                }
                max_Value = Math.Max(max_Value, nums[i]);
            }
            if (temp != null)
                possibleRes.Add((int)temp);
            for (var i = 0; i < possibleRes.Count; i++)
            {
                var product = possibleRes[i];
                max_Value = Math.Max(max_Value, product);
                for (var j = i + 1; j < possibleRes.Count; j++)
                {
                    product *= possibleRes[j];
                    max_Value = Math.Max(max_Value, product);
                }
            }
            return max_Value;
        }
        */
    }
}
