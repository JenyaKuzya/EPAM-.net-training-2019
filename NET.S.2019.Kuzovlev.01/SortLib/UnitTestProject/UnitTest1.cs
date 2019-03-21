using NUnit.Framework;
using SortLib;
using System;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void QuickSortTest()
        {
            int[] array = { 4, 8, 2, 5, 9, 1, 3, 6, 7 };

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] actual = Sorter.QuickSort(array, 0, array.Length - 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MergeSortTest()
        {
            int[] array = { 4, 8, 2, 5, 9, 1, 3, 6, 7 };

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] actual = Sorter.MergeSort(array);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MergeSortEmptyArrayTest()
        {
            int[] array = { };

            int[] expected = { };
            int[] actual = Sorter.MergeSort(array);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuickSortEmptyArrayTest()
        {
            int[] array = { };

            int[] expected = { };
            int[] actual = Sorter.QuickSort(array, 0, array.Length - 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MergeSortNullArrayTest()
        {
            Assert.Throws<ArgumentNullException>(() => Sorter.MergeSort(null));
        }

        [Test]
        public void QuickSortNullArrayTest()
        {
            Assert.Throws<ArgumentNullException>(() => Sorter.QuickSort(null, 0, 0));
        }
    }
}