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
        /// Get the Head node of the List
        /// </summary>
        /// <returns></returns>
        virtual public Node Head()
        {
            currentNode = head;
            return head;
        }

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
            //Shift current Node to next Node, if possible, and return it
            if (currentNode.Next != null)
                currentNode = currentNode.Next;
            return currentNode;
        }

        /// <summary>
        /// Returns the Node that the Node pointer is currently pointed at
        /// </summary>
        /// <returns></returns>
        virtual public Node GetCurrentNode()
        {
            return currentNode;
        }

        /// <summary>
        /// Removes the Node at the current Node pointer.
        /// Returns bool indicating success
        /// </summary>
        /// <returns></returns>
        abstract public bool RemoveCurrentNode();
        
        /// <summary>
        /// The current Node pointer. Used to show which Node we are currently pointed at
        /// </summary>
        protected Node currentNode;
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
                head = new Node
                {
                    Data = data,
                    Next = null                    
                };
                currentNode = head;
            }
            else
            {
                //create the required node
                Node toAdd = new Node
                {
                    Data = data,
                    Next = null
                };

                //scan through the Linked List to find the last node
                Node node = head; //start at the first node
                while (node.Next != null)
                    node = node.Next;

                node.Next = toAdd; //insert the new node at the end
            }
        }

        public override bool RemoveCurrentNode()
        {
            //check if the Node to be removed is the head Node
            if (head == currentNode)
            {
                head = head.Next;
                currentNode = head;
                return true;
            }

            //scan through Linked List until we find the currentNode
            Node thisNode = head;
            while (thisNode.Next != null)
            {
                if (thisNode.Next == currentNode)
                {
                    thisNode.Next = currentNode.Next;
                    currentNode = thisNode.Next;
                    return true;
                }
                thisNode = thisNode.Next;
            }

            throw new Exception("Node not found");
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
                head = new Node
                {
                    Data = data,
                    Next = null
                };
                return;
            }
            //create the new Node
            Node toAdd = new Node
            {
                Data = data
            };

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

        public override bool RemoveCurrentNode()
        {
            //check if the Node to be removed is the head Node
            if (head == currentNode)
            {
                head = head.Next;
                currentNode = head;
                return true;
            }

            //scan through Linked List until we find the currentNode
            Node thisNode = head;
            while (thisNode.Next != null)
            {
                if (thisNode.Next == currentNode)
                {
                    thisNode.Next = currentNode.Next;
                    currentNode = thisNode.Next;
                    return true;
                }
                thisNode = thisNode.Next;
            }

            throw new Exception("Node not found"); ;
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
        new protected Node currentNode;

        /// <summary>
        /// Returns the Head node of the list
        /// </summary>
        /// <returns></returns>
        new virtual public Node Head()
        {
            currentNode = head;
            return head;
        }

        /// <summary>
        /// Returns the next element of the Doubly-Linked List
        /// </summary>
        /// <returns></returns>
        new virtual public Node GetNext()
        {
            if (currentNode.Next != null)
                currentNode = currentNode.Next;
            return currentNode;
        }

        /// <summary>
        /// Returns the tail element of the Doubly-Linked List
        /// </summary>
        /// <returns></returns>
        virtual public Node Tail()
        {
            return tail;
        }

        /// <summary>
        /// Returns the current Node according to the pointer
        /// </summary>
        /// <returns></returns>
        new virtual public Node GetCurrentNode()
        {
            return currentNode;
        }

        //Returns the previous element in the list
        virtual public Node GetPreviousNode()
        {
            if (currentNode.Previous != null)
                currentNode = currentNode.Previous;
            return currentNode;
        }
    }

    public class SimpleDLL : DoublyLinkedList
    {
        public SimpleDLL()
        {
            head = new Node
            {
                Data = null,
                Previous = null
            };

            tail = new Node
            {
                Data = null,
                Next = null
            };

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
            Node toAdd = new Node
            {
                Data = data,
                Previous = tail,
                Next = null
            };
            tail.Next = toAdd;
            tail = toAdd;
        }

        public override bool RemoveCurrentNode()
        {
            if (currentNode == head)
            {
                head = currentNode.Next;
                currentNode = head;
                return true;
            }
            if (currentNode == tail)
            {
                tail = currentNode.Previous;
                currentNode = tail;
                return true;
            }

            //otherwise we have node in middle of list
            var prev = currentNode.Previous;
            var next = currentNode.Next;
            prev.Next = next;
            next.Previous = prev;
            currentNode = next;

            return false;
        }
    }

}
