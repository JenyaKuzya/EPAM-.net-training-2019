using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass()]
    public class InserterTests
    {
        [TestMethod()]
        public void InsertNumberTest()
        {
            Assert.AreEqual(15, Inserter.InsertNumber(15, 15, 0, 0));
            Assert.AreEqual(9, Inserter.InsertNumber(8, 15, 0, 0));
            Assert.AreEqual(120, Inserter.InsertNumber(8, 15, 3, 8));
        }

        [TestMethod()]
        public void InsertNumberNegativeNumbersTest()
        {
            Assert.AreEqual(-15, Inserter.InsertNumber(-15, -15, 0, 0));
            Assert.AreEqual(-7, Inserter.InsertNumber(-8, -15, 0, 0));
            Assert.AreEqual(-120, Inserter.InsertNumber(-8, -15, 3, 8));
        }

        [TestMethod()]
        public void InsertNumberArgumentExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => Inserter.InsertNumber(-15, -15, 32, 33));
            Assert.ThrowsException<ArgumentException>(() => Inserter.InsertNumber(-15, -15, -1, -2));
            Assert.ThrowsException<ArgumentException>(() => Inserter.InsertNumber(-15, -15, 8, 3));
        }

        [TestMethod()]
        public void InsertNumberBoundaryArgumentsTest()
        {
            Assert.AreEqual(Int32.MinValue + 1, Inserter.InsertNumber(Int32.MinValue, Int32.MaxValue, 0, 0));
            Assert.AreEqual(-8, Inserter.InsertNumber(-8, -15, 31, 31));
            Assert.AreEqual(15, Inserter.InsertNumber(8, 15, 0, 31));
        }
    }
}