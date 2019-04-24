using NUnit.Framework;
using Task3;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private class Book : IComparable<Book>
        {
            public string name;
            public string author;
            public int year;
            public int price;

            public int CompareTo(Book book)
            {
                return this.price - book.price;
            }
        }

        private struct Point
        {
            public int x;
            public int y;
            public int z;
        }

        private static int Compare(Point p1, Point p2)
        {
            return p1.y - p2.y;
        }

        List<int> intList = new List<int> { 5, 4, 6, 7, 3, 8, 2, 9, 1 };
        List<string> stringList = new List<string> { "5", "4", "6", "7", "3", "8", "2", "9", "1" };
        List<Book> bookList = new List<Book>()
        {
            new Book() { price = 322, author = "K", name = "M", year = 1998 },
            new Book() { price = 200, author = "K", name = "M", year = 1990 },
            new Book() { price = 144, author = "K", name = "D", year = 1900 },
            new Book() { price = 400, author = "K", name = "M", year = 1999 }
        };
        List<Point> pointList = new List<Point>()
        {
            new Point() { x = 7, y = 5, z = 10 },
            new Point() { x = 4, y = 4, z = 5 },
            new Point() { x = 5, y = 3, z = 2 },
            new Point() { x = 9, y = 2, z = 6 },
            new Point() { x = 7, y = 1, z = 15 },
            new Point() { x = 2, y = 6, z = 18 },
            new Point() { x = 13, y = 7, z = 9 }
        };

        BinarySearchTree<int> intTree = new BinarySearchTree<int>();
        BinarySearchTree<string> stringTree = new BinarySearchTree<string>();
        BinarySearchTree<Book> bookTree = new BinarySearchTree<Book>();
        BinarySearchTree<Point> pointTree = new BinarySearchTree<Point>(Compare);

        [Test]
        public void AddTest()
        {
            intTree.Add(intList);
            stringTree.Add(stringList);
            bookTree.Add(bookList);
            pointTree.Add(pointList);

            Assert.IsFalse(intTree.IsEmpty);
            Assert.IsFalse(stringTree.IsEmpty);
            Assert.IsFalse(bookTree.IsEmpty);
            Assert.IsFalse(pointTree.IsEmpty);
        }

        [Test]
        public void IsContainTest()
        {
            Assert.IsTrue(intTree.IsContain(5));
            Assert.IsTrue(stringTree.IsContain("5"));
            Assert.IsFalse(intTree.IsContain(15));
            Assert.IsFalse(stringTree.IsContain("15"));
        }

        [Test]
        public void InOrderTraversalTest()
        {
            List<int> actualIntList = new List<int>();
            List<string> actualStringList = new List<string>();
            List<int> actualBookList = new List<int>();
            List<int> actualPointList = new List<int>();

            foreach (int elem in intTree.InorderTraversal())
                actualIntList.Add(elem);

            foreach (string elem in stringTree.InorderTraversal())
                actualStringList.Add(elem);

            foreach (Book elem in bookTree.InorderTraversal())
                actualBookList.Add(elem.price);

            foreach (Point elem in pointTree.InorderTraversal())
                actualPointList.Add(elem.y);

            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, actualIntList);
            Assert.AreEqual(new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" }, actualStringList);
            Assert.AreEqual(new List<int> { 144, 200, 322, 400 }, actualBookList);
            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, actualPointList);
        }

        [Test]
        public void PreOrderTraversal()
        {
            List<int> actualIntList = new List<int>();
            List<string> actualStringList = new List<string>();
            List<int> actualBookList = new List<int>();
            List<int> actualPointList = new List<int>();

            foreach (int elem in intTree.PreorderTraversal())
                actualIntList.Add(elem);

            foreach (string elem in stringTree.PreorderTraversal())
                actualStringList.Add(elem);

            foreach (Book elem in bookTree.PreorderTraversal())
                actualBookList.Add(elem.price);

            foreach (Point elem in pointTree.PreorderTraversal())
                actualPointList.Add(elem.y);

            Assert.AreEqual(new List<int> { 5, 4, 3, 2, 1, 6, 7, 8, 9 }, actualIntList);
            Assert.AreEqual(new List<string> { "5", "4", "3", "2", "1", "6", "7", "8", "9" }, actualStringList);
            Assert.AreEqual(new List<int> { 322, 200, 144, 400 }, actualBookList);
            Assert.AreEqual(new List<int> { 5, 4, 3, 2, 1, 6, 7 }, actualPointList);
        }

        [Test]
        public void PostOrderTraversal()
        {
            List<int> actualIntList = new List<int>();
            List<string> actualStringList = new List<string>();
            List<int> actualBookList = new List<int>();
            List<int> actualPointList = new List<int>();

            foreach (int elem in intTree.PostorderTraversal())
                actualIntList.Add(elem);

            foreach (string elem in stringTree.PostorderTraversal())
                actualStringList.Add(elem);

            foreach (Book elem in bookTree.PostorderTraversal())
                actualBookList.Add(elem.price);

            foreach (Point elem in pointTree.PostorderTraversal())
                actualPointList.Add(elem.y);

            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 9, 8, 7, 6, 5 }, actualIntList);
            Assert.AreEqual(new List<string> { "1", "2", "3", "4", "9", "8", "7", "6", "5" }, actualStringList);
            Assert.AreEqual(new List<int> { 144, 200, 400, 322 }, actualBookList);
            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 7, 6, 5 }, actualPointList);
        }
    }
}