using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollection;

namespace UnitTestProject1
{
    [TestClass]
    public class ListUnitTest
    {
        [TestMethod]
        public void MyListCtorTest()
        {
            MyList<int> list = new MyList<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(false, list.IsReadOnly);
        }

        [TestMethod]
        public void MyListCtorTest_2()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            MyList<int> list = new MyList<int>(arr);
            Assert.AreEqual(10, list.Count);
        }

        [TestMethod]
        public void MyListAddTest()
        {
            MyList<int> list = new MyList<int>(4);
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
        public void MyListClearTest()
        {
            MyList<int> list = new MyList<int>(4);
            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(100, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void InsertTestMethod()
        {
            MyList<int> list = new MyList<int>();
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            foreach (int val in arr)
            {
                list.Add(val);
            }
            list.Insert(3, 33);
            int[] newarray = new int[list.Count];
            list.CopyTo(newarray, 0);
            int[] mockArr = { 1, 5, 10, 33, 15, 25, 3, 8, 8 };
            CollectionAssert.AreEqual(newarray, mockArr);

        }
        [TestMethod]
        public void RemoveTestMethod()
        {
            MyList<int> list = new MyList<int>();
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
        public void RemoveAtTestMethod()
        {
            MyList<int> list = new MyList<int>();
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            foreach (int val in arr)
            {
                list.Add(val);
            }
            list.RemoveAt(1);
            int[] newarray = new int[list.Count];
            list.CopyTo(newarray, 0);
            int[] mockArr = { 1, 10, 15, 25, 3, 8, 8 };
            CollectionAssert.AreEqual(newarray, mockArr);

        }

        [TestMethod]
        public void MyListIndexTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyList<int> list = new MyList<int>();
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
        public void MyListOutOfRangeTest_0()
        {
            MyList<int> list = new MyList<int>();
            list[-1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyListOutOfRangeTest_1()
        {
            MyList<int> list = new MyList<int>();
            list[1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyListOutOfRangeTest_2()
        {
            MyList<int> list = new MyList<int>();
            int x = list[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyListOutOfRangeTest_3()
        {
            MyList<int> list = new MyList<int>();
            int x = list[1];
        }

        [TestMethod]
        public void MyListContainsTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyList<int> list = new MyList<int>(arr);
            Assert.IsFalse(list.Contains(-1));
            Assert.IsTrue(list.Contains(8));
            Assert.IsFalse(list.Contains(22));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(10));
            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod]
        public void MyListCopyToTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyList<int> list = new MyList<int>(arr);
            int[] arr2 = new int[arr.Length];
            list.CopyTo(arr2, 0);
            for (int i = 0; i < arr.Length; ++i)
            {
                Assert.AreEqual(arr[i], arr2[i]);
            }
        }

        [TestMethod]
        public void MyListIndexOfTest()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyList<int> list = new MyList<int>(arr);
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(5));
            Assert.AreEqual(2, list.IndexOf(10));
            Assert.AreEqual(4, list.IndexOf(25));
            Assert.AreEqual(6, list.IndexOf(8));
            Assert.AreEqual(-1, list.IndexOf(11));
            Assert.AreEqual(-1, list.IndexOf(-1));
        }

        [TestMethod]
        public void MyListEnumerableTest()
        {
            MyList<int> list = new MyList<int>();
            Assert.IsTrue(list.GetEnumerator() is IEnumerator<int>);
        }

        [TestMethod]
        public void MyListEnumerator_1_Test()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyList<int> list = new MyList<int>(arr);
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
        public void MyListEnumerator_2_Test()
        {
            int[] arr = { 1, 5, 10, 15, 25, 3, 8, 8 };
            MyList<int> list = new MyList<int>(arr);
            int counter = 0;

            foreach (int x in list)
            {
                Assert.AreEqual(arr[counter++], x);
            }
        }
    }
}
