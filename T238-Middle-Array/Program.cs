using System;

namespace T238_Middle_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = ProductExceptSelf(new int[] { 1, 2, 3, 4 });
        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] forward = new int[nums.Length];
            int[] reverse = new int[nums.Length];
            int[] res = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
                forward[i] = i == 0 ? nums[i] : (forward[i - 1] * nums[i]);
            for (var i = nums.Length - 1; i >= 0; i--)
                reverse[i] = i == nums.Length - 1 ? nums[i] : (reverse[i + 1] * nums[i]);
            for (var i = 0; i < nums.Length; i++)
                res[i] = (i == 0 ? 1 : forward[i - 1]) * (i == nums.Length - 1 ? 1 : reverse[i + 1]);
            return res;
        }

    }
}
