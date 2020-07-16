using System;

namespace T365_Middle_Math
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }
        //TODO:无法理解数学法！！
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (x + y < z) return false;
            if (x == 0 || y == 0) return z == 0 || x + y == z;
            return z % GCD(x, y) == 0;

        }
        public static int GCD(int a, int b)
        {
            if (a == b)
                return a;
            var min = Math.Min(a, b);
            var max = Math.Max(a, b);
            while (min != 0)
            {
                var t = max % min;
                max = min;
                min = t;
            }
            return max;
        }
    }
}
