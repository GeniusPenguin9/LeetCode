using System;

namespace T283_Easy_Array_TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void MoveZeroes(int[] nums)
        {
            var current = 0;
            var nonzero = 0;

            while(current != nums.Length)
            {
                if (nums[current] == 0)
                    current++;
                else
                {
                    if (current != nonzero)
                        nums[nonzero] = nums[current];
                    current++;
                    nonzero++;
                }
            }
            for(nonzero = nonzero; nonzero < nums.Length; nonzero++)
                nums[nonzero] = 0;
        }
    }
}
