using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace DataStructuresTest
{
    [TestClass]
    public class QueueTest
    {
        private readonly DataStructures.Queue<int> _testQueue = new();
        private readonly Random random = new();

        [TestMethod]
        public void TestEnqueueDequeuePeek()
        {
            int randnum;
            System.Collections.Generic.Queue<int> stdQueue = new();

            for (ushort i = 1000; i < 10000; i += 100)
            {
                _testQueue.Clear();
                stdQueue.Clear();

                for (ushort _ = 0; _ < i; _++)
                {
                    randnum = random.Next();
                    _testQueue.Enqueue(randnum);
                    stdQueue.Enqueue(randnum);
                    Assert.AreEqual(stdQueue.Peek(), _testQueue.Peek());
                }

                Assert.AreEqual(_testQueue.Count, stdQueue.Count);

                while (_testQueue.Count != 0)
                {
                    Assert.AreEqual(stdQueue.Peek(), _testQueue.Peek());
                    Assert.AreEqual(stdQueue.Dequeue(), _testQueue.Dequeue());
                }

                Assert.AreEqual(0, _testQueue.Count);
                Assert.ThrowsException<DataStructures.EmptyQueue>(() => _testQueue.Peek());
                Assert.ThrowsException<DataStructures.EmptyQueue>(() => _testQueue.Dequeue());
            }
        }

        [TestMethod]
        public void TestRemoveContains()
        {
            _testQueue.Clear();
            int[] values = new int[] { 1, 2, 2, 2, 3, 4, 3, 3, 5, 6, 1, 1, 1 };
            foreach (int val in values)
            {
                _testQueue.Enqueue(val);
            }

            // test contains
            Assert.IsTrue(_testQueue.Contains(1));
            Assert.IsTrue(_testQueue.Contains(2));
            Assert.IsTrue(_testQueue.Contains(3));
            Assert.IsFalse(_testQueue.Contains(-1));
            Assert.IsFalse(_testQueue.Contains(9));

            // test remove and remove all
            Assert.IsTrue(_testQueue.Remove(1));
            Assert.IsTrue(_testQueue.Remove(2));
            Assert.IsTrue(_testQueue.Remove(1));
            Assert.AreEqual(10, _testQueue.Count);

            Assert.IsTrue(_testQueue.RemoveAll(3));
            Assert.AreEqual(7, _testQueue.Count);
            foreach (int val in new int[] { 2, 2, 4, 5, 6, 1, 1 })
            {
                Assert.AreEqual(val, _testQueue.Peek());
            }

            _testQueue.Clear();
            for (int _ = 0; _ < 3; _++)
            {
                _testQueue.Enqueue(1);
            }
            _testQueue.RemoveAll(1);
            Assert.AreEqual(0, _testQueue.Count);
        }
    }
}
