using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNet.BinaryTree.Tree
{
    internal class PriorityQueueMethod
    {
        private int[] array;
        private int size;

        public PriorityQueueMethod()
        {
            // 队列初始长度为32位
            array = new int[32];
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key">元素</param>
        public void enQueue(int key)
        {
            if (size >= array.Length)
            {
                resize();
            }

            array[size++] = key;
            upAdjust();
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int deQueue()
        {
            if (size <= 0)
            {
                throw new Exception("the queue is empty.");
            }
            // 获得堆顶元素
            int head = array[0];
            // 让最后一个元素移动到堆顶
            array[0] = array[--size];
            downAdjust();
            return head;
        }

        private void downAdjust()
        {
            int parentIndex = 0;
            int temp = array[parentIndex];
            int childIndex = 2 * parentIndex + 1;
            while (childIndex < size)
            {
                if (childIndex + 1 < size && array[childIndex + 1] > array[childIndex])
                {
                    childIndex++;
                }

                if (temp >= array[childIndex])
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
        /// 上浮调整
        /// </summary>
        ///
        private void upAdjust()
        {
            int childIndex = size - 1; // 叶子节点
            int parentIndex = (childIndex - 1) / 2; // 堆顶
            int temp = array[childIndex];
            while (childIndex > 0 && temp > array[parentIndex])
            {
                array[childIndex] = array[parentIndex];
                childIndex = parentIndex;
                parentIndex = parentIndex / 2;
            }

            array[childIndex] = temp;
        }

        private void resize()
        {
            int newSize = size * 2;
            int[] newArray = new int[newSize];
            array.CopyTo(newArray, 0);
            array = newArray;
        }
    }
}
