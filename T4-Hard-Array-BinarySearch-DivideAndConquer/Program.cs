using System;

namespace T4_Hard_Array_BinarySearch_DivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;
            var k = (m + n + 1) / 2;
            var start1 = -1;
            var start2 = -1;
            while(true)
            {
                var len1 = Math.Min(k / 2, m - start1);
                var len2 = Math.Min(k / 2, n - start2);
                if(nums1[start1+len1] >= nums2[start2+len2])
                {
                    start2 += len2;
                    k -= len2;
                }
                else
                {
                    start1 += len1;
                    k -= len1;
                }

            }
        }
    }
}
