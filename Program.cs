using AlgorithmNet.BinaryTree.Tree;
using AlgorithmNet.Method;
using System.Xml.Linq;

namespace AlgorithmNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // StartTree();
            // StartQuickSort();
            // Console.WriteLine(SimpleRecursion(10));
            // StackTree();
            StartLine();
        }

        /// <summary>
        /// 简单的递归
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static int SimpleRecursion(int i)
        {
            if (i != 0)
            {
                Console.WriteLine(SimpleRecursion(i - 1));
            }

            return i;
        }

        private static void StartQuickSort()
        {
            int[] arr = { 4, 4, 6, 5, 3, 2, 8, 1 };
            // SortAlgorithm.quickSort_Duplicate(arr, 0, arr.Length - 1);
            // SortAlgorithm.quicksort_Single(arr, 0, arr.Length - 1);
            SortAlgorithm.quicksort_Stack(arr, 0, arr.Length - 1);
        }

        private static void StartTree()
        {
            LinkedList<int> inputList = new LinkedList<int>((new int[] { 1, 2, 4, '\0', '\0', 5, '\0', '\0', 3, '\0', 6 }).ToList());
            TreeNode treeNode = BinaryTreeMethod.createBinaryTree(inputList);
            Console.WriteLine("前序遍历：");
            BinaryTreeMethod.preOrderTraveral(treeNode);
            Console.WriteLine("中序遍历：");
            BinaryTreeMethod.inOrderTraveral(treeNode);
            Console.WriteLine("后序遍历：");
            BinaryTreeMethod.postOrderTraveral(treeNode);
            Console.WriteLine("栈遍历：");
            BinaryTreeMethod.preOrderTraveralWithStack(treeNode); /// 似懂非懂
            Console.WriteLine("层序遍历：");
            BinaryTreeMethod.levelOrderTraversal(treeNode);
            Console.WriteLine("二叉堆：");
            int[] array = new[] { 1, 3, 2, 6, 5, 7, 8, 9, 10, 0 };
            BinaryHeapMethod.upAdjust(ref array);
            Console.WriteLine(array.ToString());
            Console.WriteLine("构建堆：");
            array = new[] { 7, 1, 3, 10, 5, 2, 8, 9, 6 };
            BinaryHeapMethod.buildHeap(ref array);
            Console.WriteLine(array.ToString());
            Console.WriteLine("优先队列：");
            PriorityQueueMethod priorityQueueMethod = new PriorityQueueMethod();
            priorityQueueMethod.enQueue(3);
            priorityQueueMethod.enQueue(5);
            priorityQueueMethod.enQueue(6);
            priorityQueueMethod.enQueue(10);
            priorityQueueMethod.enQueue(2);
            priorityQueueMethod.enQueue(9);
            Console.WriteLine("出队元素：" + priorityQueueMethod.deQueue());
            Console.WriteLine("出队元素：" + priorityQueueMethod.deQueue());
        }

        private static void StackTree()
        {
            LinkedList<int> inputList = new LinkedList<int>((new int[] { 1, 2, 4, '\0', '\0', 5, '\0', '\0', 3, '\0', 6 }).ToList());
            TreeNode treeNode = BinaryTreeMethod.createBinaryTree(inputList);
            Console.WriteLine("======1======");
            ATestByTree.preOrderTraveralWithStack(treeNode);
            Console.WriteLine("======2======");
            ATestByTree.inOrderTraveralWithStack(treeNode);
            Console.WriteLine("======3======");
            ATestByTree.postOrderTraveralWithStatck(treeNode);
        }

        private static void StartLine()
        {
            Console.WriteLine("=========Count Sort==========");
            int[] array = new int[] { 95, 94, 91, 98, 99, 90, 99, 93, 91, 97, 95, 96, 94, 92, 95 };
            int[] sortedArray = SortLine.countSort(array);
            foreach (var sort in sortedArray)
            {
                Console.WriteLine(sort);
            }
            Console.WriteLine("===========Bucket Sort============");
            double[] darray = new double[] { 4.12, 6.421, 0.0023, 3.0, 2.123, 8.122, 4.12, 10.09 };
            double[] sorteddArray = SortLine.bucketSort(darray);
            foreach (var sort in sorteddArray)
            {
                Console.WriteLine(sort);
            }
        }
    }
}
