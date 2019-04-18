using NUnit.Framework;
using Task3;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [TestCase (new int[] { 1, 2, 3, 4, 5, 6, 7, 8}, 3, ExpectedResult = 2)]
        [TestCase(new char[] { '1', '2', '3', '4', '5', '6', '7', '8' }, '3', ExpectedResult = 2)]
        [Test]
        public int Test<T>(IEnumerable<T> array, T value)
        {
            return BinarySearch.Find(array, value);
        }
    }
}