using System;

namespace M51_Hard_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var res5 = ReversePairs(new int[] { 7, 5, 6, 4 });
        }

        static public int ReversePairs(int[] nums)
        {
            return Reverse(nums, 0, nums.Length - 1);
        }
        static public int Reverse(int[] nums, int start, int end)
        {
            if (start >= end)
                return 0;
            int mid = (start + end) / 2;
            var tmp = new int[end - start + 1];
            int res = 0;
            res += Reverse(nums, start, mid);
            res += Reverse(nums, mid + 1, end);
            var left = start;
            var right = mid + 1;
            var index = 0;
            while(true)
            {
                if (left == (mid + 1) && right == (end + 1))
                    break;
                else if(left == mid+1)
                {
                    tmp[index] = nums[right];
                    index++;
                    right++;
                }
                else if(right == end + 1)
                {
                    tmp[index] = nums[left];
                    index++;
                    left++;
                    res += end - mid;
                }
                else if(nums[left]<=nums[right])
                {
                    tmp[index] = nums[left];
                    index++;
                    left++;
                    res += right - mid - 1;
                }
                else
                {
                    tmp[index] = nums[right];
                    index++;
                    right++;
                }

            }
            Array.Copy(tmp, 0, nums, start, end - start + 1);
            return res;
        }
    }
}
