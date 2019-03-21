using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
    /// <summary>
    /// Contains sort methods for integer arrays.
    /// </summary>
    public static class Sorter
    {
        /// <summary>
        /// Sorts integer array with Quick sort.
        /// </summary>
        /// <param name="array"> Sorting array. </param>
        /// <param name="start"> Start index. </param>
        /// <param name="end"> End index. </param>
        /// <returns> Sorted array. </returns>
        public static int[] QuickSort(int[] array, int start, int end)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Source array cannot be null!");
            }
            if (start >= end)
            {
                return array;
            }
            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
            return array;
        }

        /// <summary>
        /// Divides array into two parts for Quick sort.  
        /// </summary>
        /// <param name="array"> Dividing array. </param>
        /// <param name="start"> Start index. </param>
        /// <param name="end"> End index. </param>
        /// <returns> Index of a mid of the array. </returns>
        private static int Partition(int[] array, int start, int end)
        {
            int temp = 0;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker++;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        /// <summary>
        /// Sorts integer array with Merge sort.
        /// </summary>
        /// <param name="array"> Sorting array. </param>
        /// <returns> Sorted array. </returns>
        public static int[] MergeSort(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Source array cannot be null!");
            }
            if ((array.Length == 1) || (array.Length == 0))
            {
                return array;
            }
            int center = array.Length / 2;
            int[] result = Merge(MergeSort(array.Take(center).ToArray()), MergeSort(array.Skip(center).ToArray()));
            return result;
        }

        /// <summary>
        /// Merges two arrays in one.
        /// </summary>
        /// <param name="firstArray"> First array. </param>
        /// <param name="secondArray"> Second array. </param>
        /// <returns> Merged array. </returns>
        private static int[] Merge(int[] firstArray, int[] secondArray)
        {
            int ptr1 = 0, ptr2 = 0;
            int[] mergedArray = new int[firstArray.Length + secondArray.Length];
            for (int i = 0; i < mergedArray.Length; ++i)
            {
                if (ptr1 < firstArray.Length && ptr2 < secondArray.Length)
                {
                    mergedArray[i] = firstArray[ptr1] > secondArray[ptr2] ? secondArray[ptr2++] : firstArray[ptr1++];
                }
                else
                {
                    mergedArray[i] = ptr2 < secondArray.Length ? secondArray[ptr2++] : firstArray[ptr1++];
                }
            }
            return mergedArray;
        }
    }
}
