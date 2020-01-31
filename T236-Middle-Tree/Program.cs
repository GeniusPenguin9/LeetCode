using System;

namespace T236_Middle_Tree
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

        public TreeNode res = null;
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            IsAncestor(root, p, q);
            return res;
        }


        public bool IsAncestor(TreeNode head, TreeNode p, TreeNode q)
        {
            if(res != null || head == null)
                return false;

            var left = IsAncestor(head.left, p, q) == true ? 1 : 0;
            var right = IsAncestor(head.right, p, q) == true ? 1 : 0;
            var mid = (head == p || head == q) ? 1 : 0;
            if ((left + right + mid) >= 2)
                res = head;
            return (left + right + mid) > 0;
        }
    }

}
