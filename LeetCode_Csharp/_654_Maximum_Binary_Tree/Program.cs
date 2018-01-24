using System;
using System.Collections.Generic;
using System.Linq;

namespace _654_Maximum_Binary_Tree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] a = {3, 2, 7, 6, 1, 5};
            TreeNode aa = ConstructMaximumBinaryTree(a);
            LevelOrder_Mine(aa);

//            TreeNode b1 = new TreeNode(00);
//            TreeNode b21 = new TreeNode(10);
//            TreeNode b22 = new TreeNode(11);
//            TreeNode b32 = new TreeNode(21);
//            TreeNode b43 = new TreeNode(32);
//            b1.left = b21;
//            b1.right = b22;
//            b21.right = b32;
//            b32.left = b43;
//            LevelOrder_Mine(b1);
        }


        public class TreeNode
        {
            public int val;

            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
                left = null;
                right = null;
            }
        }

        #region 搬来自己写的树的层次遍历

        ///层次遍历，我自己写的，完了对比对比能不能用
        //设置一个队列装载所有的顺序队列
        //这招真他妈好用
        public static Queue<TreeNode> sq = new Queue<TreeNode>(1000);

        public static void LevelOrder_Mine(TreeNode root)
        {
            int trigger = 0;
            if (root == null) return;
            else
            {
                //表示了本节点的数据
                Console.Write(root + "d:\t" + root.val + "\n");

                if (root.left != null)
                {
                    sq.Enqueue(root.left);
                    trigger++;
                }

                if (root.right != null)
                {
                    sq.Enqueue(root.right);
                    trigger++;
                }
            }

            if (trigger != 0)
            {
                for (int i = trigger; i > 0; i--)
                {
                    TreeNode aaa = sq.Dequeue();
                    LevelOrder_Mine(aaa);
                }
            }
        }

        #endregion

        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            int max = 0;
            int maxIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxIndex = i;
                }
            }

            TreeNode root = new TreeNode(max);
            if (maxIndex != 0 && nums.Length != 0)
            {
                int[] leftArray = new int[maxIndex];
                Array.Copy(nums, 0, leftArray, 0, maxIndex);
                root.left = ConstructMaximumBinaryTree(leftArray);
            }


            if (maxIndex != nums.Length - 1 && nums.Length != 0)
            {
                int[] rightArray = new int[nums.Length - 1 - maxIndex];
                Array.Copy(nums, maxIndex + 1, rightArray, 0, nums.Length - maxIndex - 1);
                root.right = ConstructMaximumBinaryTree(rightArray);
            }

            return root;
        }

        public static void BianLiArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
        }
    }
}

///总结
/// Array的Copy函数真几把坑
/*
 *Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

The root is the maximum number in the array.
The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
Construct the maximum tree by the given array and output the root node of this tree.

Example 1:
Input: [3,2,1,6,0,5]
Output: return the tree root node representing the following tree:

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1
Note:
The size of the given array will be in the range [1,1000].

 *
 * 
 */