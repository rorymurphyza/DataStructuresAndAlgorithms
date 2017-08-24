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
    public class SearchTests
    {
        int[] sampleSet = new int[] { 5, 2, 1, 4, 5, 3, 9, 7, 15, 74, 25, 77, 69, 32, 54, 11 };
        int target1 = 5;
        int target2 = 77;
        int target3 = 201;

        [TestMethod()]
        public void BinarySearchTest()
        {
            var sortedSet = Sort.QuickSort(sampleSet);
            Assert.IsTrue(Search.BinarySearch(sampleSet, target1));
            Assert.IsTrue(Search.BinarySearch(sampleSet, target2));
            Assert.IsFalse(Search.BinarySearch(sampleSet, target3));
        }
    }
}