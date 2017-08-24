using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.Tests
{
    [TestClass()]
    public class StackTests
    {
        [TestClass()]
        public class Array
        {
            [TestMethod()]
            public void DefaultConstructorTest()
            {
                var stack = new StackArray();
                int initialSize = getInitialSize(stack);
                Assert.AreEqual(10, initialSize);
                int stackSize = getArraySize(stack);
                Assert.AreEqual(initialSize, stackSize);
            }

            [TestMethod()]
            public void ConstructorTest()
            {
                Stack stack = new StackArray(12);
                int initialSize = getInitialSize(stack);
                Assert.AreEqual(12, initialSize);
                int stackSize = getArraySize(stack);
                Assert.AreEqual(initialSize, stackSize);
            }            

            [TestMethod()]
            public void PushTest()
            {
                Stack stack = new StackArray(3);
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);

                int?[] stackArray = getArray(stack);
                Assert.IsNotNull(stackArray);
                Assert.AreEqual(6, stackArray.Length);
                Assert.AreEqual(1, stackArray[0]);
                Assert.AreEqual(2, stackArray[1]);
                Assert.AreEqual(3, stackArray[2]);
                Assert.AreEqual(4, stackArray[3]);
                Assert.IsNull(stackArray[4]);
                Assert.IsNull(stackArray[5]);
            }

            [TestMethod()]
            public void PopTest()
            {
                Stack stack = new StackArray(3);
                stack.Push(1);
                var output = stack.Pop();
                Assert.AreEqual(1, output);
                output = stack.Pop();
                Assert.IsNull(output);

                stack.Push(2);
                stack.Push(5);
                stack.Push(7);
                output = stack.Pop();
                Assert.AreEqual(7, output);
                output = stack.Pop();
                Assert.AreEqual(5, output);
                output = stack.Pop();
                Assert.AreEqual(2, output);
                output = stack.Pop();
                Assert.IsNull(output);
            }

            [TestMethod()]
            public void PeekTest()
            {
                Stack stack = new StackArray();
                stack.Push(5);
                var peek = stack.Peek();
                Assert.IsNotNull(peek);
                Assert.AreEqual(5, peek);
                peek = stack.Peek();
                Assert.IsNotNull(peek);
                Assert.AreEqual(5, peek);
                var pop = stack.Pop();
                Assert.IsNotNull(pop);
                Assert.AreEqual(5, pop);
                peek = stack.Peek();
                Assert.IsNull(peek);
                Assert.IsNull(stack.Pop());
            }

            [TestMethod()]
            public void FullTest()
            {
                Stack stack = new StackArray(100);
                int testLength = 512;
                Random rnd = new Random();

                int[] comparisonArray = new int[testLength];
                for (int i = 0; i < testLength; i++)
                {
                    int element = rnd.Next(0, 10000000);
                    comparisonArray[comparisonArray.Length - i - 1] = element;
                    stack.Push(element);
                }

                for (int i = 0; i < comparisonArray.Length; i++)
                {
                    Assert.AreEqual(comparisonArray[i], stack.Peek());
                    Assert.AreEqual(comparisonArray[i], stack.Pop());
                }
            }
        }

        [TestClass()]
        public class List
        {
            [TestMethod()]
            public void DefaultConstructorTest()
            {
                Stack stack = new StackList();
                var list = getList(stack);
                Assert.IsNotNull(list);
            }

            [TestMethod()]
            public void PushTest()
            {
                Stack stack = new StackList();
                stack.Push(3);
                stack.Push(5);
                stack.Push(7);

                var outputStack = getList(stack);
                Assert.AreEqual(3, outputStack.Count);
                Assert.AreEqual(7, outputStack.First());
                Assert.AreEqual(7, outputStack[0]);
                Assert.AreEqual(5, outputStack[1]);
                Assert.AreEqual(3, outputStack[2]);
            }

            [TestMethod()]
            public void PeekTest()
            {
                Stack stack = new StackList();

                Assert.IsNull(stack.Peek());

                stack.Push(5);
                Assert.AreEqual(5, stack.Peek());
                Assert.AreEqual(5, stack.Peek());

                stack.Push(7);
                Assert.AreEqual(7, stack.Peek());
                Assert.AreEqual(7, stack.Peek());
            }

            [TestMethod()]
            public void PopTest()
            {
                Stack stack = new StackList();
                stack.Push(5);
                Assert.AreEqual(5, stack.Peek());
                Assert.AreEqual(5, stack.Pop());
                Assert.IsNull(stack.Peek());
                Assert.IsNull(stack.Pop());

                stack.Push(7);
                stack.Push(9);
                Assert.AreEqual(9, stack.Pop());
                Assert.AreEqual(7, stack.Peek());
                Assert.AreEqual(7, stack.Pop());
                Assert.IsNull(stack.Pop());
            }

            [TestMethod()]
            public void FullTest()
            {
                Stack stack = new StackList();
                int testLength = 512;
                Random rnd = new Random();

                int[] comparisonArray = new int[testLength];
                for (int i = 0; i < testLength; i++)
                {
                    int element = rnd.Next(0, 10000000);
                    comparisonArray[comparisonArray.Length - i - 1] = element;
                    stack.Push(element);
                }

                for (int i = 0; i < comparisonArray.Length; i++)
                {
                    Assert.AreEqual(comparisonArray[i], stack.Peek());
                    Assert.AreEqual(comparisonArray[i], stack.Pop());
                }
            }
        }

        [TestClass()]
        public class BuiltIn
        {
            [TestMethod()]
            public void DefaultConstructorTest()
            {
                Assert.IsTrue(true);
            }

            [TestMethod()]
            public void PushTest()
            {
                Stack stack = new StackBuiltIn();
                stack.Push(3);
                stack.Push(5);
                stack.Push(7);

                var outputStack = getBIStack(stack);
                Assert.AreEqual(3, outputStack.Count);
                Assert.AreEqual(7, outputStack.Pop());
                Assert.AreEqual(5, outputStack.Pop());
                Assert.AreEqual(3, outputStack.Pop());
            }

            [TestMethod()]
            public void PeekTest()
            {
                Stack stack = new StackBuiltIn();

                stack.Push(5);
                Assert.AreEqual(5, stack.Peek());
                Assert.AreEqual(5, stack.Peek());

                stack.Push(7);
                Assert.AreEqual(7, stack.Peek());
                Assert.AreEqual(7, stack.Peek());
            }

            [TestMethod()]
            public void PopTest()
            {
                Stack stack = new StackBuiltIn();
                stack.Push(5);
                Assert.AreEqual(5, stack.Peek());
                Assert.AreEqual(5, stack.Pop());
                //Assert.IsNull(stack.Peek());
                //Assert.IsNull(stack.Pop());

                stack.Push(7);
                stack.Push(9);
                Assert.AreEqual(9, stack.Pop());
                Assert.AreEqual(7, stack.Peek());
                Assert.AreEqual(7, stack.Pop());
                //Assert.IsNull(stack.Pop());
            }
        }

        #region private methods
        private static int getInitialSize(Stack stack)
        {
            PrivateObject pri = new PrivateObject(stack);
            return (int)pri.GetFieldOrProperty("initialSize");
        }
        private static int getArraySize(Stack stack)
        {
            PrivateObject pri = new PrivateObject(stack);
            int?[] stackArray = (int?[])pri.GetFieldOrProperty("stack");
            return stackArray.Length;
        }
        private static int?[] getArray(Stack stack)
        {
            PrivateObject pri = new PrivateObject(stack);
            return (int?[])pri.GetFieldOrProperty("stack");
        }
        private static List<int> getList(Stack stack)
        {
            PrivateObject pri = new PrivateObject(stack);
            return (List<int>)pri.GetFieldOrProperty("stack");
        }
        private static System.Collections.Stack getBIStack(Stack stack)
        {
            PrivateObject pri = new PrivateObject(stack);
            return (System.Collections.Stack)pri.GetFieldOrProperty("stack");
        }
        #endregion
    }
}