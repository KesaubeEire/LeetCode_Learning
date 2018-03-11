using System;

namespace _104__Maximum_Depth_of_Binary_Tree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }


        static public int MaxDepth(TreeNode root)
        {
            int res = 1;
            if (root.left != null || root.right != null)
            {
                res += Math.Max(MaxDepth(root.right), MaxDepth(root.left));
                if (root.left != null)
                {
                    MaxDepth(root.left);
                }

                if (root.right != null)
                {
                    MaxDepth(root.right);
                }
            }

            return res;
        }
    }
}
/*Given a binary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

For example:
Given binary tree [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7
return its depth = 3.

*/