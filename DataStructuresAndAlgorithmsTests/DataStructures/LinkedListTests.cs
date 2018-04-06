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
            currentNode = node.GetCurrentNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
            
            //get the next Node from the Linked List
            var nextNode = node.GetNext();
            currentNode = nextNode;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(6, currentNode.Data);

            //get the following node
            nextNode = node.GetNext();
            currentNode = nextNode;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(12, currentNode.Data);

            nextNode = node.GetNext();
            currentNode = nextNode;
            Assert.IsNotNull(currentNode);

            //test removing node from list
            currentNode = node.Head();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);

            currentNode = node.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(6, currentNode.Data);
            node.RemoveCurrentNode();
            currentNode = node.GetCurrentNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(12, currentNode.Data);

            //remove head from list
            currentNode = node.Head();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
            node.RemoveCurrentNode();
            currentNode = node.GetCurrentNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(12, currentNode.Data);
        }
        
        //Basic test for linked list that should always be ordered by data
        [TestMethod()]
        public void OrderedTestAddInOrder()
        {
            var list = new OrderedLinkedList();
            list.Add(5);

            var headNode = list.Head();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            var currentNode = list.GetNext();
            Assert.AreEqual(currentNode, headNode);

            list.Add(7);
            headNode = list.Head();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);

            list.Add(9);
            headNode = list.Head();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);

            //remove Node test
            currentNode = list.Head();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            list.RemoveCurrentNode();
            currentNode = list.GetCurrentNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            currentNode = list.Head();
            Assert.AreEqual(5, currentNode.Data);
            currentNode = list.GetNext();
            Assert.AreEqual(9, currentNode.Data);
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

            var headNode = list.Head();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(5, headNode.Data);
            Assert.IsNotNull(headNode.Next);

            var currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(8, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);


            list.Add(1);
            headNode = list.Head();
            Assert.IsNotNull(headNode);
            Assert.AreEqual(1, headNode.Data);
            Assert.IsNotNull(headNode.Next);

            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(8, currentNode.Data);
            Assert.IsNotNull(currentNode.Next);

            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
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
            var currentNode = list.Head();
            var nextNode = list.GetNext();
            while (currentNode.Next != null)
            {
                nextNode = list.GetNext();

                if ((int)currentNode.Data > (int)nextNode.Data)
                    Assert.Fail();

                iterations++;
                currentNode = list.GetCurrentNode();
            }

            Assert.AreEqual(numOfElements, iterations + 1);
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
            var head = list.Head();
            Assert.IsNotNull(head);
            Assert.AreEqual(5, head.Data);
            Assert.IsNull(head.Previous);

            var tail = list.Tail();
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
            DoublyLinkedList list = new SimpleDLL();

            list.Add(5);
            var head = list.Head();
            Assert.IsNotNull(head);
            Assert.AreEqual(5, head.Data);
            Assert.IsNull(head.Next.Next);
            Assert.IsNull(head.Previous);

            list.Add(7);
            head = list.Head();
            Assert.AreEqual(5, head.Data);
            var currentNode = list.GetNext();
            Assert.AreEqual(7, currentNode.Data);

            list.Add(9);
            head = list.Head();
            Assert.AreEqual(5, head.Data);
            currentNode = list.GetNext();
            Assert.AreEqual(7, currentNode.Data);
            currentNode = list.GetNext();
            Assert.AreEqual(9, currentNode.Data);
            Assert.IsNull(currentNode.Next);

            list.Add(11);
            currentNode = list.GetCurrentNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(11, currentNode.Data);
            var tail = list.Tail();
            Assert.IsNotNull(tail);
            Assert.IsNotNull(tail.Previous);
            Assert.AreEqual(11, tail.Data);
        }

        [TestMethod()]
        public void DoublyLinkedListTraverseTest()
        {
            var list = new SimpleDLL();

            list.Add(5);
            list.Add(7);
            list.Add(9);
            list.Add(11);

            var head = list.Head();
            Assert.AreEqual(5, head.Data);
            var currentNode = list.GetNext();
            Assert.AreEqual(7, currentNode.Data);
            currentNode = list.GetNext();
            Assert.AreEqual(9, currentNode.Data);
            currentNode = list.GetNext();
            Assert.AreEqual(11, currentNode.Data);
            Assert.IsNull(currentNode.Next);
            Assert.AreEqual(currentNode, list.Tail());
            currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.IsNull(currentNode.Next);
            Assert.AreEqual(11, currentNode.Data);

            currentNode = list.GetPreviousNode();
            Assert.AreEqual(9, currentNode.Data);
            currentNode = list.GetPreviousNode();
            Assert.AreEqual(7, currentNode.Data);
            currentNode = list.GetPreviousNode();
            Assert.AreEqual(5, currentNode.Data);
            Assert.AreEqual(currentNode, list.Head());
            Assert.IsNull(currentNode.Previous);
            currentNode = list.GetPreviousNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(5, currentNode.Data);
        }

        [TestMethod()]
        public void DoublyLinkedListRemoveNodesTest()
        {
            var list = new SimpleDLL();

            list.Add(5);
            list.Add(7);
            list.Add(9);

            //Remove in middle of list
            var head = list.Head();
            Assert.IsNotNull(head);
            Assert.AreEqual(5, head.Data);
            var currentNode = list.GetNext();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(7, currentNode.Data);
            list.RemoveCurrentNode();
            currentNode = list.GetCurrentNode();
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            Assert.IsNull(currentNode.Next);
            Assert.AreEqual(currentNode.Previous, list.Head());

            //remove tail node
            list.Add(11);   //5 -> 9 -> 11
            var tail = list.Tail();
            while (list.GetCurrentNode() != tail)   //move currentNode to tail
                currentNode = list.GetNext();
            list.RemoveCurrentNode();
            tail = list.Tail();
            currentNode = list.GetCurrentNode();
            Assert.IsNotNull(tail);
            Assert.IsNotNull(currentNode);
            Assert.AreEqual(9, currentNode.Data);
            Assert.AreEqual(9, tail.Data);
            Assert.AreEqual(currentNode, tail);

            //remove head node
            list.Add(13);   //5 -> 9 -> 13
            head = list.Head();
            while (list.GetPreviousNode() != head)  //move currentNode to head
                currentNode = list.GetPreviousNode();
            currentNode = list.GetCurrentNode();
            Assert.AreEqual(5, currentNode.Data);
            Assert.AreEqual(5, head.Data);
            Assert.AreEqual(currentNode, head);
            list.RemoveCurrentNode();
            currentNode = list.GetCurrentNode();
            head = list.Head();
            Assert.IsNotNull(currentNode);
            Assert.IsNotNull(head);
            Assert.AreEqual(9, currentNode.Data);
            Assert.AreEqual(9, head.Data);
            Assert.AreEqual(currentNode, head);
        }
    }
}