using NUnit.Framework;
using System;
using Task1;

namespace Tests
{
    public class Tests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(-15, -15, 0, 0, ExpectedResult = -15)]
        [TestCase(-8, -15, 0, 0, ExpectedResult = -7)]
        [TestCase(-8, -15, 3, 8, ExpectedResult = -120)]
        [Test]
        public int InsertNumberTest(int number1, int number2, int i, int j)
        {
            return Inserter.InsertNumber(number1, number2, i, j);
        }

        [Test]
        public void InsertNumberArgumentExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Inserter.InsertNumber(-15, -15, 32, 33));
            Assert.Throws<ArgumentException>(() => Inserter.InsertNumber(-15, -15, -1, -2));
            Assert.Throws<ArgumentException>(() => Inserter.InsertNumber(-15, -15, 8, 3));
        }

        [Test]
        public void InsertNumberBoundaryArgumentsTest()
        {
            Assert.AreEqual(Int32.MinValue + 1, Inserter.InsertNumber(Int32.MinValue, Int32.MaxValue, 0, 0));
            Assert.AreEqual(-8, Inserter.InsertNumber(-8, -15, 31, 31));
            Assert.AreEqual(15, Inserter.InsertNumber(8, 15, 0, 31));
        }
    }
}