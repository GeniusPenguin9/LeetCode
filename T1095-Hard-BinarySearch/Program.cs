using System;

namespace T1095_Hard_BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class MountainArray
        {
            public int n;
            public int[] arr;
            public MountainArray(int n, int[] arr)
            { this.n = n; this.arr = arr; }
            static public int Get(int index) { return arr[index]; }
            public int Length() { return n; }
            static public int FindInMountainArray(int target, MountainArray mountainArr)
            {

            }
            
        }
        static public Tuple<int, int> BinarySearch(Tuple<int, int> range)
        {
            var l = range.Item1;
            var r = range.Item2;
            if(l==r)
                return 

            int m = l + (l - r) / 2;
            if (MountainArray.Get(m) > MountainArray.Get(m+1))

            }

    }
}
