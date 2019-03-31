using NUnit.Framework;
using System;
using Task1;

namespace Tests
{
    public class Tests
    {
        [TestCase(new double[] { 2, 3, 0, 4, 1 }, ExpectedResult = "1x^4 + 4x^3 + 3x + 2")]
        [TestCase(new double[] { }, ExpectedResult = "")]
        [TestCase(new double[] { 2, -3, 0, -4, 1 }, ExpectedResult = "1x^4 + -4x^3 + -3x + 2")]
        [TestCase(new double[] { 2, -3, 0, 0, 0 }, ExpectedResult = "-3x + 2")]
        [TestCase(new double[] { 0, 0, 0, -4, 1 }, ExpectedResult = "1x^4 + -4x^3")]
        [Test]
        public string ToStringTest(double[] coefficients)
        {
            Polynomial polinom = new Polynomial(coefficients);

            return polinom.ToString();
        }

        [TestCase(new double[] { 3, 4, 1 }, 0, ExpectedResult = 3)]
        [TestCase(new double[] { 3, 4, 1 }, 1, ExpectedResult = 8)]
        [TestCase(new double[] { 3, 4, 1 }, 1.5, ExpectedResult = 11.25)]
        [Test]
        public double CountTest(double[] coefficients, double x)
        {
            Polynomial polinom = new Polynomial(coefficients);

            return polinom.Count(x);
        }

        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 1, 6 }, ExpectedResult = false)]
        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 2 }, ExpectedResult = false)]
        [Test]
        public bool EqualsTest(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polinom1 = new Polynomial(coefficients1);
            Polynomial polinom2 = new Polynomial(coefficients2);

            return polinom1.Equals(polinom2);
        }

        [Test]
        public void SumTest()
        {
            Polynomial polinom1 = new Polynomial(new double[] { 3, 4, 1 });
            Polynomial polinom2 = new Polynomial(new double[] { 3, 4, 1, 3, 1 });
            Polynomial expectedPolinom = new Polynomial(new double[] { 6, 8, 2, 3, 1 });

            Assert.AreEqual(expectedPolinom, polinom1 + polinom2);
        }

        [Test]
        public void SubTest()
        {
            Polynomial polinom1 = new Polynomial(new double[] { 3, 4, 1 });
            Polynomial polinom2 = new Polynomial(new double[] { 3, 4, 1, 3, 1 });
            Polynomial expectedPolinom = new Polynomial(new double[] { 0, 0, 0, -3, -1 });

            Assert.AreEqual(expectedPolinom, polinom1 - polinom2);
        }

        [Test]
        public void MulTest()
        {
            Polynomial polinom = new Polynomial(new double[] { 3, 4, 1 });
            double number = 2;
            Polynomial expectedPolinom = new Polynomial(new double[] { 6, 8, 2 });

            Assert.AreEqual(expectedPolinom, polinom * number);
        }

        [Test]
        public void DivTest()
        {
            Polynomial polinom = new Polynomial(new double[] { 6, 8, 2 });
            double number = 2;
            Polynomial expectedPolinom = new Polynomial(new double[] { 3, 4, 1 });

            Assert.AreEqual(expectedPolinom, polinom / number);
        }

        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 1, 6 }, ExpectedResult = false)]
        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 2 }, ExpectedResult = false)]
        [Test]
        public bool EqualTest(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polinom1 = new Polynomial(coefficients1);
            Polynomial polinom2 = new Polynomial(coefficients2);

            return polinom1 == polinom2;
        }

        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 1, 6 }, ExpectedResult = true)]
        [TestCase(new double[] { 3, 4, 1 }, new double[] { 3, 4, 2 }, ExpectedResult = true)]
        [Test]
        public bool NotEqualTest(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polinom1 = new Polynomial(coefficients1);
            Polynomial polinom2 = new Polynomial(coefficients2);

            return polinom1 != polinom2;
        }
    }
}