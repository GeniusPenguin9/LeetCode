using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DoubleWeeklyCompetition21
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res = SortString("aaaabbbbcccc") == "abccbaabccba";
            //var res2 = SortString("rat") == "art";
            //var res3 = SortString("leetcode") == "cdelotee";
            //var res4 = SortString("ggggggg") == "ggggggg";
            //var res5 = SortString("spo") == "ops";

            //var res13 = FindTheLongestSubstring("eleetminicoworoep");
            //var res5 = FindTheLongestSubstring("leetcodeisgreat");
            //var res6 = FindTheLongestSubstring("bcbcbc");


        }
        public static string SortString(string s)
        {
            var arr = Enumerable.Repeat(0, 26).ToArray();
            foreach(var ch in s)
            {
                arr[ch - 'a'] += 1;
            }
            var count = s.Length;

            List<char> res = new List<char>();
            while(true)
            {
                if (count == 0)
                    break;
                for(var i = 0; i < 26 && count>0; i++)
                {
                    if(arr[i]>0)
                    {
                        res.Add((char)('a'+i));
                        arr[i] -= 1;
                        count -= 1;
                    }
                }
                for (var i = 25; i >=0 && count > 0; i--)
                {
                    if (arr[i] > 0)
                    {
                        res.Add((char)('a' + i));
                        arr[i] -= 1;
                        count -= 1;
                    }
                }
            }
            return new string(res.ToArray());
        }

        public static int FindTheLongestSubstring(string s)
        {
            Dictionary<char, List<int>> dic = new Dictionary<char, List<int>> { { 'a',new List<int>()},
                                                                                { 'e',new List<int>()},
                                                                                { 'i',new List<int>()},
                                                                                { 'o',new List<int>()},
                                                                                { 'u',new List<int>()}};
            for (var i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                    dic[s[i]].Add(i);
            }

            var max = 0;
            for (var start = 0; start < s.Length; start++)
            {
                for(var end = s.Length - 1; end >= start; end--)
                {
                    var a = Count(dic['a'], start, end);
                    var e = Count(dic['e'], start, end); ;
                    var i2 = Count(dic['i'], start, end); ;
                    var o = Count(dic['o'], start, end); ;
                    var u = Count(dic['u'], start, end); ;

                    if (a % 2 == 0 && e % 2 == 0 && i2 % 2 == 0 && o % 2 == 0 && u % 2 == 0)
                    { 
                        max = Math.Max(max, end - start + 1); 
                        break; 
                    }
                }
            }
            return max;
        }
        private static int Count(List<int> list, int start, int end)
        {
            var min = -1;
            var max = -1;
            for(var i = 0; i < list.Count; i++)
            {
                if(list[i]>=start)
                {
                    min = i;
                    break;
                }
            }
            for(var i = list.Count-1;i>=0;i--)
            {
                if(list[i]<=end)
                {
                    max = i;
                    break;
                }
                
            }
            return min == -1 ? 0 : max - min + 1;
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        int maxlen;
        public int MaxSumBST(TreeNode root)
        {
            maxlen = 0;
            maxsumbst(root, true, 1);
            maxsumbst(root, false, 1);
            return maxlen;
        }
        
        private void maxsumbst(TreeNode root, bool IsLeft, int step)
        {
            if (root == null)
                return;
            maxlen = Math.Max(maxlen, step);
            if(IsLeft)
            {
                maxsumbst(root.left, false, step + 1);
                maxsumbst(root.right, true, 1);
            }
            else
            {
                maxsumbst(root.right, true, step + 1);
                maxsumbst(root.left, false, 1);
            }
        }

    }


}
