using NUnit.Framework;
using System;
using Task5;

namespace Tests
{
    public class Tests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        [TestCase(144, 2, 1, 12)]
        [Test]
        public void Test(double a, int n, double eps, double expectedResult)
        {
            Assert.AreEqual(expectedResult, FindSqrt.FindNthRoot(a, n, eps), eps);
        }

        [TestCase(-8, 2, 0.01)]
        [TestCase(8, -2, 0.01)]
        [TestCase(16, 2, -0.01)]
        [Test]
        public void ExceptionTest(double a, int n, double eps)
        {
            Assert.Throws<ArgumentException>(() => FindSqrt.FindNthRoot(a, n, eps));
        }
    }
}