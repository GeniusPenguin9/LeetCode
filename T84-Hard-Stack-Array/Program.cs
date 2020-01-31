using System;
using System.Collections.Generic;

namespace T84_Hard_Stack_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            var maxarea = 0;
            for(var i = 0; i < heights.Length; i++)
            {
                while (stack.Peek() != -1 && heights[i] < heights[stack.Peek()])
                    maxarea = Math.Max(maxarea, heights[stack.Pop()] * (i - stack.Peek() - 1));
                stack.Push(i);
            }
            while (stack.Peek() != -1)
                maxarea = Math.Max(maxarea, heights[stack.Pop()] * (heights.Length - stack.Peek() - 1));
            return maxarea;
        }
    }
}
