using System;
using System.Collections.Generic;
using System.Linq;

namespace WeeklyCompetition181
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res = CreateTargetArray(new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 1, 2, 2, 1 });
            //var res2= CreateTargetArray(new int[] { 1, 2, 3, 4, 0 }, new int[] { 0, 1, 2, 3, 0 });
            //var res3= CreateTargetArray(new int[] { 1 }, new int[] { 0});

            //var res32 = SumFourDivisors(new int[] { 21, 4, 7 });
            //var res45=SumFourDivisors(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            //var res10932 = SumFourDivisors(new int[] { 7286,18704,70773,8224,91675 });
            var res = LongestPrefix("level");
            var res2 = LongestPrefix("ababab");
            var res3 = LongestPrefix("leetcodeleet");
            var res4 = LongestPrefix("a");
            var res5 = LongestPrefix("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            var ls = new List<int>();
            for(var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var ind = index[i];
                ls.Insert(ind, num);
            }
            return ls.ToArray();
        }
        public static int SumFourDivisors(int[] nums)
        {

            var res = 0;
            foreach(var num in nums)
            {
                
                    res += CanAdd(num);
            }
            return res;
        }
        private static int CanAdd(int num)
        {
            //            var ls = new List<int> {2,3,5,7,11,13,17,19,23,29,
            //                    31,37,41,43,47,53,59,61,67,71,
            //                    73,79,83,89,97,
            //                    101,103,107,109,113,
            //                    127,131,137,139,149,151,157,163,167,173,
            //                    179,181,191,193,197,199,211,223,227,229,
            //                    233,239,241,251,257,263,269,271,277,281,
            //                    283,293,307,311,313,317, 331 337 347 349
            //353 359 367 373 379 383 389 397 401 409
            //419 421 431
            //            433 439 443 449 457 461 463
            //467 479 487 491 499 503 509 521 523 541
            //547 557 563 569 571 577 587 593 599 601
            //607 613 617 619 631 641 643 647 653 659
            //661 673 677 683 691 701 709 719
            //            727 733
            //739 743 751 757 761 769 773 787 797 809
            //811 821 823 827 829 839 853 857 859 863
            //877 881 883 887 907 911 919 929 937 941
            //947 953 967 971 977 983 991 997
            //1009 1013 1019 1021 1031 1033 1039 1049 1051 1061
            //1063 1069
            //            1087 1091 1093 1097 1103 1109 1117 1123
            //1129 1151 1153 1163 1171 1181 1187 1193 1201 1213
            //1217 1223 1229 1231 1237 1249 1259 1277 1279 1283
            //1289 1291 1297 1301 1303 1307 1319 1321 1327 1361
            //1367 1373 1381 1399 1409 1423 1427 1429 1433 1439
            //1447 1451 1453 1459 1471 1481 1483 1487 1489 1493
            //1499 1511
            //            1523 1531 1543 1549 1553 1559 1567 1571
            //1579 1583 1597 1601 1607 1609 1613 1619 1621 1627
            //1637 1657 1663 1667 1669 1693 1697 1699 1709 1721
            //1723 1733 1741 1747 1753 1759 1777 1783 1787 1789
            //1801 1811 1823 1831 1847 1861 1867 1871 1873 1877
            //1879 1889 1901 1907 1913 1931 1933 1949 1951 1973
            //1979 1987 1993 1997 1999 2003 2011
            //            2017 2027 2029
            //2039 2053 2063 2069 2081 2083 2087 2089 2099 2111
            //2113 2129 2131 2137 2141 2143 2153 2161 2179 2203
            //2207 2213 2221 2237 2239 2243 2251 2267 2269 2273
            //2281 2287 2293 2297 2309 2311 2333 2339 2341 2347
            //2351 2357 2371 2377 2381 2383 2389 2393 2399 2411
            //2417 2423 2437 2441 2447 2459 2467 2473 2477
            //2503 2521 2531 2539 2543 2549 2551 2557 2579 2591
            //            2593
            //2609 2617 2621 2633 2647 2657 2659 2663 2671 2677
            //2683 2687 2689 2693 2699 2707 2711 2713 2719 2729
            //2731 2741 2749 2753 2767 2777 2789 2791 2797 2801
            //2803 2819 2833 2837 2843 2851 2857 2861 2879 2887
            //2897 2903 2909 2917 2927 2939 2953 2957 2963 2969
            //2971 2999 3001 3011 3019 3023 3037 3041 3049 3061
            //3067 3079 3083 3089 3109 3119 3121 3137 3163 3167
            //3169 3181 3187 3191 3203 3209 3217 3221 3229};
            var ls = new List<int> {2,3,5,7,11,13,17,19,23,29,
                                31,37,41,43,47,53,59,61,67,71,
                                73,79,83,89,97,
                                101,103,107,109,113,
                                127,131,137,139,149,151,157,163,167,173,
                                179,181,191,193,197,199,211,223,227,229,
                                233,239,241,251,257,263,269,271,277,281,
                                283,293,307,311,313,317};
            var count = 0;
            var sum = 0;
            var root = Math.Sqrt(num);
            for (var i = 0; i < ls.Count; i++)
            {
                if (ls[i] >= root)
                    break;

                if (num % ls[i] == 0 && isPrime(num / ls[i]))
                {
                    count+=2;
                    sum += ls[i];
                    sum += num / ls[i];
                }
                else if (num == ls[i] * ls[i] * ls[i])
                {
                    count += 2;
                    sum += ls[i] * ls[i] + ls[i];
                }

            }
            return count == 2 ? (sum + 1 + num) : 0;
        }
        public bool HasValidPath(int[][] grid)
        {
            return false;
        }
        public static string LongestPrefix(string s)
        {
            var lastchr = s.Last();

            if(s.Length>0 && AllSame(s))
                return s.Substring(0, s.Length-1);

            for (var i = s.Length-2;i>=0;i--)
            {
                if (s[i] == lastchr && IsSame(s, i, s.Length - 1))
                    return s.Substring(0, i+1);
            }
            return "";
        }

        private static bool IsSame(string s, int a, int b)
        {
            while(a>=0)
            {
                if (s[a] != s[b])
                    return false;

                    a--;
                b--;
            }return true;
        }
        private static bool AllSame(string s)
        {
            var ch = s[0];
            foreach(var c in s)
            {
                if (c != ch)
                    return false;
            }
            return true;
        }

        private static bool isPrime(int num)
        {
                //两个较小数另外处理
                if (num == 2 || num == 3)
                    return true;
                //不在6的倍数两侧的一定不是质数
                if (num % 6 != 1 && num % 6 != 5)
                    return false;
                int tmp = (int)Math.Sqrt(num);
                //在6的倍数两侧的也可能不是质数
                for (int i = 5; i <= tmp; i += 6)
                    if (num % i == 0 || num % (i + 2) == 0)
                        return false;
                //排除所有，剩余的是质数
                return true;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
