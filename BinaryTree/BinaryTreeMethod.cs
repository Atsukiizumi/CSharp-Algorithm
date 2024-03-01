using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNet.BinaryTree
{
    internal class BinaryTreeMethod
    {
        /// <summary>
        /// 构建二叉树
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static TreeNode createBinaryTree(LinkedList<int> inputList)
        {
            TreeNode node = null;
            if (inputList == null || inputList.Count == 0)
            {
                return null;
            }

            int data = inputList.First();
            inputList.RemoveFirst();
            if (data != null && data != 0)
            {
                node = new TreeNode(data);
                node.leftChild = createBinaryTree(inputList);
                node.rightChild = createBinaryTree(inputList);
            }

            return node;
        }

        /// <summary>
        /// 二叉树前序遍历
        /// </summary>
        /// <param name="node"></param>
        public static void preOrderTraveral(TreeNode node)
        {
            if (node == null) return;
            Console.WriteLine(node.data);
            preOrderTraveral(node.leftChild);
            preOrderTraveral(node.rightChild);
        }

        /// <summary>
        /// 二叉树中序遍历
        /// </summary>
        /// <param name="node"></param>
        public static void inOrderTraveral(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            inOrderTraveral(node.leftChild);
            Console.WriteLine(node.data);
            inOrderTraveral(node.rightChild);
        }

        /// <summary>
        /// 二叉树后序遍历
        /// </summary>
        /// <param name="node"></param>
        public static void postOrderTraveral(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            postOrderTraveral(node.leftChild);
            postOrderTraveral(node.rightChild);
            Console.WriteLine(node.data);
        }

        public static void preOrderTraveralWithStack(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;
            while (node != null || stack.TryPeek(out _))
            {
                // 迭代访问节点的左孩子，并入栈
                while (node != null)
                {
                    Console.WriteLine(node.data);
                    stack.Push(node);
                    node = node.leftChild;
                }
                // 左孩子没有了，则弹出栈顶节点，访问节点右孩子
                if (stack.TryPeek(out _))
                {
                    node = stack.Pop();
                    node = node.rightChild;
                }
            }
        }

        public static void levelOrderTraversal(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.WriteLine(node.data);
                if (node.leftChild != null)
                {
                    queue.Enqueue(node.leftChild);
                }

                if (node.rightChild != null)
                {
                    queue.Enqueue(node.rightChild);
                }
            }
        }
    }
}
