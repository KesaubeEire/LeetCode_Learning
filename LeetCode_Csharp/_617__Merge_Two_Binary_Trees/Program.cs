using System.Threading;

namespace _617__Merge_Two_Binary_Trees
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

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            TreeNode valPlus = new TreeNode(t1.val + t2.val);
            if (t1.left != null || t2.left != null)
            {
                if (t1.left == null) t1.left = new TreeNode(0);
                if (t2.left == null) t2.left = new TreeNode(0);
                valPlus.left = MergeTrees(t1.left, t2.left);
            }

            if (t1.right != null || t2.right != null)
            {
                if (t1.right == null) t1.right = new TreeNode(0);
                if (t2.right == null) t2.right = new TreeNode(0);
                valPlus.right = MergeTrees(t1.right, t2.right);
            }

            return valPlus;
        }

        /// 答案给我的另一个思路
        /// 我之前的思路是创造一个新的树，直接让两个树相应位置相加
        /// 一方面没有子树的部分算作0
        /// 新的思路是，既然存在一方面没有子树的情况
        /// 那么就把存在子树情况的部分直接继承下来
        /// 这样省了很多事情
        public TreeNode MergeTrees2(TreeNode t1, TreeNode t2)
        {
            TreeNode valPlus = new TreeNode(t1.val + t2.val);
            if (t1.left == null && t2.left == null)
            {
            }
            else if (t1.left == null)
                t1.left = valPlus.left = t2.left;
            else if (t2.left == null)
                valPlus.left = t1.left;
            else
            {
                valPlus.left = MergeTrees2(t1.left, t2.left);
            }

            if (t1.right == null && t2.right == null)
            {
            }
            else if (t1.right == null)
                t1.right = valPlus.right = t2.right;
            else if (t2.right == null)
                valPlus.right = t1.right;
            else
            {
                valPlus.right = MergeTrees2(t1.right, t2.right);
            }


            return valPlus;
        }

        //标准答案再次，受我一拜，真的牛逼
        ///总结一个规律
        /// 就是想要快，在原有基础上改动往往比造一个新的空壳套要快
        /// 不知道以后会不会经常碰到这种样子的
        public TreeNode mergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val += t2.val;
            t1.left = mergeTrees(t1.left, t2.left);
            t1.right = mergeTrees(t1.right, t2.right);
            return t1;
        }

        //但是
        ///这个就打脸了
        /// 我曹还有这种方式
        /// 牛的一比
        /// 新建回答这种招式是更牛逼的套路
        /// 下次也学一学
        public TreeNode MergeTrees3(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;

            return new TreeNode(t1.val + t2.val)
            {
                left = MergeTrees3(t1.left, t2.left),
                right = MergeTrees3(t1.right, t2.right)
            };
        }
    }
}
/*Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.

You need to merge them into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of new tree.

Example 1:
Input: 
	Tree 1                     Tree 2                  
          1                         2                             
         / \                       / \                            
        3   2                     1   3                        
       /                           \   \                      
      5                             4   7                  
Output: 
Merged tree:
	     3
	    / \
	   4   5
	  / \   \ 
	 5   4   7
Note: The merging process must start from the root nodes of both trees.

*/