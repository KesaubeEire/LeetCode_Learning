namespace _226__Invert_Binary_Tree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        // 别人写的牛逼东西
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            TreeNode righta = InvertTree(root.right);
            TreeNode lefta = InvertTree(root.left);
            root.right = lefta;
            root.left = righta;

            return root;
        }

        /// 自己瞎几把写能不能写好呢
        /// 我觉得得掌握一个递归赋值的思想
        /// 不能总把那个return忘了,return是个非常重要的东西
        /// 这个递归赋值的思想非常重要
        /// 我觉得有必要复习一哈所有的这些数据结构的思想
        /// 在必要的时候
        /// 4月底吧,写在Kelog上
//        public TreeNode InvertTree_1(TreeNode root)
//        {
//        }

        public class TreeNode
        {
            private int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}
/*Invert a binary tree.
     4
   /   \
  2     7
 / \   / \
1   3 6   9
to
     4
   /   \
  7     2
 / \   / \
9   6 3   1
Trivia:
This problem was inspired by this original tweet by Max Howell:
Google: 90% of our engineers use the software you wrote (Homebrew), but you can’t invert a binary tree on a whiteboard so fuck off.*/