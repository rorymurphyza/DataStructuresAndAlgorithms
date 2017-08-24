using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures
{
    public abstract class LinkedList
    {
        /// <summary>
        /// The basic node for a Linked List. At simplest, needs only data and next pointer.
        /// </summary>
        public class Node
        {
            public object Data;
            public Node Next = null;
        }

        /// <summary>
        /// Keeps track of the head of the Linked List
        /// </summary>
        protected Node head;

        /// <summary>
        /// Add a new entry to the linked list. Each implementation executes this differently
        /// </summary>
        /// <param name="data"></param>
        abstract public void Add(object data);

        /// <summary>
        /// Returns the head node in the list
        /// </summary>
        /// <returns></returns>
        virtual public Node GetNext()
        {
            return head;
        }
        
        /// <summary>
        /// Returns the next Node after the given Node. Will return null if no more nodes
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        virtual public Node GetNext(Node currentNode)
        {
            Node nextNode = null;
            if (currentNode.Next != null)
                nextNode = currentNode.Next;
            return nextNode;
        }
    }

    /// <summary>
    /// A sandbox for linked list and all variants.
    /// Linked list is amost always worse than an array for timing
    /// For random insertion: Linked list is O(1), array is O(n)
    /// For finding specific index: Linked list is O(n), array is O(1)
    /// </summary>
    public class SimpleLinkedList : LinkedList
    {
        /// <summary>
        /// Adds a new node to the linked list.
        /// Will create the head entry if required.
        /// </summary>
        /// <param name="data"></param>
        public override void Add(object data)
        {
            if (head == null)
            {
                //Linked List has ot been initialised yet, so create it
                head = new Node();

                head.Data = data;
                head.Next = null;
            }
            else
            {
                //create the required node
                Node toAdd = new Node();
                toAdd.Data = data;
                toAdd.Next = null;

                //scan through the Linked List to find the last node
                Node currentNode = head; //start at the first node
                while (currentNode.Next != null)
                    currentNode = currentNode.Next;

                currentNode.Next = toAdd; //insert the new node at the end
            }
        }
    }

    /// <summary>
    /// Linked List that contains an integer data value. 
    /// Will be ordered by default.
    /// </summary>
    public class OrderedLinkedList : LinkedList
    {
        /// <summary>
        /// Adds a new Node into the Linked List, preserving the ordering
        /// </summary>
        public override void Add(object data)
        {
            if (head == null)
            {
                head = new Node();
                head.Data = data;
                head.Next = null;
                return;
            }
            //create the new Node
            Node toAdd = new Node();
            toAdd.Data = data;

            //find the appropriate place to insert the new Node
            Node previousNode = null; 
            Node currentNode = head; //start at the head node

            bool found = false;
            while (!found)
            {
                if ((int)toAdd.Data > (int)currentNode.Data)
                {
                    if (currentNode.Next == null)
                    {
                        currentNode.Next = toAdd;
                        found = true;
                    }
                    else
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                }
                else
                {
                    if (previousNode == null)
                    {
                        toAdd.Next = currentNode;
                        head = toAdd;
                    }
                    else
                    {
                        toAdd.Next = currentNode;
                        previousNode.Next = toAdd;
                    }
                    found = true;
                }                
            }
        }
    }

    public abstract class DoublyLinkedList : LinkedList
    {
        /// <summary>
        /// The more complex node required for a Doubly Linked List. Must have forward and backward notation as well as data
        /// </summary>
        new public class Node
        {
            public object Data;
            public Node Previous;
            public Node Next;
        }

        new public Node head;
        public Node tail;

        /// <summary>
        /// Returns the head element of the Doubly-Linked List
        /// </summary>
        /// <returns></returns>
        new virtual public Node GetNext()
        {
            return head;
        }

        /// <summary>
        /// Returns the tail element of the Doubly-Linked List
        /// </summary>
        /// <returns></returns>
        virtual public Node GetTail()
        {
            return tail;
        }

        /// <summary>
        /// Return the next Node to the given Node
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        new virtual public Node GetNext(Node current)
        {
            return current.Next;
        }
    }

    public class SimpleDLL : DoublyLinkedList
    {
        public SimpleDLL()
        {
            head = new Node();
            head.Data = null;
            head.Previous = null;

            tail = new Node();
            tail.Data = null;
            tail.Next = null;

            head.Next = tail;
            tail.Previous = head;
        }

        public override void Add(object data)
        {
            if (head.Data == null)
            {
                head.Data = data;
                return;
            }
            if (tail.Data == null)
            {
                tail.Data = data;
                return;
            }
            Node toAdd = new Node();
            toAdd.Data = data;
            toAdd.Previous = tail;
            toAdd.Next = null;
            tail = toAdd;
        }
    }

}
