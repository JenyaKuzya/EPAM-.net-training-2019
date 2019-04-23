using NUnit.Framework;
using Task1;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        MyQueue<int> intQueue = new MyQueue<int>();
        MyQueue<string> stringQueue = new MyQueue<string>();
        MyQueue<object> objectQueue = new MyQueue<object>();

        [Test]
        public void EnqueueTest()
        {
            intQueue.Enqueue(5);
            stringQueue.Enqueue("test");
            objectQueue.Enqueue(new object());

            Assert.AreEqual(1, intQueue.Count);
            Assert.AreEqual(1, stringQueue.Count);
            Assert.AreEqual(1, objectQueue.Count);
        }

        [Test]
        public void DequeueTest()
        {
            object objectItem = new object();

            intQueue.Enqueue(5);
            stringQueue.Enqueue("test");
            objectQueue.Enqueue(objectItem);

            Assert.AreEqual(5, intQueue.Dequeue());
            Assert.AreEqual("test", stringQueue.Dequeue());
            Assert.AreEqual(objectItem, objectQueue.Dequeue());
        }

        [Test]
        public void ClearTest()
        {
            object objectItem = new object();

            intQueue.Enqueue(5);
            stringQueue.Enqueue("test");
            objectQueue.Enqueue(objectItem);

            intQueue.Clear();
            stringQueue.Clear();
            objectQueue.Clear();

            Assert.IsTrue(intQueue.IsEmpty);
            Assert.IsTrue(stringQueue.IsEmpty);
            Assert.IsTrue(objectQueue.IsEmpty);
        }

        [Test]
        public void ContainsTest()
        {
            object objectItem = new object();

            intQueue.Enqueue(5);
            stringQueue.Enqueue("test");
            objectQueue.Enqueue(objectItem);

            Assert.IsTrue(intQueue.Contains(5));
            Assert.IsTrue(stringQueue.Contains("test"));
            Assert.IsTrue(objectQueue.Contains(objectItem));
            Assert.IsFalse(intQueue.Contains(6));
            Assert.IsFalse(stringQueue.Contains("test1"));
            Assert.IsFalse(objectQueue.Contains(new object()));

            intQueue.Clear();
            stringQueue.Clear();
            objectQueue.Clear();
        }

        [Test]
        public void ForeachTest()
        {
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            intQueue.Enqueue(5);

            List<int> list = new List<int>();

            foreach (int item in intQueue)
            {
                list.Add(item);
            }

            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, list);

            intQueue.Clear();
        }
    }
}