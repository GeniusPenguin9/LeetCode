using System;

namespace T226_Easy_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                TreeNode right = InvertTree(root.right);
                TreeNode left = InvertTree(root.left);
                root.right = left;
                root.left = right;
            }
            
            return root;
        }

    }
}
