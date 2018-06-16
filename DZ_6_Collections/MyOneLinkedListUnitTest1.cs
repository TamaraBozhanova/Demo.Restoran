using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MyCollection;

namespace UnitTestProject1
{
    [TestClass]
    public class MyOneLinkedListUnitTest1
    {
        [TestMethod]
        public void MyOneLinkedListCtorTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(false, list.IsReadOnly);
        }

        [TestMethod]
        public void MyOneLinkedListCtorTest_2()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>(arr);
            Assert.AreEqual(10, list.Count);
        }
        [TestMethod]
        public void MyOneLinkedListAddTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            list.Add(10);
            Assert.AreEqual(1, list.Count);

            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(101, list.Count);
        }
        [TestMethod]
        public void MyOneLinkedListAddTailTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            list.Add(10);
            Assert.AreEqual(1, list.Count);

            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(101, list.Count);
        }
        [TestMethod]
        public void MyOneLinkedListClearTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(100, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void MyOneLinkedListIndexTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            foreach (int val in arr)
            {
                list.Add(val);
            }
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(arr[i], list[i]);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyOneLinkedListOutOfRangeTest_0()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            list[-1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyOneLinkedListOutOfRangeTest_1()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            list[1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyOneLinkedListOutOfRangeTest_2()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            int x = list[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyOneLinkedListOutOfRangeTest_3()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            int x = list[1];
        }
        [TestMethod]
        public void MyOneLinkedListContainsTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>(arr);
            Assert.IsFalse(list.Contains(-1));
            Assert.IsTrue(list.Contains(8));
            Assert.IsFalse(list.Contains(22));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(10));
            Assert.IsTrue(list.Contains(3));
        }
        [TestMethod]
        public void MyOneLinkedListCopyToTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>(arr);
            int[] arr2 = new int[list.Count];
            list.CopyTo(arr2, 0);
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(arr[i], arr2[i]);
            }
        }

        [TestMethod]
        public void MyOneLinkedListIndexOfTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>(arr);
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(5));
            Assert.AreEqual(2, list.IndexOf(10));
            Assert.AreEqual(4, list.IndexOf(25));
            Assert.AreEqual(6, list.IndexOf(8));
            Assert.AreEqual(-1, list.IndexOf(11));
            Assert.AreEqual(-1, list.IndexOf(-1));
        }

        [TestMethod]
        public void MyOneLinkedListRemoveTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            foreach (int val in arr)
            {
                list.Add(val);
            }
            list.Remove(8);
            int[] newarray = new int[list.Count];
            list.CopyTo(newarray, 0);
            int[] mockArr = { 1, 5, 10, 15, 25, 3, 8 };
            CollectionAssert.AreEqual(newarray, mockArr);

        }
        [TestMethod]
        public void MyOneLinkedListRemoveAtTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            foreach (int val in arr)
            {
                list.Add(val);
            }
            list.RemoveAt(2);
            int[] newarray = new int[list.Count];
            list.CopyTo(newarray, 0);
            int[] mockArr = { 1, 5, 15, 25, 3, 8, 8 };
            CollectionAssert.AreEqual(newarray, mockArr);

        }
        [TestMethod]
        public void MyOneLinkedListEnumerableTest()
        {
            MyOneLinkedList<int> list = new MyOneLinkedList<int>();
            Assert.IsTrue(list.GetEnumerator() is IEnumerator<int>);
        }

        [TestMethod]
        public void MyOneLinkedListEnumerator_1_Test()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>(arr);
            int counter = 0;

            using (IEnumerator<int> e = list.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    Assert.AreEqual(arr[counter++], e.Current);
                }
            }
            counter = 0;
            foreach (int x in list)
            {
                Assert.AreEqual(arr[counter++], x);
            }
        }
        [TestMethod]
        public void MyOneLinkedListEnumerator_2_Test()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyOneLinkedList<int> list = new MyOneLinkedList<int>(arr);
            int counter = 0;

            foreach (int x in list)
            {
                Assert.AreEqual(arr[counter++], x);
            }
        }
    }
}
