using System;
using System.Collections.Generic;
using System.Linq;

namespace M59_Middle_Stack_SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MaxQueue
    {
        private Queue<int> q;
        private List<int> sort;
        public MaxQueue()
        {
            q = new Queue<int>();
            sort = new List<int>();
        }

        public int Max_value()
        {
            return sort.Count == 0 ? -1 : sort[0];
        }

        public void Push_back(int value)
        {
            q.Enqueue(value);
            while (sort.Count > 0)
            {
                if (sort.Last() < value)
                    sort.RemoveAt(sort.Count - 1);
            }
            sort.Add(value);
        }

        public int Pop_front()
        {
            if (q.Count == 0)
                return -1;
            else
            {
                if (q.Peek() == sort[0])
                    sort.RemoveAt(0);
                return q.Dequeue();
            }
        }
    }
}
