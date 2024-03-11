using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorithmNet.BinaryTree
{
    internal class ATestByTree
    {
        /// <summary>
        /// 构建二叉树
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static TreeNode createTree(LinkedList<int> list)
        {
            TreeNode treeNode = null;
            if (list == null || list.Count == 0)
            {
                return null;
            }

            var data = list.First();
            list.RemoveFirst();
            if (data != null)
            {
                treeNode = new TreeNode(data);
                treeNode.leftChild = createTree(list);
                treeNode.rightChild = createTree(list);
            }

            return treeNode;
        }

        /// <summary>
        /// 二叉树前序遍历
        /// 从上往下开始，从左到右的顺序查询
        /// </summary>
        /// <param name="node"></param>
        public static void preOrderTraveral(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.data);
            preOrderTraveral(node.leftChild);
            preOrderTraveral(node.rightChild);
        }

        /// <summary>
        /// 二叉树中序遍历
        /// 从中间往下开始查询，从左到右的顺序查询
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
        /// 从二叉树最左下侧往上查询，从左到右的顺序查询。最后输出是树顶
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

        /// <summary>
        /// 二叉树前序遍历,用栈的方式，先进后出，后进先出
        /// 从中间往下开始查询，从左到右的顺序查询
        /// </summary>
        /// <param name="node"></param>
        public static void preOrderTraveralWithStack(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode treeNode = root;
            while (treeNode != null || stack.TryPeek(out _))
            {
                while (treeNode != null)
                {
                    Console.WriteLine("Stack<TreeNode> --> " + treeNode.data);
                    stack.Push(treeNode);
                    treeNode = treeNode.leftChild;
                }

                if (stack.TryPeek(out _))
                {
                    treeNode = stack.Pop();
                    treeNode = treeNode.rightChild;
                }
            }
        }

        /// <summary>
        /// 二叉树中序遍历
        /// 从中间往下开始查询，从左到右的顺序查询
        /// </summary>
        /// <param name="root"></param>
        public static void inOrderTraveralWithStack(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode treeNode = root;
            while (treeNode != null || stack.TryPeek(out _))
            {
                while (treeNode != null)
                {
                    stack.Push(treeNode);
                    treeNode = treeNode.leftChild;
                }

                if (stack.TryPeek(out _))
                {
                    // Console.WriteLine("Stack <-- " + treeNode.data);
                    treeNode = stack.Pop();
                    Console.WriteLine("Stack --> " + treeNode.data);
                    treeNode = treeNode.rightChild;
                }
            }
        }

        /// <summary>
        /// 二叉树后序遍历
        /// 从二叉树最左下侧往上查询，从左到右的顺序查询。最后输出是树顶
        /// </summary>
        /// <param name="root"></param>
        public static void postOrderTraveralWithStatck(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode treeNode = root;
            TreeNode lastVisited = null;
            while (treeNode != null || stack.TryPeek(out _))
            {
                while (treeNode != null)
                {
                    stack.Push(treeNode);
                    treeNode = treeNode.leftChild;
                    // Console.WriteLine("Stack <-- " + treeNode.data);
                }

                if (stack.TryPeek(out _))
                {
                    treeNode = stack.Peek();
                    if (treeNode.rightChild == null || treeNode.rightChild == lastVisited)
                    {
                        Console.WriteLine("Stack --> " + treeNode.data);
                        stack.Pop();
                        lastVisited = treeNode;
                        treeNode = null;
                    }
                    else
                    {
                        treeNode = treeNode.rightChild;
                    }
                }
            }
        }
    }
}
