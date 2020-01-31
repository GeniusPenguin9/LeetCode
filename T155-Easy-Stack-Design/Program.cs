using System;
using System.Collections.Generic;

namespace T155_Easy_Stack_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            var res = stack.Peek();
        }
    }

    public class MinStack
    {
        private class LinkedNode
        {
            public int value;
            public int min_value;
            public LinkedNode next;
            public LinkedNode(int value)
            { this.value = value; }
        }

        
        private LinkedNode head;
        private LinkedNode tail;
        /** initialize your data structure here. */
        public MinStack()
        {    
            tail = new LinkedNode(-1);
            tail.min_value = int.MaxValue;
            head = tail;

        }

        public void Push(int x)
        {
            var node = new LinkedNode(x);
            node.next = head;
            node.min_value = Math.Min(x, head.min_value);
            head = node;
        }

        public void Pop()
        {
            if (head != tail)
                head = head.next;
        }

        public int Top()
        {
            if (head != tail)
                return head.value;
            else
                throw new InvalidOperationException();
        }

        public int GetMin()
        {
            if (head != tail)
                return head.min_value;
            else
                throw new InvalidOperationException();
        }
    }
}
