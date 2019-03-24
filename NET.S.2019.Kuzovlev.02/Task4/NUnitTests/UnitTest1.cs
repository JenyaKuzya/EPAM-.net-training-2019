using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task4;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void PositiveNumbersTest()
        {
            List<int> list = new List<int> { 10, 21, 34, 46, 123, 654, 789, 741, 852, 963, 102 };
            Assert.AreEqual(new List<int> { 10, 102 }, Filter.FilterDigit(list, 0));
            Assert.AreEqual(new List<int> { 10, 21, 123, 741, 102}, Filter.FilterDigit(list, 1));
            Assert.AreEqual(new List<int> { 21, 123, 852, 102 }, Filter.FilterDigit(list, 2));
            Assert.AreEqual(new List<int> { 34, 123, 963 }, Filter.FilterDigit(list, 3));
            Assert.AreEqual(new List<int> { 34, 46, 654, 741 }, Filter.FilterDigit(list, 4));
            Assert.AreEqual(new List<int> { 654, 852 }, Filter.FilterDigit(list, 5));
            Assert.AreEqual(new List<int> { 46, 654, 963 }, Filter.FilterDigit(list, 6));
            Assert.AreEqual(new List<int> { 789, 741 }, Filter.FilterDigit(list, 7));
            Assert.AreEqual(new List<int> { 789, 852 }, Filter.FilterDigit(list, 8));
            Assert.AreEqual(new List<int> { 789, 963 }, Filter.FilterDigit(list, 9));
        }

        [Test]
        public void NegativeNumbersTest()
        {
            List<int> list = new List<int> { -10, -21, -34, -46, -123, -654, -789, -741, -852, -963, -102 };
            Assert.AreEqual(new List<int> { -10, -102 }, Filter.FilterDigit(list, 0));
            Assert.AreEqual(new List<int> { -10, -21, -123, -741, -102 }, Filter.FilterDigit(list, 1));
            Assert.AreEqual(new List<int> { -21, -123, -852, -102 }, Filter.FilterDigit(list, 2));
            Assert.AreEqual(new List<int> { -34, -123, -963 }, Filter.FilterDigit(list, 3));
            Assert.AreEqual(new List<int> { -34, -46, -654, -741 }, Filter.FilterDigit(list, 4));
            Assert.AreEqual(new List<int> { -654, -852 }, Filter.FilterDigit(list, 5));
            Assert.AreEqual(new List<int> { -46, -654, -963 }, Filter.FilterDigit(list, 6));
            Assert.AreEqual(new List<int> { -789, -741 }, Filter.FilterDigit(list, 7));
            Assert.AreEqual(new List<int> { -789, -852 }, Filter.FilterDigit(list, 8));
            Assert.AreEqual(new List<int> { -789, -963 }, Filter.FilterDigit(list, 9));
        }

        [Test]
        public void NullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => Filter.FilterDigit(null, 2));
        }

        [Test]
        public void EmptyListTest()
        {
            Assert.AreEqual(new List<int> { }, Filter.FilterDigit(new List<int> { }, 2));
        }

        [Test]
        public void ArgumentExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Filter.FilterDigit(new List<int> { }, -1));
            Assert.Throws<ArgumentException>(() => Filter.FilterDigit(new List<int> { }, 10));
        }

        [Test]
        public void BoundaryTest()
        {
            Assert.AreEqual(new List<int> { Int32.MaxValue, Int32.MinValue }, 
                Filter.FilterDigit(new List<int> { Int32.MaxValue, Int32.MinValue }, 2));
        }
    }
}