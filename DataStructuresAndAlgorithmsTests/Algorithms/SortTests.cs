using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Algorithms.Tests
{
    [TestClass()]
    public class SortTests
    {
        [TestMethod()]
        public void testSetTest()
        {
            var set = new int[] { 1, 5, 10, 15, 58 };
            Assert.IsTrue(this.testSetAscending(set));

            set = new int[] { 1, 5, 10, 15, 58, 30 };
            Assert.IsFalse(this.testSetAscending(set));

            set = new int[] { 1, 1, 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(this.testSetAscending(set));

            set = new int[] { 7, 6, 5, 4, 3, 2 };
            Assert.IsTrue(this.testSetDescending(set));

            set = new int[] { 6, 7, 5, 4, 3, 2, 1 };
            Assert.IsFalse(this.testSetDescending(set));

            set = new int[] { 7, 7, 7, 7, 7, 3, 1 };
            Assert.IsTrue(this.testSetDescending(set));
        }

        [TestMethod()]
        public void InsertionSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.InsertionSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.InsertionSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.InsertionSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }
        
        [TestMethod()]
        public void SelectionSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.SelectionSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.SelectionSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.SelectionSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.BubbleSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.BubbleSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.BubbleSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        [TestMethod()]
        public void MergeSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.MergeSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));
            
            set = this.createSet();
            sortedSet = Sort.MergeSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));
            
            sortedSet = Sort.MergeSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.QuickSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.QuickSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.QuickSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        [TestMethod()]
        public void RandomQuickSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.RandomQuickSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.RandomQuickSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.RandomQuickSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        [TestMethod()]
        public void CountingSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.CountingSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.CountingSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.CountingSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        [TestMethod()]
        public void RadixSortTest()
        {
            var set = this.createSet();
            var sortedSet = Sort.RadixSort(set);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            set = this.createSet();
            sortedSet = Sort.RadixSort(set, true);
            Assert.IsTrue(this.testSetAscending(sortedSet));

            sortedSet = Sort.RadixSort(set, false);
            Assert.IsTrue(this.testSetDescending(sortedSet));
        }

        #region Private Methods
        /// <summary>
        /// Create a random set of integers, of random length and with random values
        /// </summary>
        /// <returns></returns>
        public int[] createSet()
        {
            Random rnd = new Random();
            int length = rnd.Next(500);

            int[] set = new int[length];
            for (int i = 0; i < length; i++)
                set[i] = rnd.Next(1000, 10000000);

            return set;
        }

        /// <summary>
        /// Tests if the given integer set has been sorted in ascending order
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool testSetAscending(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] > input[i + 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Tests if the given integer set has been sorted in descending order
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool testSetDescending(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] < input[i + 1])
                    return false;
            }

            return true;
        }
        #endregion
    }
}