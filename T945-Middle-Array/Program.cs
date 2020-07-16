using System;
using System.Collections.Generic;
using System.Linq;

namespace T945_Middle_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var res1 = MinIncrementForUnique(new int[] { 1, 2, 2 });
            var res6=MinIncrementForUnique(new int[] {3,2,1,2,1,7 });
            var res5 = MinIncrementForUnique(new int[] {1,1,5,5,5,9,9 });
            var res= MinIncrementForUnique(new int[] { 1, 1, 1,1,1,2,3 });
        }
        //超时！！
        //public static int MinIncrementForUnique(int[] A)
        //{
        //    Array.Sort(A);
        //    var hashset = new List<int>();
        //    var repeat = new List<Tuple<int,int>>();//key,hashset index
        //    foreach(var a in A)
        //    {
        //        if (hashset.Count>0 && hashset.Last() == a)
        //            repeat.Add(new Tuple<int, int>(a,hashset.Count-1));
        //        else
        //            hashset.Add(a);
        //    }

        //    var res = 0;
        //    foreach(var re in repeat)
        //    {
        //        res += Increment(hashset, re);
        //    }
        //    return res;
        //}
        //private static int Increment(List<int> hashset, Tuple<int,int> t)
        //{
        //    var num = t.Item1;
        //    var index = hashset.IndexOf(t.Item1, t.Item2);

        //    while(true)
        //    {
        //        index++;
        //        if (index == hashset.Count)
        //        {
        //            var ls = hashset.Last();
        //            hashset.Add(ls + 1);
        //            return ls + 1 - num;
        //        }
        //        else if (hashset[index] - hashset[index - 1] > 1)
        //        {
        //            var ls = hashset[index - 1];
        //            hashset.Insert(index, ls + 1);
        //            return ls + 1 - num;
        //        }
        //    }
        //}

        public static int MinIncrementForUnique(int[] A)
        {
            Array.Sort(A);
            var res = 0;
            for(var i = 1; i < A.Length; i++)
            {
                if(A[i]<=A[i-1])
                {
                    res += A[i - 1] + 1 - A[i];
                    A[i] = A[i - 1] + 1;
                }
            }
            return res;
        }
    }
}
