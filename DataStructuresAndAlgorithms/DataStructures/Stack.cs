using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// Various implementations of the Stack data object, a LIFO object
    /// Push should add an element, pop should remove and return it
    /// Peek is optional and just return the element without removing it
    /// </summary>
    public abstract class Stack
    {
        /// <summary>
        /// Push a new element onto the stack
        /// </summary>
        /// <param name="i"></param>
        public abstract void Push(int i);

        /// <summary>
        /// Pop the top element from the stack
        /// </summary>
        /// <returns></returns>
        public abstract int? Pop();

        /// <summary>
        /// Peek at the top element. Does not remove from stack.
        /// </summary>
        /// <returns></returns>
        public abstract int? Peek();
    }

    public class StackArray : Stack
    {
        private int initialSize { get; set; }
        private int?[] stack;

        /// <summary>
        /// Initiate the StackArray with the default stack size of 10 elements
        /// </summary>
        public StackArray()
        {
            initialSize = 10;
            stack = new int?[initialSize];
            setNullArray();
        }

        /// <summary>
        /// Initiate the StackArray with a non-default size
        /// </summary>
        /// <param name="i"></param>
        public StackArray(int i)
        {
            initialSize = i;
            stack = new int?[initialSize];
            setNullArray();
        }

        public override void Push(int i)
        {
            int index = 0;
            while ((index < stack.Length) && (stack[index] != null))
            {
                index++;
            }
            if (index == stack.Length - 1) //we have filled the array
            {
                //increase array and copy into it
                int?[] tempStack = new int?[stack.Length + initialSize];
                Array.Copy(stack, tempStack, stack.Length);
                stack = tempStack;
            }
            stack[index] = i;
        }

        public override int? Pop()
        {
            return Pop(false);
        }

        public override int? Peek()
        {
            return Pop(true);
        }

        private int? Pop(bool peek)
        {
            int index = stack.Length - 1;
            while ((stack[index] == null) && (index > 0))
            {
                index--;
            }
            if (index < 0)
                return null;

            int? temp = stack[index];
            if (!peek)
                stack[index] = null;
            return temp;
        }
       
        private void setNullArray()
        {
            for (int i = 0; i < stack.Length; i++)
                stack[i] = null;
        }
    }

    public class StackList : Stack
    {
        private List<int> stack;

        public StackList()
        {
            stack = new List<int>();
        }

        public override void Push(int i)
        {
            stack.Insert(0, i);
        }

        public override int? Pop()
        {
            var output = this.Peek();
            if (output != null)
                stack.RemoveAt(0);
            return output;
        }

        public override int? Peek()
        {
            if (stack.Count != 0)
                return stack.First();
            return null;
        }
    }

    public class StackBuiltIn : Stack
    {
        private System.Collections.Stack stack;

        public StackBuiltIn()
        {
            stack = new System.Collections.Stack();
        }

        public override void Push(int i)
        {
            stack.Push(i);
        }

        public override int? Pop()
        {
            return (int?)stack.Pop();
        }

        public override int? Peek()
        {
            return (int?)stack.Peek();
        }
    }
}
