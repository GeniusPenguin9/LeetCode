using System;

namespace T101_Easy_Tree_DepthFirstSearch_BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            TreeNode a1 = new TreeNode(2);
            TreeNode a2 = new TreeNode(2);
            root.left = a1;
            root.right = a2;
            a1.left = new TreeNode(3);
            a1.right = new TreeNode(4);
            
        }

    }
    
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
        public static bool IsSymmetric(TreeNode root)
        {
            if (root.left != root.right)
                return false;
            else
            {
                if (root.left == null)
                    return true;
                else
                    return IsSymmetric(root.left) && IsSymmetric(root.right);
            }

        }
    }
}

