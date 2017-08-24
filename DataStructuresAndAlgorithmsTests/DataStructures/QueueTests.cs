using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructuresAndAlgorithms.DataStructures.QueueExceptions;

namespace DataStructuresAndAlgorithms.DataStructures.Tests
{
    [TestClass()]
    public class QueueTests
    {
        [TestClass()]
        public class QueueArrayTests
        {
            [TestMethod()]
            public void DefaultConstructorTest()
            {
                Queue queue = new QueueArray();
                object[] outputQueue = getQueueArray(queue);

                Assert.AreEqual(10, outputQueue.Length);
                for (int i = 0; i < outputQueue.Length; i++)
                    Assert.IsNull(outputQueue[i]);
            }

            [TestMethod()]
            public void ConstructorTest()
            {
                Queue queue = new QueueArray(3);
                object[] outputQueue = getQueueArray(queue);

                Assert.AreEqual(3, outputQueue.Length);
                for (int i = 0; i < outputQueue.Length; i++)
                    Assert.IsNull(outputQueue[i]);

                queue = new QueueArray(137);
                outputQueue = getQueueArray(queue);
                Assert.AreEqual(137, outputQueue.Length);
                for (int i = 0; i < outputQueue.Length; i++)
                    Assert.IsNull(outputQueue[i]);
            }

