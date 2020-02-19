using System;
using System.Collections.Generic;
using static T297_Hard_Tree_Design.Codec;
using System.Linq;
using System.Text;

namespace T297_Hard_Tree_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Codec c = new Codec();
            TreeNode root = new TreeNode(1);
            TreeNode r = new TreeNode(3);
            TreeNode rl = new TreeNode(-1);
            TreeNode rr = new TreeNode(5);
            root.right = r;
            r.left = rl;
            r.right = rr;

            var res = c.serialize(root);
            //var newroot = c.deserialize(res);

            TreeNode rootR = new TreeNode(0);
            TreeNode r1 = new TreeNode(1);
            TreeNode r2 = new TreeNode(2);
            TreeNode r3 = new TreeNode(3);
            rootR.right = r1;
            r1.right = r2;
            r2.right = r3;
            var resR = c.serialize(rootR);
            var newrootR = c.deserialize(resR);

            var test = c.deserialize("1,2,3,,,4,5");
        }
    }

    public class Codec
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";

            List<int?> res = new List<int?>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null)
                    res.Add(null);
                else
                {
                    res.Add(node.val);
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            var sb = new StringBuilder();
            foreach (var item in res)
            {
                sb.Append(item);
                sb.Append(',');
            }
            return sb.ToString(0, sb.Length - 1);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "")
                return null;

            List<int?> datalist = data.Split(',').Select(i => i == "" ? (int?)null : int.Parse(i)).ToList();
            TreeNode head = new TreeNode((int)datalist[0]);

            List<TreeNode> last = new List<TreeNode> { head };
            var index = 0;
            List<TreeNode> current = new List<TreeNode>();
            
            for(var j = 1; j < datalist.Count; j++)
            {
                current.Add(datalist[j] == null ? null : new TreeNode((int)datalist[j]));

                if (j % 2 != 0)//left
                {
                    last[index].left = current[index * 2];
                }
                else
                {
                    last[index].right = current[index * 2 + 1];
                    index++;
                    if (current.Count == last.Count * 2)
                    {
                        last = current.Where(i => i != null).ToList();
                        index = 0;
                        current = new List<TreeNode>();
                    }
                } 
            }
            return head;
        }

        /* 用了满二叉树，逻辑OK，极限情况纯单侧子树时效率极低
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";

            List<int?> res = new List<int?>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            var layer = 0;
            var layercount = 0;
            var nullcount = 0;

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                layercount++;

                if (node == null)
                {
                    nullcount += 2;
                    res.Add(null);
                    q.Enqueue(null);
                    q.Enqueue(null);
                }
                else
                {
                    res.Add(node.val);
                    if (node.left == null)
                        nullcount++;
                    q.Enqueue(node.left);
                    if (node.right == null)
                        nullcount++;
                    q.Enqueue(node.right);
                }
                if (layercount == Math.Pow(2, layer))
                {
                    if (nullcount == layercount * 2)
                        break;
                    else
                    {
                        nullcount = 0;
                        layercount = 0;
                        layer++;
                    }
                }
            }
            var sb = new StringBuilder();
            foreach (var i in res)
            {
                sb.Append(i);
                sb.Append(',');
            }
            return sb.ToString(0, sb.Length - 1);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            List<string> datalist = data.Split(',').ToList();
            if (datalist[0] == "")
                return null;
            else
            {
                TreeNode root = new TreeNode(int.Parse(datalist[0]));
                if (1 < datalist.Count && datalist[1] != null)
                    root.left = deserializeHelp(datalist, 1);
                if (2 < datalist.Count && datalist[2] != null)
                    root.right = deserializeHelp(datalist, 2);
                return root;
            }
        }

        private TreeNode deserializeHelp(List<string> datalist, int index)
        {
            if (index >= datalist.Count)
                return null;
            else
            {
                if (datalist[index] == "")
                    return null;
                else
                {
                    TreeNode res = new TreeNode(int.Parse(datalist[index]));
                    if (2 * index + 1 < datalist.Count && datalist[2 * index + 1] != null)
                        res.left = deserializeHelp(datalist, 2 * index + 1);
                    if (2 * index + 2 < datalist.Count && datalist[2 * index + 2] != null)
                        res.right = deserializeHelp(datalist, 2 * index + 2);
                    return res;
                }
            }
        }
        */

    }
}
