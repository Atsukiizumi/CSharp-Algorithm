using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNet.Method
{
    // 线性时间排序
    internal class SortLine
    {
        public static int[] countSort(int[] array)
        {
            // 1.得到数列的最大值和最小值，并算出差值d
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }

                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            int d = max - min;
            // 2.创建统计数组并统计对应元素的个数
            int[] countArray = new int[d + 1];
            for (int i = 0; i < array.Length; i++)
            {
                countArray[array[i] - min]++;
            }
            // 3.统计数组做变形，后面的元素等于前面的元素之和
            for (int i = 1; i < countArray.Length; i++)
            {
                countArray[i] += countArray[i - 1];
            }
            //4.倒叙遍历原石数列，从统计数组找到正确为止，输出结果数组
            int[] sortedArray = new int[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[countArray[array[i] - min] - 1] = array[i];
                countArray[array[i] - min]--;
            }

            return sortedArray;
        }
    }
}
