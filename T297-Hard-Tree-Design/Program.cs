using System;
using System.Collections.Generic;

namespace T297_Hard_Tree_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

            List<int> res = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            var layer = 0;
            var fullcount = 1;
            while(q.Count > 0)
            {
                var node = q.Dequeue();
                res.Add(node.val);
                q.Enqueue(root.left);
                q.Enqueue(root.right);
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {

        }
    }
}
