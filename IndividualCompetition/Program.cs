using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace IndividualCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            //var increase = new int[3][];
            //increase[0] = new int[] { 2, 8, 4 };
            //increase[1]=new int[] { 2, 5,0 };
            //increase[2] = new int[] { 10,9,8 };

            //var requirements = new int[4][];
            //requirements[0] = new int[] { 2, 11, 3 };
            //requirements[1] = new int[] { 15,10,7 };
            //requirements[2] = new int[] { 9,17,12};
            //requirements[3] = new int[] { 8,1,14 };
            //var res = GetTriggerTime(increase, requirements);
            var jmp = new int[] { 2, 5, 1, 1, 1, 1 };
            var jmp2 = new int[] { 2, 4, 2, 5, 1, 1 };
            var jmp3= new int[] { 3, 7, 6, 1, 4, 3, 7, 8, 1, 2, 8, 5, 9, 8, 3, 2, 7, 5, 1, 1};
            //var res = MinJump(jmp);
            var res3 = MinJump(jmp3);
        }
        static public int MinJump(int[] jump)
        {
            var n = jump.Length;
            var dp = new int[n+1];
            Array.Fill(dp, -1);
            var time = 0;
            dp[0] = 0;
            List<int> curlist = new List<int> { 0 };//already reach
            int curmax = 0;
            int lastmax = 0;
            while(true)
            {
                time++;
                List<int> nextlist = new List<int>();
                int nextmax = -1;
                foreach(var curindex in curlist)
                {
                    var gotoindex = curindex + jump[curindex];
                    if (gotoindex >= n)
                        return time;
                    else
                    { 
                        nextlist.Add(gotoindex);
                        nextmax = Math.Max(nextmax, gotoindex);
                    }
                }
                
                for(var i =lastmax; i< curmax; i++)
                {
                    if (dp[i] == -1)
                        nextlist.Add(i);
                }
                lastmax = curmax;
                curlist = nextlist;
                curmax = nextmax;
            }
        }
        static public int[] GetTriggerTime(int[][] increase, int[][] requirements)
        {
            var res = new int[requirements.Length];
            var r0 = new int[100001];
            var r1 = new int[100001];
            var r2 = new int[100001];
            Array.Fill(res, -1); 
            Array.Fill(r0, -1);
            Array.Fill(r1, -1);
            Array.Fill(r2, -1);
            int[] cur = new int[] { 0, 0, 0 };
            for(var i = 0; i < increase.Length;i++)
            {
                for (var j = cur[0]; j < cur[0] + increase[i][0]; j++)
                    r0[j + 1] = i + 1;
                cur[0] += increase[i][0];

                for (var j = cur[1]; j < cur[1] + increase[i][1]; j++)
                    r1[j + 1] = i + 1;
                cur[1] += increase[i][1];

                for (var j = cur[2]; j < cur[2] + increase[i][2]; j++)
                    r0[j + 1] = i + 1;
                cur[2] += increase[i][2];

            }
            for(var i = 0; i < requirements.Length; i++)
            {
                int a = r0[requirements[i][0]];
                int b = r1[requirements[i][1]];
                int c = r1[requirements[i][2]];
                if (a != -1 && b != -1 && c != -1)
                    res[i] = Math.Max(a, Math.Max(b, c));
            }
            return res;
        }
        public int NumWays(int n, int[][] relation, int k)
        {
            Dictionary<int, List<int>> dicway = new Dictionary<int, List<int>>();
            foreach(var re in relation)
            {
                if (dicway.ContainsKey(re[0]))
                    dicway[re[0]].Add(re[1]);
                else
                    dicway.Add(re[0], new List<int>{ re[1] } );
            }
            var cur_ls = new List<int>();
            cur_ls.Add(0);
            for(var i = 0; i < k; i++)
            {
                var next_ls = new List<int>();
                foreach(var people in cur_ls)
                {
                    if(dicway.ContainsKey(people))
                        next_ls.AddRange(dicway[people]);
                }
                cur_ls = next_ls;
            }

            int res = 0;
            foreach(var item in cur_ls)
            {
                if (item == n - 1)
                    res++;
            }
            return res;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }

            public double MinimalExecTime(TreeNode root)
            {
                return 0;
            }

            ////tuple=(包括节点本身)的 可并行时间，不可并行时间,aheadtime=有个人提前N分钟介入
            //public Tuple<double,double> MinimalExecTimeHelp(TreeNode root, double aheadtime) 
            //{
            //    if (root == null)
            //        return new Tuple<double, double> ( 0, 0 );
            //    int lval = root.left == null ? 0 : root.left.val;
            //    int rval = root.right == null ? 0 : root.right.val;
            //    Tuple<double, double> lres = MinimalExecTimeHelp(root.left, rval - lval);
            //    Tuple<double, double> rres = MinimalExecTimeHelp(root.right, lval - rval);
                
                
            //}
        }
    }
}
