using System;
using System.Collections.Generic;
using System.Linq;

namespace T820_Middle_String
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res10 = MinimumLengthEncoding(new string[] { "time", "me", "bell" });
            var res5 = MinimumLengthEncoding(new string[] { "me", "time"});
        }

 
        static public int MinimumLengthEncoding(string[] words)
        {
            var root = new WordNode();
            //各字符串的末尾节点，字符串
            Dictionary<WordNode, string> dic = new Dictionary<WordNode, string>();

            foreach(var word in words)
            {
                //words集合重复字符串
                if (dic.ContainsValue(word))
                    continue;

                WordNode cur = root;
                for(var i = word.Length - 1; i >= 0; i--)
                {
                    cur = cur.insert(word[i]);
                }
                dic.Add(cur, word);
            }

            var res = 0;
            foreach(var wordnode in dic.Keys)
            {
                if (wordnode.childcount == 0)
                    res += dic[wordnode].Length + 1;
            }
            return res;
        }

        class WordNode
        {
            public int childcount;
            public WordNode[] child;
            public WordNode()
            {
                child = new WordNode[26];
                this.childcount = 0;
            }
            public WordNode insert(char ch)
            {
                if(this.child[ch-'a'] == null)
                {
                    this.child[ch - 'a'] = new WordNode();
                    childcount++;   //有子节点，说明原节点非叶子节点
                }
                return this.child[ch - 'a'];
            }
        }
    }
}
