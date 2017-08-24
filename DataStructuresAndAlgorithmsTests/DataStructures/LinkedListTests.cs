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
    public class LinkedListTests
    {
        //Create a set of three nodes, making sure we can traverse it and get each value out
        [TestMethod()]
        public void SimpleLinkedListTest()
        {
            SimpleLinkedList node = new SimpleLinkedList();
            node.Add(5);
            node.Add(6);
            node.Add(12);
            
            //get the head Node from the Linked List
            SimpleLinkedList.Node currentNode;
            currentNode = node.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
            
            //get the next Node from the Linked List
            var nextNode = node.GetNext(currentNode);
            currentNode = nextNode;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(6, currentNode.Data);

            //get the following node
            nextNode = node.GetNext(currentNode);
            currentNode = nextNode;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(12, currentNode.Data);

            nextNode = node.GetNext(currentNode);
            currentNode = nextNode;
            Assert.IsNull(currentNode);
        }
        
        //Basic test for linked list that should always be ordered by data
        [TestMethod()]
        public void OrderedTestAddInOrder()
        {
            var list = new OrderedLinkedList();
            list.Add(5);

            var headNode = list.GetNext();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            var currentNode = list.GetNext(headNode);
            Assert.IsNull(currentNode);

            list.Add(7);
            headNode = list.GetNext();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            currentNode = list.GetNext(headNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            currentNode = list.GetNext(currentNode);
            Assert.IsNull(currentNode);

            list.Add(9);
            headNode = list.GetNext();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            currentNode = list.GetNext(headNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            currentNode = list.GetNext(currentNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            currentNode = list.GetNext(currentNode);
            Assert.IsNull(currentNode);
        }
        
        //Test a mostly ordered list
        [TestMethod()]
        public void OrderedTestAddOneOutOfOrder()
        {
            var list = new OrderedLinkedList();
            list.Add(5);
            list.Add(7);
            list.Add(9);
            list.Add(8);

            var headNode = list.GetNext();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            Assert.IsNotNull(headNode.Next);

            var currentNode = list.GetNext(headNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(8, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            Assert.IsNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNull(currentNode);


            list.Add(1);
            headNode = list.GetNext();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(1, headNode.Data);
            Assert.IsNotNull(headNode.Next);

            currentNode = list.GetNext(headNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(8, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            Assert.IsNull(currentNode.Next);

            currentNode = list.GetNext(currentNode);
            Assert.IsNull(currentNode);
        }

        //Test for ordered linked list that generates random numbers
        [TestMethod()]
        public void OrderedListRandomisedTest()
        {
            Random rnd = new Random();
            int numOfElements = rnd.Next(100, 1000);

            var list = new OrderedLinkedList();

            //add in the numbers to the list
            for (int i = 0; i < numOfElements; i++)
                list.Add(rnd.Next(1, 10000));

            //now, check them for orderedness
            int iterations = 1;
            var currentNode = list.GetNext();
            var nextNode = list.GetNext();
            while (currentNode.Next != null)
            {
                nextNode = list.GetNext(currentNode);

                if ((int)currentNode.Data > (int)nextNode.Data)
                    Assert.Fail();

                iterations++;
                currentNode = nextNode;
            }

            Assert.AreEqual(numOfElements, iterations);
        }   
    }

    [TestClass()]
    public class DoublyLinkedListTests
    {
        [TestMethod()]
        public void DoublyLinkedListBasicTest()
        {
            DoublyLinkedList list = new SimpleDLL();

            list.Add(5);
            var head = list.GetNext();
            Assert.IsNotNull(head);
            Assert.AreEqual(5, head.Data);
            Assert.IsNull(head.Previous);

            var tail = list.GetTail();
            Assert.IsNotNull(tail);
            Assert.IsNull(tail.Data);
            Assert.IsNotNull(tail.Previous);
            Assert.AreEqual(head.Next, tail);
            Assert.AreEqual(tail.Previous, head);
            Assert.IsTrue(head.Next.Equals(tail));
            Assert.IsTrue(tail.Previous.Equals(head));
        }

        [TestMethod()]
        public void DoublyLinkedListAddTest()
        {

        }
    }
}