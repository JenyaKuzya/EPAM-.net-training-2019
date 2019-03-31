using System;
using NUnit.Framework;
using Task1;

namespace Task1.Tests
{
    class Tests
    {
        [TestCase(new int[] { 2, 3, 5, 6, 7 } , ExpectedResult = 1)]
        [TestCase(new int[] { 2, 4, 18, 6, 12 }, ExpectedResult = 2)]
        [TestCase(new int[] { 9, 21, 18, 6, 12 }, ExpectedResult = 3)]
        [TestCase(new int[] { -9, -21, -18, -6, -12 }, ExpectedResult = 3)]
        [TestCase(new int[] { -8, -15, 0, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { Int32.MaxValue, Int32.MinValue, 45, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { Int32.MinValue, 0 }, ExpectedResult = Int32.MaxValue)]
        [TestCase(new int[] { Int32.MinValue, Int32.MinValue }, ExpectedResult = Int32.MaxValue)]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = 0)]
        [Test]
        public int EuclidGCDTest(int[] numbers)
        {
            return GCD.MultiGCD(GCD.EuclidGCD, numbers);
        }

        [TestCase(new int[] { 2, 3, 5, 6, 7 } , ExpectedResult = 1)]
        [TestCase(new int[] { 2, 4, 18, 6, 12 }, ExpectedResult = 2)]
        [TestCase(new int[] { 9, 21, 18, 6, 12 }, ExpectedResult = 3)]
        [TestCase(new int[] { -9, -21, -18, -6, -12 }, ExpectedResult = 3)]
        [TestCase(new int[] { -8, -15, 0, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { Int32.MaxValue, Int32.MinValue, 45, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { Int32.MinValue, 0 }, ExpectedResult = Int32.MaxValue)]
        [TestCase(new int[] { Int32.MinValue, Int32.MinValue }, ExpectedResult = Int32.MaxValue)]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = 0)]
        [Test]
        public int SteinsGCDTest(int[] numbers)
        {
            return GCD.MultiGCD(GCD.SteinsGCD, numbers);
        }

        [Test]
        public void ExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => GCD.MultiGCD(GCD.SteinsGCD, new int[] { }));
            Assert.Throws<ArgumentNullException>(() => GCD.MultiGCD(GCD.SteinsGCD, null));
        }

        [Test]
        public void ElapsedTimeTest()
        {
            GCD.MultiGCD(GCD.SteinsGCD, new int[] { 2, 4, 18, 6, 12, 20, 40, 180, 60, 120, Int32.MinValue, Int32.MinValue });
            long time = GCD.ElapsedTime;

            Assert.IsTrue(time != 0);
        }
    }
}
