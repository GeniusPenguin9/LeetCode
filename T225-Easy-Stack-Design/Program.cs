using System;
using System.Collections.Generic;

namespace T225_Easy_Stack_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new MyStack();
            st.Push(2);
            st.Push(1);
            st.Push(0);

            var top0 = st.Top();
            var res0 = st.Pop();
            var top1 = st.Top();
            var res1 = st.Pop();
            var top2 = st.Top();
            var res2 = st.Pop();
        }
    }

    public class MyStack
    {
        private Queue<int> q;
        private int top;
        /** Initialize your data structure here. */
        public MyStack()
        {
            q = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            q.Enqueue(x);
            top = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            for(var i = 1; i < q.Count; i ++)
            {
                var item = q.Dequeue();
                q.Enqueue(item);
                if (i == q.Count - 1)
                    top = item;
            }
            return q.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return this.top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q.Count == 0;
        }
    }
}
