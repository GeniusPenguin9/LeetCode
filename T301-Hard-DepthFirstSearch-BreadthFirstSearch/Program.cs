using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T301_Hard_DepthFirstSearch_BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //输入: "()())()"
            //输出: ["()()()", "(())()"]
            var res = RemoveInvalidParentheses("()())()");

            //输入: "(a)())()"
            //输出: ["(a)()()", "(a())()"]
            var res2 = RemoveInvalidParentheses("(a)())()");

            //输入: ")("
            //输出: [""]
            var res3 = RemoveInvalidParentheses(")(");

        }

        public static IList<string> RemoveInvalidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            List<int> validRight = new List<int>();
            List<int> delectRight = new List<int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else if (s[i] == ')')
                {
                    if (stack.Peek() != -1)
                    {
                        validRight.Add(i);
                        stack.Pop();
                    }
                    else
                    {
                        if (validRight.Count > 0)
                            validRight[validRight.Count - 1] = i;
                        else
                            validRight.Add(i);
                        delectRight.Add(i);
                    }
                }
            }

            var list_s = s.ToList();
            while (stack.Peek() != -1)
            {
                list_s.RemoveAt(stack.Pop());
            }

            HashSet<string> hash = new HashSet<string>();
            if (delectRight.Count > 0)
                hash.Add(CombineString(list_s, validRight, delectRight, -1, 0));
            else
                hash.Add(new string(list_s.ToString()));

            return hash.ToList();
        }

        private static void CombineString(List<char>list_s, List<int> validRight, List<int> delectRight, int clean, int cur)
        {
            if (clean == delectRight.Count - 1)
                return ;
            foreach (var del in validRight.Where(i => i <= delectRight[cur] && clean == -1 ? true : i > delectRight[clean]))
            {
                
            }
        }
    }
}
