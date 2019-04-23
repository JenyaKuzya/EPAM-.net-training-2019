using NUnit.Framework;
using Task2;

namespace Tests
{
    public class Tests
    {
        SquareMatrix<int> intSquareMatrix = new SquareMatrix<int>(5);
        SymmetricMatrix<int> intSymmetricMatrix = new SymmetricMatrix<int>(5);
        DiagonalMatrix<int> intDiagonalMatrix = new DiagonalMatrix<int>(5);
        SquareMatrix<string> stringSquareMatrixMatrix = new SquareMatrix<string>(5);
        SquareMatrix<object> objectSquareMatrix = new SquareMatrix<object>(5);

        [Test]
        public void Test()
        {
            object item = new object();

            intSquareMatrix[1, 1] = 5;
            stringSquareMatrixMatrix[1, 1] = "5";
            objectSquareMatrix[1, 1] = item;

            Assert.AreEqual(5, intSquareMatrix[1, 1]);
            Assert.AreEqual("5", stringSquareMatrixMatrix[1, 1]);
            Assert.AreEqual(item, objectSquareMatrix[1, 1]);

            Assert.AreEqual(0, intSquareMatrix[0, 0]);
            Assert.AreEqual(null, stringSquareMatrixMatrix[0, 0]);
            Assert.AreEqual(null, objectSquareMatrix[0, 0]);
        }

        [Test]
        public void EventTest()
        {
            void ShowMessage(object sender, ChangeEventArgs e)
            {
                Assert.Pass();
            }

            intSquareMatrix.ChangeElement += ShowMessage;
            intSquareMatrix[1, 1] = 5;
            Assert.Fail();
        }

        [Test]
        public void SumTest()
        {
            intSquareMatrix[0, 0] = 5;
            intSymmetricMatrix[0, 0] = 5;
            intDiagonalMatrix[0, 0] = 5;
            stringSquareMatrixMatrix[0, 0] = "5";

            Assert.AreEqual(10, (intSquareMatrix + intSquareMatrix)[0, 0]);
            Assert.AreEqual(10, (intSymmetricMatrix + intSymmetricMatrix)[0, 0]);
            Assert.AreEqual(10, (intDiagonalMatrix + intDiagonalMatrix)[0, 0]);
            Assert.AreEqual(10, (intSquareMatrix + intSymmetricMatrix)[0, 0]);
            Assert.AreEqual(10, (intSquareMatrix + intDiagonalMatrix)[0, 0]);
            Assert.AreEqual(10, (intSymmetricMatrix + intDiagonalMatrix)[0, 0]);
            Assert.AreEqual("55", (stringSquareMatrixMatrix + stringSquareMatrixMatrix)[0, 0]);
        }
    }
}