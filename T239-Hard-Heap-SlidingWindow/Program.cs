using System;

namespace T239_Hard_Heap_SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // 参考官方题解动态规划法，时间复杂度O(N)
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            if (n * k == 0) return new int[0];
            if (k == 1) return nums;

            int[] left = new int[n];
            left[0] = nums[0];
            int[] right = new int[n];
            right[n - 1] = nums[n - 1];

            for (int i = 1; i < n; i++)
            {
                // from left to right
                if (i % k == 0) left[i] = nums[i];  // block_start
                else left[i] = Math.Max(left[i - 1], nums[i]);

                // from right to left
                int j = n - i - 1;
                if ((j + 1) % k == 0) right[j] = nums[j];  // block_end
                else right[j] = Math.Max(right[j + 1], nums[j]);
            }

            int[] output = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
                output[i] = Math.Max(left[i + k - 1], right[i]);

            return output;
        }

        /* 时间复杂度O(k*N)
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] res = new int[nums.Length - k + 1];
            for(var si = 0; si < nums.Length - k + 1; si++)
            {
                var max = int.MinValue;
                for (var ei = si; ei < si + k; ei++)
                    max = Math.Max(max, nums[ei]);
                res[si] = max;
            }
            return res;
        }
        */
    }
}
