using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNet.Method
{
    internal class SortAlgorithm
    {
        /// <summary>
        /// 冒泡排序_第一版
        /// </summary>
        public static void BubbleSort_One(int[] arry)
        {
            for (int i = 0; i < arry.Length - 1; i++)
            {
                for (int j = 0; j < arry.Length - i - 1; j++)
                {
                    int tmp = 0;
                    if (arry[j] > arry[j + 1])
                    {
                        tmp = arry[j];
                        arry[j] = arry[j + 1];
                        arry[j + 1] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// 冒泡排序_第二版
        /// </summary>
        /// <param name="arry"></param>
        public static void BubbleSort_Two(int[] arry)
        {
            for (int i = 0; i < arry.Length - 1; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < arry.Length - i - 1; j++)
                {
                    int tmp = 0;
                    if (arry[j] > arry[j + 1])
                    {
                        tmp = arry[j];
                        arry[j] = arry[j + 1];
                        arry[j + 1] = tmp;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 冒泡排序_第三版
        /// </summary>
        /// <param name="arry"></param>
        public static void BubbleSort_Three(int[] arry)
        {
            // 记录最后一次交换位置
            int lastExchangeIndex = 0;
            // 无序数列的边界，每次比较只需要比到这里为止
            int sortBorder = arry.Length - 1;
            for (int i = 0; i < arry.Length - 1; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < sortBorder; j++)
                {
                    int tmp = 0;
                    if (arry[j] > arry[j + 1])
                    {
                        tmp = arry[j];
                        arry[j] = arry[j + 1];
                        arry[j + 1] = tmp;
                        isSorted = false;
                        lastExchangeIndex = j;
                    }
                }

                sortBorder = lastExchangeIndex;
                if (isSorted)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 鸡尾酒排序_第一版
        /// </summary>
        /// <param name="arry"></param>
        public static void CocktailSort_One(int[] arry)
        {
            int tmp = 0;
            for (int i = 0; i < arry.Length / 2; i++)
            {
                bool isSorted = true;
                // 奇数轮
                for (int j = i; j < arry.Length - i - 1; j++)
                {
                    if (arry[j] > arry[j + 1])
                    {
                        tmp = arry[j];
                        arry[j] = arry[j + 1];
                        arry[j + 1] = tmp;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }

                // 偶数轮
                for (int j = arry.Length - i - 1; j > 1; j--)
                {
                    if (arry[j] < arry[j - 1])
                    {
                        tmp = arry[j - 1];
                        arry[j - 1] = arry[j];
                        arry[j] = tmp;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 快速排序_双边循环
        /// </summary>
        public static void quickSort_Duplicate(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivotIndex = partition(arr, startIndex, endIndex);
            quickSort_Duplicate(arr, startIndex, pivotIndex - 1);
            quickSort_Duplicate(arr, pivotIndex + 1, endIndex);
        }

        /// <summary>
        /// 分治法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int partition(int[] arr, int startIndex, int endIndex)
        {
            // int[] arr = { 4, 4, 6, 5, 3, 2, 8, 1 };
            // 取得第一个位置（也可以选择随机位置）的元素作为基准元素
            int pivot = arr[startIndex];
            int left = startIndex;
            int right = endIndex;

            while (left != right)
            {
                // 控制right向左
                while (right > left && arr[right] > pivot)
                {
                    right--;
                }
                // 控制left向右
                while (left < right && arr[left] <= pivot)
                {
                    left++;
                }

                if (left < right)
                {
                    int p = arr[left];
                    arr[left] = arr[right];
                    arr[right] = p;
                }
            }
            //pivot和指针重合点交换
            arr[startIndex] = arr[left];
            arr[left] = pivot;
            return left;
        }

        /// <summary>
        /// 快速排序_单边循环
        /// </summary>
        public static void quicksort_Single(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            // 得到基准元素位置
            int pivotIndex = partition_s(arr, startIndex, endIndex);
            // 根据基准元素，分成两部分进行递归排序
            quicksort_Single(arr, startIndex, pivotIndex - 1);
            quicksort_Single(arr, pivotIndex + 1, endIndex);
        }

        private static int partition_s(int[] arr, int startIndex, int endIndex)
        {
            // 取得第一个位置
            int pivot = arr[startIndex];
            int mark = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i] <= pivot)
                {
                    mark++;
                    int p = arr[mark];
                    arr[mark] = arr[i];
                    arr[i] = p;
                }
            }

            arr[startIndex] = arr[mark];
            arr[mark] = pivot;
            return mark;
        }

        public static void quicksort_Stack(int[] arr, int startIndex, int endIndex)
        {
            // 用一个合集栈来代替递归函数
            Stack<Dictionary<string, int>> quickSortStack = new Stack<Dictionary<string, int>>();

            // 整个数列的起止下标，以哈希的形式入栈
            Dictionary<string, int> rootParam = new Dictionary<string, int>();
            rootParam.Add("startIndex", startIndex);
            rootParam.Add("endIndex", endIndex);
            quickSortStack.Push(rootParam);

            // 循环结束条件：栈为空
            while (quickSortStack.TryPeek(out _))
            {
                // 栈顶元素出栈，得到起止下标
                Dictionary<string, int> param = quickSortStack.Pop();
                int pivotIndex = partitionStack(arr, param["startIndex"], param["endIndex"]);

                // 根据基准元素分成两部分，把每一部分的起止下标入栈
                // 拆分的左边部分
                if (param["startIndex"] < pivotIndex - 1)
                {
                    Dictionary<string, int> leftParam = new Dictionary<string, int>
                    {
                        { "startIndex", param["startIndex"] },
                        { "endIndex", pivotIndex - 1 }
                    };
                    quickSortStack.Push(leftParam);
                }
                // 拆分的右边部分
                if (param["endIndex"] > pivotIndex + 1)
                {
                    Dictionary<string, int> rightParam = new Dictionary<string, int>
                    {
                        { "startIndex",pivotIndex+1},
                        {"endIndex",param["endIndex"]}
                    };
                    quickSortStack.Push(rightParam);
                }
            }
        }

        private static int partitionStack(int[] arr, int startIndex, int endIndex)
        {
            int pivot = arr[startIndex];
            int mark = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i] < pivot)
                {
                    mark++;
                    int p = arr[mark];
                    arr[mark] = arr[i];
                    arr[i] = p;
                }
            }

            arr[startIndex] = arr[mark];
            arr[mark] = pivot;
            return mark;
        }
    }
}
