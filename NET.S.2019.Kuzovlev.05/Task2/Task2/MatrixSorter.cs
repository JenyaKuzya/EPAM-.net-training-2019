using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Class with methods for sorting a jagged array.
    /// </summary>
    public class JaggedArraySorter
    {
        /// <summary>
        /// Delegate for matcing two sz-arrays.
        /// </summary>
        /// <param name="arr1"> First sz-array. </param>
        /// <param name="arr2"> Second sz-array. </param>
        /// <returns> The resulr of matching. </returns>
        private delegate bool SortType(int[] arr1, int[] arr2);

        /// <summary>
        /// Sorts the rows of jagged array by max element in incremental order.
        /// </summary>
        /// <param name="jaggedArr"> The jagged array for sorting. </param>
        public static void SortByMaxElemInc(ref int[][] jaggedArr)
        {
            CheckJaggedArray(jaggedArr);
            SortType sorttype = MaxElemInc;
            Sort(ref jaggedArr, sorttype);
        }

        /// <summary>
        /// Sorts the rows of jagged array by max element in decremental order.
        /// </summary>
        /// <param name="jaggedArr"> The jagged array for sorting. </param>
        public static void SortByMaxElemDec(ref int[][] jaggedArr)
        {
            CheckJaggedArray(jaggedArr);
            SortType sorttype = MaxElemDec;
            Sort(ref jaggedArr, sorttype);
        }

        /// <summary>
        /// Sorts the rows of jagged array by sum of elements in incremental order.
        /// </summary>
        /// <param name="jaggedArr"> The jagged array for sorting. </param>
        public static void SortBySumInc(ref int[][] jaggedArr)
        {
            CheckJaggedArray(jaggedArr);
            SortType sorttype = SumInc;
            Sort(ref jaggedArr, sorttype);
        }

        /// <summary>
        /// Sorts the rows of jagged array by sum of elements in decremental order.
        /// </summary>
        /// <param name="jaggedArr"> The jagged array for sorting. </param>
        public static void SortBySumDec(ref int[][] jaggedArr)
        {
            CheckJaggedArray(jaggedArr);
            SortType sorttype = SumDec;
            Sort(ref jaggedArr, sorttype);
        }

        /// <summary>
        /// Sorts the rows of jagged array by min element in incremental order.
        /// </summary>
        /// <param name="jaggedArr"> The jagged array for sorting. </param>
        public static void SortByMinElemInc(ref int[][] jaggedArr)
        {
            CheckJaggedArray(jaggedArr);
            SortType sorttype = MinElemInc;
            Sort(ref jaggedArr, sorttype);
        }

        /// <summary>
        /// Sorts the rows of jagged array by min element in decremental order.
        /// </summary>
        /// <param name="jaggedArr"> The jagged array for sorting. </param>
        public static void SortByMinElemDec(ref int[][] jaggedArr)
        {
            CheckJaggedArray(jaggedArr);
            SortType sorttype = MinElemDec;
            Sort(ref jaggedArr, sorttype);
        }

        /// <summary>
        /// Checks a jagged array.
        /// </summary>
        /// <param name="jaggedArray"> The jagged array for sorting. </param>
        private static void CheckJaggedArray(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException("Array shouldn't be null.");
            if (jaggedArray.Length == 0)
                throw new ArgumentException("Array shouldn't be empty.");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i] == null)
                    throw new ArgumentNullException("Inner arrays shouldn't be null.");
                if (jaggedArray[i].Length == 0)
                    throw new ArgumentException("Inner arrays shouldn't be empty.");
            }
        }

        /// <summary>
        /// Implements a bubble sort method for jagged array.
        /// </summary>
        /// <param name="jaggedArray"> The jagged array for sorting. </param>
        /// <param name="sortType"> Type of sorting. </param>
        private static void Sort(ref int[][] jaggedArray, SortType sortType)
        {             
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                for (int j = 0; j < jaggedArray.GetLength(0) - 1 - i; j++)
                {
                    if (sortType(jaggedArray[j], jaggedArray[j + 1]))
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swaps the two sz-arrays.
        /// </summary>
        /// <param name="array1"> First array. </param>
        /// <param name="array2"> Second array. </param>
        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int [] tempArr = array1;
            array1 = array2;
            array2 = tempArr;
        }

        /// <summary>
        /// Matchs whether a first array bigger than the second array by sum of elements.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns> Result of matching. </returns>
        private static bool SumInc(int[] arr1, int[] arr2)
        {
            if (arr1.Sum() > arr2.Sum())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matchs whether a second array bigger than the first array by sum of elements.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns> Result of matching. </returns>
        private static bool SumDec(int[] arr1, int[] arr2)
        {
            if (arr1.Sum() < arr2.Sum())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matchs whether a first array bigger than the second array by max element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns> Result of matching. </returns>
        private static bool MaxElemInc(int[] arr1, int[] arr2)
        {
            if (arr1.Max() > arr2.Max())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matchs whether a second array bigger than the first array by max element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns> Result of matching. </returns>
        private static bool MaxElemDec(int[] arr1, int[] arr2)
        {
            if (arr1.Max() < arr2.Max())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matchs whether a first array bigger than the second array by min element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns> Result of matching. </returns>
        private static bool MinElemInc(int[] arr1, int[] arr2)
        {
            if (arr1.Min() > arr2.Min())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matchs whether a second array bigger than the first array by min element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns> Result of matching. </returns>
        private static bool MinElemDec(int[] arr1, int[] arr2)
        {
            if (arr1.Min() < arr2.Min())
                return true;
            else
                return false;
        }
    }
}
