using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// Implementation of a queue object. A simple FIFO list.
    /// Very similar to a normal LinkedList, we just now have the ability to remove elements
    /// </summary>
    public abstract class Queue
    {
        /// <summary>
        /// Add an object to the queue
        /// </summary>
        /// <param name="input"></param>
        public abstract void Enqueue(object input);

        /// <summary>
        /// Returns the object at the front of the queue
        /// </summary>
        /// <returns></returns>
        public abstract object Dequeue();

        /// <summary>
        /// Returns the object at the front of the queue without removing it from the queue
        /// </summary>
        /// <returns></returns>
        public abstract object Peek();

        /// <summary>
        /// Returns a bool showing if there is an object in the queue to be returned
        /// </summary>
        /// <returns></returns>
        public abstract bool HasNext();
    }

    /// <summary>
    /// A generic queue of objects, made up on atomic array, stored as circular buffer
    /// </summary>
    public class QueueArray : Queue
    {
        private object[] queue;
        private int initialQueueSize;
        private int queueReadPointer = 0;
        private int queueWritePointer = 0;

        /// <summary>
        /// Default constructor, creates array with default length of 10
        /// </summary>
        public QueueArray()
        {
            queue = new object[10];
            initialQueueSize = 10;
        }

        /// <summary>
        /// Creates the new queue, with given initial length
        /// </summary>
        /// <param name="length"></param>
        public QueueArray(int length)
        {
            queue = new object[length];
            initialQueueSize = length;
        }

        public override void Enqueue(object input)
        {
            //check if array is full
            bool isFull = true;
            int index = 0;
            while (index < queue.Length)
            {
                if (queue[index] == null)
                {
                    isFull = false;
                    break;
                }
                index++;
            }

            if (!isFull)
            {
                queue[queueWritePointer] = input;
                incrementWritePointer();
            }
            else
            {
                object[] newArray = new object[queue.Length + initialQueueSize];
                for (int i = 0; i < queue.Length; i++)
                {
                    newArray[i] = queue[queueReadPointer];
                    incrementReadPointer();
                }
                queue = newArray;
                queueReadPointer = 0;
                queueWritePointer = 0;
                while (queue[queueWritePointer] != null)
                    incrementWritePointer();

                queue[queueWritePointer] = input;
                incrementWritePointer();
            }
        }

        public override object Dequeue()
        {
            object output = Peek();
            queue[queueReadPointer] = null;
            incrementReadPointer();
            return output;
        }

        public override object Peek()
        {
            if (HasNext())
                return queue[queueReadPointer];
            throw new QueueExceptions.QueueEmptyException("Queue is empty");
        }

        public override bool HasNext()
        {
            if (queue[queueReadPointer] != null)
                return true;
            return false;
        }

        private void incrementReadPointer()
        {
            queueReadPointer++;
            if (queueReadPointer > queue.Length - 1)
                queueReadPointer = 0;
        }

        private void decrementReadPointer()
        {
            if (queueReadPointer == 0)
                queueReadPointer = queue.Length - 1;
            else
                queueReadPointer--;
        }

        private void incrementWritePointer()
        {
            queueWritePointer++;
            if (queueWritePointer > queue.Length - 1)
                queueWritePointer = 0;
        }

        private void decrementWritePointer()
        {
            if (queueWritePointer == 0)
                queueWritePointer = queue.Length - 1;
            else
                queueWritePointer--;
        }
    }

    /// <summary>
    /// A generic queue of objects, made up of a List<object>
    /// </summary>
    public class QueueList : Queue
    {
        private List<object> queue;

        public QueueList()
        {
            queue = new List<object>();
        }

        public override void Enqueue(object input)
        {
            queue.Add(input);
        }

        public override object Dequeue()
        {
            object output = Peek();
            queue.RemoveAt(0);
            return output;
        }

        public override object Peek()
        {
            if (queue.Count > 0)
                return queue[0];
            throw new QueueExceptions.QueueEmptyException("Queue is empty");
        }

        public override bool HasNext()
        {
            if (queue.Count > 0)
                return true;
            return false;
        }
    }

    /// <summary>
    /// The C# built in queue.
    /// </summary>
    public class BuiltInQueue : Queue
    {
        private System.Collections.Queue queue;

        public BuiltInQueue()
        {
            queue = new System.Collections.Queue();
        }

        public override void Enqueue(object input)
        {
            queue.Enqueue(input);
        }

        public override object Dequeue()
        {
            return queue.Dequeue();
        }

        public override object Peek()
        {
            return queue.Peek();
        }

        public override bool HasNext()
        {
            if (queue.Count > 0)
                return true;
            return false;
        }
    }

    public class QueueExceptions
    {
        public class QueueEmptyException : Exception
        {
            public QueueEmptyException()
            {

            }

            public QueueEmptyException(string message) : base(message)
            {

            }
        }
    }
}
