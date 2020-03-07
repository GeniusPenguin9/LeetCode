using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WeeklyCompetition178
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res = SmallerNumbersThanCurrent(new int[] { 8, 1, 2, 2, 3 });
            //var res2= SmallerNumbersThanCurrent(new int[] { 6, 5, 4, 8 });
            //var res3= SmallerNumbersThanCurrent(new int[] { 7, 7, 7, 7 });

            var res = RankTeams(new string[] { "BCA", "CAB", "CBA", "ABC", "ACB", "BAC" });
            var res2 = RankTeams(new string[] { "WXYZ", "XYZW" });
        }
        //question 1
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                    dic[num] += 1;
                else
                    dic.Add(num, 1);
            }

            var res = new int[nums.Length];
            for (var i = 0; i < res.Length; i++)
            {
                res[i] = dic.Where(kvp => kvp.Key < nums[i]).Sum(kvp => kvp.Value);
            }
            return res;
        }
        
        //question 2
        public static Dictionary<char, int[]> dic;
        public static int teamnum;
        public static string RankTeams(string[] votes)
        {
            dic = new Dictionary<char, int[]>();
            teamnum = votes[0].Length;
            var res = new char[teamnum];

            foreach (var vote in votes)
            {
                for (var i = 0; i < teamnum; i++)
                {
                    if (!dic.ContainsKey(vote[i]))
                    {
                        dic.Add(vote[i], Enumerable.Repeat(0, teamnum).ToArray());
                    }
                    dic[vote[i]][i] += 1; 
                }
            }

            //fun 1
            //for(var i = 0; i < teamnum; i++)
            //{
            //    var v = 0;
            //    for(var j = 0; j < teamnum; j++)
            //    {
            //        if (RightIsBetter(votes[0][v], votes[0][j]))
            //            v = j; 
            //    }
            //    dic[votes[0][v]] = Enumerable.Repeat(0, teamnum).ToArray();
            //    res[i] = votes[0][v];
            //}

            //return new string(res);

            var orderedKeys = dic.Keys.OrderBy(i => i, new DicComparer(dic));
            return new string(orderedKeys.ToArray());
        }

        private class DicComparer : IComparer<char>
        {
            Dictionary<char, int[]> dic;
            public DicComparer(Dictionary<char, int[]> dic)
            {
                this.dic = dic;
            }

            public int Compare([AllowNull] char a, [AllowNull] char b)
            {
                for (var i = 0; i < teamnum; i++)
                {
                    if (dic[a][i] != dic[b][i])
                        return dic[a][i] < dic[b][i]?1:-1;
                }
                return a > b? 1: -1;
            }
        }

        //question 3
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null)
                return true;
            else if (root == null)
                return false;
            else
                return IsPath(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
        }
        private bool IsPath(ListNode head, TreeNode root)
        {
            if (head == null)
                return true;
            else if (root == null || root.val != head.val)
                return false;
            else
                return IsPath(head.next, root.left) || IsPath(head.next, root.right);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
