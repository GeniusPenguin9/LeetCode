using System;
using System.Text;

namespace M0106_Easy_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = CompressString("aabcccccc");
            var res2 = CompressString("aabcccccaaa");
            var res3 = CompressString("abbccd");
        }
        public static string CompressString(string S)
        {
            if (S == null || S.Length == 0)
                return S;
            var sb = new StringBuilder();
            var chr = S[0];
            var count = 0;
            foreach(var c in S)
            {
                if (c == chr)
                    count++;
                else
                {
                    sb.Append(chr);
                    sb.Append(count);
                    chr = c;
                    count = 1;
                }
            }
            sb.Append(chr);
            sb.Append(count);
            return sb.Length >= S.Length ? S : sb.ToString();
        }
    }
}
