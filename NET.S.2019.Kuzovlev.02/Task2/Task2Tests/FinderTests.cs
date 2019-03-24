using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestClass()]
    public class FinderTests
    {       
        [TestMethod()]
        public void FindNextBiggerNumberTest()
        {
            Assert.ThrowsException<ArgumentException>(() => Finder.FindNextBiggerNumber(-1));
        }

        [TestMethod()]
        public void FindNextBiggerNumberTimeTest()
        {
            Finder.FindNextBiggerNumber(3456432);
            long time = Finder.ElapsedMs;

            Assert.IsTrue(time > 5);
        }
    }
}