using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNet.BinaryTree
{
    internal class BinaryHeapMethod
    {
        /// <summary>
        /// 上浮调整
        /// </summary>
        /// <param name="array"></param>
        public static void upAdjust(ref int[] array)
        {
            int childIndex = array.Length - 1; // 队列最后一个元素
            int parentIndex = (childIndex - 1) / 2;
            int temp = array[childIndex]; // temp保存插入的叶子节点值，最后用于赋值
            while (childIndex > 0 && temp < array[parentIndex])
            {
                // 无需真正交换，单向赋值即可
                array[childIndex] = array[parentIndex];
                childIndex = parentIndex;
                parentIndex = (parentIndex - 1) / 2; // 叶子节点的父节点
            }
            array[childIndex] = temp;
        }

        /// <summary>
        /// 下沉调整
        /// </summary>
        /// <param name="array"></param>
        public static void downAdjust(ref int[] array, int parentIndex, int length)
        {
            /// 保存了父级节点
            int temp = array[parentIndex];
            int childIndex = 2 * parentIndex + 1;
            while (childIndex < length)
            {
                // 如果有右孩子并且右孩子小于左孩子的值，则定位到右孩子
                if (childIndex + 1 < length && array[childIndex + 1] < array[childIndex])
                {
                    childIndex++;
                }
                //父级小于任何节点，跳出
                if (temp <= array[childIndex])
                {
                    break;
                }
                array[parentIndex] = array[childIndex];
                parentIndex = childIndex;
                childIndex = 2 * parentIndex + 1;
            }
            array[parentIndex] = temp;
        }

        /// <summary>
        /// 构建堆
        /// </summary>
        /// <param name="array"></param>
        public static void buildHeap(ref int[] array)
        {
            for (int i = (array.Length - 2) / 2; i >= 0; i--)
            {
                downAdjust(ref array, i, array.Length);
            }
        }
    }
}