            [TestMethod()]
            public void IncrementReadPointerTest()
            {
                Queue queue = new QueueArray();
                Assert.AreEqual(0, getReadPointer(queue));

                PrivateObject pri = new PrivateObject(queue);
                pri.Invoke("incrementReadPointer");
                Assert.AreEqual(1, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //2
                pri.Invoke("incrementReadPointer"); //3
                pri.Invoke("incrementReadPointer"); //4
                pri.Invoke("incrementReadPointer"); //5
                pri.Invoke("incrementReadPointer"); //6
                Assert.AreEqual(6, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //7
                pri.Invoke("incrementReadPointer"); //8
                pri.Invoke("incrementReadPointer"); //9
                Assert.AreEqual(9, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //0
                Assert.AreEqual(0, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //1
                Assert.AreEqual(1, getReadPointer(queue));


                queue = new QueueArray(3);
                pri = new PrivateObject(queue);
                Assert.AreEqual(0, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //1
                pri.Invoke("incrementReadPointer"); //2
                Assert.AreEqual(2, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //0
                Assert.AreEqual(0, getReadPointer(queue));
                pri.Invoke("incrementReadPointer");
                Assert.AreEqual(1, getReadPointer(queue));
            }

            [TestMethod()]
            public void DecrementReadPointerTest()
            {
                Queue queue = new QueueArray();
                PrivateObject pri = new PrivateObject(queue);

                Assert.AreEqual(0, getReadPointer(queue));
                pri.Invoke("incrementReadPointer"); //1
                Assert.AreEqual(1, getReadPointer(queue));
                pri.Invoke("decrementReadPointer"); //0
                Assert.AreEqual(0, getReadPointer(queue));
                pri.Invoke("decrementReadPointer"); //9
                Assert.AreEqual(9, getReadPointer(queue));


                queue = new QueueArray(3);
                pri = new PrivateObject(queue);

                Assert.AreEqual(0, getReadPointer(queue));
                pri.Invoke("decrementReadPointer"); //2
                Assert.AreEqual(2, getReadPointer(queue));
                pri.Invoke("decrementReadPointer"); //1
                Assert.AreEqual(1, getReadPointer(queue));
            }

            [TestMethod()]
            public void EnqueueTest()
            {
                Queue queue = new QueueArray();
                queue.Enqueue(5);
                queue.Enqueue("this");
                queue.Enqueue(15.5);

                object[] outputQueue = getQueueArray(queue);
                Assert.AreEqual(10, outputQueue.Count());
                Assert.AreEqual(5, outputQueue[0]);
                Assert.AreEqual("this", outputQueue[1]);
                Assert.AreEqual(15.5, outputQueue[2]);
                Assert.IsNull(outputQueue[3]);
                Assert.IsNull(outputQueue[9]);


                queue = new QueueArray(3);
                queue.Enqueue(5);
                queue.Enqueue(7);
                queue.Enqueue(9);
                queue.Enqueue(11);
                queue.Enqueue(13);
                outputQueue = getQueueArray(queue);
                Assert.AreEqual(5, outputQueue[0]);
                Assert.AreEqual(7, outputQueue[1]);
                Assert.AreEqual(9, outputQueue[2]);
                Assert.AreEqual(11, outputQueue[3]);
                Assert.AreEqual(13, outputQueue[4]);
                Assert.AreEqual(null, outputQueue[5]);
            }

            [TestMethod()]
            public void DequeueTest()
            {
                dequeueTest(new QueueArray());
            }

            [TestMethod()]
            public void PeekTest()
            {
                peekTest(new QueueArray());
            }

            [TestMethod()]
            public void FullTest()
            {
                fullTest(new QueueArray());
            }

            [TestMethod()]
            public void AdditionalTest()
            {
                Queue queue = new QueueArray(3);
                queue.Enqueue(5);
                queue.Enqueue(7);
                queue.Enqueue(9);
                queue.Enqueue(11);
                Assert.AreEqual(5, queue.Peek());
                Assert.AreEqual(5, queue.Dequeue());

                queue.Enqueue(13);
                Assert.AreEqual(7, queue.Peek());
                queue.Enqueue(15);
                Assert.AreEqual(7, queue.Peek());
                Assert.AreEqual(7, queue.Dequeue());
                Assert.AreEqual(9, queue.Dequeue());

                queue.Enqueue(17);
                Assert.AreEqual(11, queue.Peek());
                queue.Enqueue(19);
                queue.Enqueue(21);
                Assert.AreEqual(11, queue.Peek());

                queue.Enqueue(23);
                Assert.AreEqual(11, queue.Dequeue());
                Assert.AreEqual(13, queue.Dequeue());
                Assert.AreEqual(15, queue.Dequeue());
                Assert.AreEqual(17, queue.Dequeue());
                Assert.AreEqual(19, queue.Dequeue());
                Assert.AreEqual(21, queue.Dequeue());
                Assert.AreEqual(23, queue.Dequeue());
            }
        }

        [TestClass()]
        public class QueueListTests
        {
            [TestMethod()]
            public void EnqueueTest()
            {
                Queue queue = new QueueList();
                queue.Enqueue(5);
                queue.Enqueue(7);
                queue.Enqueue(9);

                List<object> outputQueue = getQueueList(queue);
                Assert.AreEqual(3, outputQueue.Count);
                Assert.AreEqual(5, outputQueue[0]);
                Assert.AreEqual(7, outputQueue[1]);
                Assert.AreEqual(9, outputQueue[2]);

                queue = new QueueList();
                queue.Enqueue("this");
                queue.Enqueue("is");
                queue.Enqueue(1);
                queue.Enqueue("test");

                outputQueue = getQueueList(queue);
                Assert.AreEqual(4, outputQueue.Count);
                Assert.AreEqual("this", outputQueue[0]);
                Assert.AreEqual("is", outputQueue[1]);
                Assert.AreEqual(1, outputQueue[2]);
                Assert.AreEqual("test", outputQueue[3]);
            }

            [TestMethod()]
            public void DequeueTest()
            {
                Queue queue = new QueueList();
                dequeueTest(queue);
            }

            [TestMethod()]
            public void PeekTest()
            {
                Queue queue = new QueueList();
                peekTest(queue);
            }

            [TestMethod()]
            public void FullTest()
            {
                fullTest(new QueueList());
            }
        }

        [TestClass()]
        public class QueueBuiltInTests
        {
            [TestMethod()]
            public void EnqueueTest()
            {
                Queue queue = new BuiltInQueue();
                queue.Enqueue(5);
                queue.Enqueue(7);
                queue.Enqueue(9);

                var outputQueue = getQueueBuiltIn(queue);
                Assert.AreEqual(3, outputQueue.Count);
                Assert.AreEqual(5, outputQueue.Dequeue());
                Assert.AreEqual(7, outputQueue.Dequeue());
                Assert.AreEqual(9, outputQueue.Dequeue());
            }

            [TestMethod()]
            public void DequeueTest()
            {
                dequeueTest(new BuiltInQueue());
            }

            [TestMethod()]
            public void PeekTest()
            {
                peekTest(new BuiltInQueue());
            }

            [TestMethod()]
            public void FullTest()
            {
                fullTest(new BuiltInQueue());
            }
        }

        #region private methods
        private static List<object> getQueueList(Queue queue)
        {
            PrivateObject pri = new PrivateObject(queue);
            return (List<object>)pri.GetFieldOrProperty("queue");
        }
        private static System.Collections.Queue getQueueBuiltIn(Queue queue)
        {
            PrivateObject pri = new PrivateObject(queue);
            return (System.Collections.Queue)pri.GetFieldOrProperty("queue");
        }
        private static object[] getQueueArray(Queue queue)
        {
            PrivateObject pri = new PrivateObject(queue);
            return (object[])pri.GetFieldOrProperty("queue");
        }
        private static void dequeueTest(Queue queue)
        {
            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (QueueEmptyException e)
            {
                Assert.IsNotNull(e);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            queue.Enqueue("this");
            Assert.AreEqual("this", queue.Dequeue());
            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (QueueEmptyException e)
            {
                Assert.IsNotNull(e);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(9);
            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual(7, queue.Dequeue());
            Assert.AreEqual(9, queue.Dequeue());
            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (QueueEmptyException e)
            {
                Assert.IsNotNull(e);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        private static void peekTest(Queue queue)
        {
            try
            {
                queue.Peek();
                Assert.Fail();
            }
            catch (QueueEmptyException e)
            {
                Assert.IsNotNull(e);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(9);
            Assert.AreEqual(5, queue.Peek());
            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual(7, queue.Peek());
            Assert.AreEqual(7, queue.Dequeue());
            Assert.AreEqual(9, queue.Peek());
            Assert.AreEqual(9, queue.Dequeue());
            try
            {
                queue.Peek();
                Assert.Fail();
            }
            catch (QueueEmptyException e)
            {
                Assert.IsNotNull(e);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsNotNull(e);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        private static void fullTest(Queue queue)
        {
            Random rnd = new Random();
            int length = rnd.Next(2000, 5000);
            int[] referenceArray = new int[length];

            for (int i = 0; i < referenceArray.Length; i++)
            {
                int element = rnd.Next(10, 50000);
                referenceArray[i] = element;
                queue.Enqueue(element);
            }

            int countOfElements = 0;
            while (queue.HasNext())
            {
                Assert.AreEqual(referenceArray[countOfElements], queue.Peek());
                Assert.AreEqual(referenceArray[countOfElements], queue.Dequeue());
                countOfElements++;
            }
            Assert.AreEqual(countOfElements, length);
        }
        private static int getReadPointer(Queue queue)
        {
            PrivateObject pri = new PrivateObject(queue);
            return (int)pri.GetFieldOrProperty("queueReadPointer");
        }
        #endregion
    }
}