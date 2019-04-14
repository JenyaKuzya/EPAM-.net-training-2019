using NUnit.Framework;
using System;
using Task2;

namespace Tests
{
    public class Tests
    {
        private int[][] jaggedArray = new int[][] {
            new int[] { 1, 2, 3},
            new int[] { 2, 4, 3, 1},
            new int[] { 1 },
            new int[] { 5, 2, 2 },
            new int[] { 2, 3, 3, 3 },
            new int[] { 6, 9 },
        };


        [Test]
        public void SumIncTest()
        {
            int[][] ExpectedJaggedArray = new int[][] {
                new int[] { 1 },
                new int[] { 1, 2, 3},
                new int[] { 5, 2, 2 },
                new int[] { 2, 4, 3, 1},
                new int[] { 2, 3, 3, 3 },
                new int[] { 6, 9 },
            };

            JaggedArraySorter.SortBySumInc(ref jaggedArray);

            Assert.AreEqual(ExpectedJaggedArray, jaggedArray);
        }

        [Test]
        public void SumDecTest()
        {
            int[][] ExpectedJaggedArray = new int[][] {
                new int[] { 6, 9 },
                new int[] { 2, 3, 3, 3 },
                new int[] { 2, 4, 3, 1},
                new int[] { 5, 2, 2 },
                new int[] { 1, 2, 3},
                new int[] { 1 }, 
            };

            JaggedArraySorter.SortBySumDec(ref jaggedArray);

            Assert.AreEqual(ExpectedJaggedArray, jaggedArray);
        }

        [Test]
        public void MaxElemIncTest()
        {
            int[][] ExpectedJaggedArray = new int[][] {
                new int[] { 1 },
                new int[] { 1, 2, 3},
                new int[] { 2, 3, 3, 3 },
                new int[] { 2, 4, 3, 1},
                new int[] { 5, 2, 2 },
                new int[] { 6, 9 },
            };

            JaggedArraySorter.SortByMaxElemInc(ref jaggedArray);

            Assert.AreEqual(ExpectedJaggedArray, jaggedArray);
        }

        [Test]
        public void MaxElemDecTest()
        {
            int[][] ExpectedJaggedArray = new int[][] {
                new int[] { 6, 9 },
                new int[] { 5, 2, 2 },
                new int[] { 2, 4, 3, 1},
                new int[] { 1, 2, 3},
                new int[] { 2, 3, 3, 3 },             
                new int[] { 1 },                              
            };

            JaggedArraySorter.SortByMaxElemDec(ref jaggedArray);

            Assert.AreEqual(ExpectedJaggedArray, jaggedArray);
        }

        [Test]
        public void MinElemIncTest()
        {
            int[][] ExpectedJaggedArray = new int[][] {
                new int[] { 1 },
                new int[] { 1, 2, 3},
                new int[] { 2, 4, 3, 1},                
                new int[] { 2, 3, 3, 3 },
                new int[] { 5, 2, 2 },
                new int[] { 6, 9 },
            };

            JaggedArraySorter.SortByMinElemInc(ref jaggedArray);

            Assert.AreEqual(ExpectedJaggedArray, jaggedArray);
        }

        [Test]
        public void MinElemDecTest()
        {
            int[][] ExpectedJaggedArray = new int[][] {
                new int[] { 6, 9 },                
                new int[] { 2, 3, 3, 3 },
                new int[] { 5, 2, 2 },
                new int[] { 1 },
                new int[] { 1, 2, 3},
                new int[] { 2, 4, 3, 1},              
            };

            JaggedArraySorter.SortByMinElemDec(ref jaggedArray);

            Assert.AreEqual(ExpectedJaggedArray, jaggedArray);
        }

        [Test]
        public void ExceptionTest()
        {
            int[][] wrongJaggedArray1 = new int[][] {
                new int[] { 1 },
                new int[] { },
                new int[] { 5, 2, 2 },
                new int[] { 2, 4, 3, 1},
                new int[] { 2, 3, 3, 3 },
                new int[] { 6, 9 },
            };

            int[][] wrongJaggedArray2 = new int[][] {
                new int[] { 1 },
                null,
                new int[] { 5, 2, 2 },
                new int[] { 2, 4, 3, 1},
                new int[] { 2, 3, 3, 3 },
                new int[] { 6, 9 },
            };

            int[][] wrongJaggedArray3 = new int[][] {  };

            int[][] wrongJaggedArray4 = null;

            JaggedArraySorter.SortBySumInc(ref jaggedArray);

            Assert.Throws<ArgumentException>(() => JaggedArraySorter.SortByMaxElemInc(ref wrongJaggedArray1));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortByMaxElemInc(ref wrongJaggedArray2));
            Assert.Throws<ArgumentException>(() => JaggedArraySorter.SortByMaxElemInc(ref wrongJaggedArray3));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortByMaxElemInc(ref wrongJaggedArray4));
        }
    }
}