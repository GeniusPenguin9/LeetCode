using System;
using System.Collections.Generic;
using System.Linq;

namespace T460_Hard_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            var dica = new Dictionary<int, int>();
            dica.Add(1, 1);
            dica.Add(2, 2);
            dica.Remove(2);



            var cache = new LFUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            var res1=cache.Get(1);
            cache.Put(3, 3);
            var res_1 = cache.Get(2);
        }
        public class LFUCache
        {
            private Dictionary<int, LFUNode> dic;
            private int cap;
            private int operate_cur = 0;
            public LFUCache(int capacity)
            {
                dic = new Dictionary<int, LFUNode>();
                this.cap = capacity;
            }

            public int Get(int key)
            {
                if (dic.ContainsKey(key))
                {
                    operate_cur++;
                    dic[key].fre++;
                    dic[key].operate = operate_cur;
                    return dic[key].val;
                }
                else
                    return -1;
            }

            public void Put(int key, int value)
            {
                if (cap > 0)
                {
                    operate_cur++;
                    if (!dic.ContainsKey(key))
                    {
                        if (dic.Count == cap)
                        {
                            var values = dic.Values;
                            var nodekey = values.ToList().OrderBy(i => i.fre).ThenBy(j => j.operate).First().key;
                            dic.Remove(nodekey);
                        }
                        dic.Add(key, new LFUNode(key, value, operate_cur));
                    }
                    else
                    {
                        dic[key].val = value;
                        dic[key].fre++;
                        dic[key].operate = operate_cur;
                    }
                }
            }
            public class LFUNode
            {
                public int key;
                public int val;
                public int fre;
                public int operate;
                public LFUNode(int key, int val, int operate)
                {
                    this.key = key;
                    this.val = val;
                    this.fre = 1;
                    this.operate = operate;
                }
            }
        }

    }
}
