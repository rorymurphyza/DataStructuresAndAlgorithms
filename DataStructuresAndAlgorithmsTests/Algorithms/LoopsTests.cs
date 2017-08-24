using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJM.Personal;
using System.Reflection;

namespace DataStructuresAndAlgorithms.Algorithms.Tests
{
    [TestClass()]
    public class LoopsTests
    {
        int[] sampleArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int sumOfSampleArray = 55;

        [TestMethod()]
        public void SumOfElementsUsingForLoopTest()
        {
            Assert.AreEqual(sumOfSampleArray, Loops.SumOfArrayUsingForLoop(sampleArray));
        }

        [TestMethod()]
        public void SumOfElementsUsingForEachLoopTest()
        {
            Assert.AreEqual(sumOfSampleArray, Loops.SumOfArrayUsingForEachLoop(sampleArray));
        }

        [TestMethod()]
        public void SumOfArrayUsingAggregateTest()
        {
            Assert.AreEqual(sumOfSampleArray, Loops.SumOfArrayUsingAggregate(sampleArray));
        }

        [TestMethod()]
        public void CreateNewArrayFromOldForLoopTest()
        {
            Assert.AreEqual(sampleArray.Length, Loops.CreateNewArrayFromOldForLoop(sampleArray).Length);
            Assert.AreEqual(sumOfSampleArray, Loops.SumOfArrayUsingAggregate(Loops.CreateNewArrayFromOldForLoop(sampleArray)));
        }

        [TestMethod()]
        public void CreateNewArrayFromOldForeachLoopTest()
        {
            Assert.AreEqual(sampleArray.Length, Loops.CreateNewArrayFromOldForeachLoop(sampleArray).Length);
            Assert.AreEqual(sumOfSampleArray, Loops.SumOfArrayUsingAggregate(Loops.CreateNewArrayFromOldForeachLoop(sampleArray)));
        }

        [TestMethod()]
        public void CreateNewArrayFromOldWithMapTest()
        {
            Assert.AreEqual(sampleArray.Length, Loops.CreateNewArrayFromOldWithMap(sampleArray).Length);
            Assert.AreEqual(sumOfSampleArray, Loops.SumOfArrayUsingAggregate(Loops.CreateNewArrayFromOldWithMap(sampleArray)));
        }

        [TestMethod()]
        public void ReturnSubsetArrayUsingForTest()
        {
            int start = 2;
            int end = 4;
            var output = Loops.ReturnSubsetArrayUsingFor(sampleArray, start, end);
            Assert.AreEqual(output[0], sampleArray[2]);
            Assert.AreEqual(output[1], sampleArray[3]);
            Assert.AreEqual(output[2], sampleArray[4]);
            Assert.AreEqual(output.Length, 3);
        }

        [TestMethod()]
        public void ReturnSubsetArrayUsingRangeTest()
        {
            int start = 2;
            int end = 4;
            var output = Loops.ReturnSubsetArrayUsingRange(sampleArray, start, end);
            Assert.AreEqual(output[0], sampleArray[2]);
            Assert.AreEqual(output[1], sampleArray[3]);
            Assert.AreEqual(output[2], sampleArray[4]);
            Assert.AreEqual(output.Length, 3);
        }
    }

    [TestClass()]
    public class LoopsTimeTests
    {
        int[] sampleArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int iterations = 10000000;

        [TestMethod()]
        public void SumOfElementsUsingForLoopTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.SumOfArrayUsingForLoop(sampleArray));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void SumOfElementsUsingForeachLoopTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.SumOfArrayUsingForEachLoop(sampleArray));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void SumOfElementsUsingAggregateLoopTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.SumOfArrayUsingAggregate(sampleArray));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void CreateNewArrayFromOldForLoopTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.CreateNewArrayFromOldForLoop(sampleArray));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void CreateNewArrayFromOldForeachLoopTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.CreateNewArrayFromOldForeachLoop(sampleArray));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void CreateNewArrayFromOldWithMapTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.CreateNewArrayFromOldWithMap(sampleArray));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void ReturnSubsetArrayUsingForTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.ReturnSubsetArrayUsingFor(sampleArray, 2, 4));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }

        [TestMethod()]
        public void ReturnSubsetArrayUsingRangeTest()
        {
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < iterations; i++)
                totalTime += Method.Time(() => Loops.ReturnSubsetArrayUsingRange(sampleArray, 2, 4));
            Console.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod(), totalTime.TotalMilliseconds));
        }
    }
}