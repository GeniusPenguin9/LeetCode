using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace WeeklyCompetition185
{
    class Program
    {
        static void Main(string[] args)
        {
            var res6 = NumOfArrays(2, 3, 1);
            var res0 = NumOfArrays(5, 2, 3);
            var res1 = NumOfArrays(9, 1, 1);
            var res34549172 = NumOfArrays(50, 100, 25);
            var res418930126 = NumOfArrays(37, 17, 7);
        }
        public string Reformat(string s)
        {
            List<char> intls = new List<char>();
            List<char> chrls = new List<char>();
            foreach(var ch in s)
            {
                if (ch >= 'a' && ch <= 'z')
                    chrls.Add(ch);
                else
                    intls.Add(ch);
            }
            
            StringBuilder sb = new StringBuilder();
            if (intls.Count == chrls.Count)
            {
                var count = intls.Count - 1;
                while (count >= 0)
                {
                    sb.Append(intls[count]);
                    sb.Append(chrls[count]);
                    count--;
                }
                return new string(sb.ToString());
            }
            else if (intls.Count - chrls.Count == 1)
            {
                var count = 0;
                while (count < chrls.Count)
                {
                    sb.Append(intls[count]);
                    sb.Append(chrls[count]);
                    count++;
                }
                sb.Append(intls[count]);
                return new string(sb.ToString());
            }
            else if (intls.Count - chrls.Count == -1)
            {
                var count = 0;
                while (count < intls.Count)
                {
                    sb.Append(chrls[count]);
                    sb.Append(intls[count]);
                    count++;
                }
                sb.Append(chrls[count]);
                return new string(sb.ToString());
            }
            else
                return "";
        }


        public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        { 
            Dictionary<string, int> dicfoodid = new Dictionary<string, int>();
            var foodid = -1;
            foreach(var order in orders)
            {
                var foodname = order[2];
                if (!dicfoodid.ContainsKey(foodname))
                {
                    foodid++;
                    dicfoodid.Add(foodname, foodid);
                }
            }
            var foodcount = dicfoodid.Count;
            Dictionary<string, int[]> dicTable = new Dictionary<string, int[]>();
            foreach(var order in orders)
            {
                var tableid = order[1];
                if (!dicTable.ContainsKey(tableid))
                    dicTable.Add(tableid, new int[foodcount]);

                var curfoodid = dicfoodid[order[2]];
                dicTable[tableid][curfoodid]++;
            }

            var res = new List<IList<string>>();
            var head = new List<string>();
            head.Add("Table");
            foreach (var food in dicfoodid.Keys.OrderBy(i => i, new MyComparer()))
            {
                head.Add(food);
            }
            foreach (var tablenow in dicTable.OrderBy(i=>int.Parse (i.Key)))
            {
                var curtable = new List<string>();
                curtable.Add(tablenow.Key);
                foreach (var food in dicfoodid.Keys.OrderBy(i => i, new MyComparer()))
                {
                   
                    var curfoodid = dicfoodid[food];
                    curtable.Add(tablenow.Value[curfoodid].ToString());
                }
                res.Add(curtable);
            }
            res.Insert(0, head);
            return res;
        }

        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            var croak = new int[5];
            foreach( var chr in croakOfFrogs)
            {
                if(!Find(croak,chr))
                {
                    if (chr == 'c')
                        croak[1] += 1;
                    else
                        return -1;
                }
            }
            if (croak[1] != 0 && croak[2] != 0 && croak[3] != 0 && croak[4] != 0)
                return -1;
            return croak[0];

        }
        public bool Find(int[] arr, char chr)
        {
            if (chr == 'c' && arr[0] > 0)
            {
                arr[0] -= 1;
                arr[1]++;
            }
            else if (chr == 'r' && arr[1] > 0)
            {
                arr[1] -= 1;
                arr[2]++;
            }
            else if (chr == 'o' && arr[2] > 0)
            {
                arr[2] -= 1;
                arr[3]++;
            }
            else if (chr == 'a' && arr[3] > 0)
            {
                arr[3] -= 1;
                arr[4]++;
            }
            else if (chr == 'k' && arr[4] > 0)
            {
                arr[4] -= 1;
                arr[0]++;
            }
            else
                return false;
            return true;
        }
        static public int NumOfArrays(int n, int m, int k)
        {
            int tmp = 1000000007;
            if (k == 0)
                return 0;
            var dp = new double[n, m + 1, k + 1];

            for (var curnum = 1; curnum < m + 1; curnum++)
            {
                dp[0, curnum, 1] = 1;
            }

            for (var index = 1; index < n; index++)
            {
                for (var curnum = 1; curnum < m + 1; curnum++)
                {
                    for (var cost = 1; cost < k + 1; cost++)
                    {
                        for (var lastmax = 1; lastmax < curnum; lastmax++)//curnum > lastmax
                        {
                            dp[index, curnum, cost] += dp[index - 1, lastmax, cost - 1];
                            dp[index, curnum, cost] %= tmp;
                        }
                        for(var lastmax = curnum; lastmax < m+1; lastmax++)//curnum<=lastmax
                        {
                            dp[index, lastmax, cost] += dp[index - 1, lastmax, cost];
                            dp[index, lastmax, cost] %= tmp;
                        }
                    }
                }
            }
            double sum = 0;
            for (var curnum = 1; curnum < m + 1; curnum++)
            {
                sum += dp[n - 1, curnum, k];
                sum %= tmp;
            }
            return (int)sum;
        }
    }

    public class MyComparer : IComparer<string>
    {
        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            return string.CompareOrdinal(x, y);
        }
    }
}
