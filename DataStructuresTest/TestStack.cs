using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System;


namespace DataStructuresTest
{
    [TestClass]
    public class TestStack
    {
        private readonly Random _random = new();
        private readonly DataStructures.Stack<int> _testStack = new();

        [TestMethod]
        public void TestPushPopPeek()
        {
            System.Collections.Generic.Stack<int> stdStack = new();

            for (ushort i = 1000; i < 10000; i += 100)
            {
                _testStack.Clear();
                stdStack.Clear();

                // create stack with random numbers
                for (uint _ = 0; _ < i; _++)
                {
                    int randnum = _random.Next();
                    _testStack.Push(randnum);
                    stdStack.Push(randnum);

                    Assert.AreEqual(_testStack.Peek(), stdStack.Peek());
                }

                Assert.AreEqual(_testStack.Count, stdStack.Count);

                while (stdStack.Count != 0)
                {
                    Assert.AreEqual(_testStack.Pop(), stdStack.Pop());
                }

                Assert.AreEqual(_testStack.Count, 0);
                Assert.ThrowsException<DataStructures.EmptyStack>(() => _testStack.Peek());
                Assert.ThrowsException<DataStructures.EmptyStack>(() => _testStack.Pop());
            }
        }

        [TestMethod]
        public void TestRemoveContains()
        {
            int randnum;
            System.Collections.Generic.List<int> stdStack = new();
            System.Collections.Generic.List<int> toRemove;
            System.Collections.Generic.List<int> toRemoveAll;

            for (ushort i = 1000; i < 10000; i += 100)
            {
                _testStack.Clear();
                stdStack.Clear();
                toRemove = new();
                toRemoveAll = new();

                // create stack with random numbers
                for (uint _ = 0; _ < i; _++)
                {
                    randnum = _random.Next();
                    _testStack.Push(randnum);
                    stdStack.Add(randnum);

                    if (_random.Next() % 2 == 0)
                    {
                        toRemove.Add(randnum);
                    }
                    if (_random.Next() % 5 == 0)
                    {
                        toRemoveAll.Add(randnum);
                    }
                }

                foreach (int value in toRemove)
                {
                    bool stdContains = stdStack.Remove(value);
                    bool testContains1 = _testStack.Contains(value);
                    bool testContains2 = _testStack.Remove(value);
                    Assert.AreEqual(stdContains, testContains1);
                    Assert.AreEqual(testContains1, testContains2);
                }

                foreach (int value in toRemoveAll)
                {
                    bool stdContains = stdStack.Contains(value);
                    if (stdContains)
                    {
                        stdStack.RemoveAll(delegate(int val) { return val == value; });
                    }
                    bool testContains1 = _testStack.Contains(value);
                    bool testContains2 = _testStack.RemoveAll(value);
                    Assert.AreEqual(stdContains, testContains1);
                    Assert.AreEqual(testContains1, testContains2);
                    Assert.IsFalse(_testStack.Contains(value));
                }

                stdStack.Reverse();
                foreach (int value in stdStack)
                {
                    Assert.AreEqual(value, _testStack.Pop());
                }
                Assert.AreEqual(_testStack.Count, 0);
            }
        }
    }
}