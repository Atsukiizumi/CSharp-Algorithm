using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNet.Method
{
    internal class SortHeap
    {
        /// <summary>
        /// “下沉”调整
        /// </summary>
        /// <param name="array"></param>
        /// <param name="parentIndex"></param>
        /// <param name="length"></param>
        public static void downAdjust(int[] array, int parentIndex, int length)
        {
            // temp保存父节点值，用于最后的赋值
            int temp = array[parentIndex];
            int childIndex = 2 * parentIndex + 1;
            while (childIndex < length)
            {
                // 如果有右孩子，且右孩子大于左孩子的值，则定位到右孩子
                if (childIndex + 1 < length && array[childIndex + 1] > array[childIndex])
                {
                    childIndex++;
                }
                // 如果父节点大于任何一个孩子的值，则直接跳出
                if (temp >= array[childIndex])
                {
                    break;
                }

                // 无须真正交换，单向赋值即可
                array[parentIndex] = array[childIndex];
                parentIndex = childIndex;
                childIndex = 2 * childIndex + 1;
            }

            array[parentIndex] = temp;
        }

        public static void heapSort(int[] arry)
        {
            // 把无序数组构建成最大堆.
            for (int i = (arry.Length - 2) / 2; i >= 0; i--)
            {
                downAdjust(arry, i, arry.Length);
            }

            Array.ForEach(arry, new Action<int>(Console.WriteLine));

            // 循环删除堆顶元素，移到集合尾部，调整堆产生新的堆顶
            for (int i = arry.Length - 1; i > 0; i--)
            {
                // 最后一个元素和第一个元素进行交换
                int temp = arry[i];
                arry[i] = arry[0];
                arry[0] = temp;
                // 下沉调整最大堆
                downAdjust(arry, 0, i);
            }
        }
    }
}
