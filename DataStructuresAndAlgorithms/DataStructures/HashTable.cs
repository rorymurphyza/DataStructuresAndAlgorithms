using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// A basic HashTable implementation with elementary has check.
    /// If a collision is detected, the object is NOT inserted and returns false
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// The number of indices in the hash table. Default value is 1000
        /// </summary>
        public int Size = 1000;

        internal Dictionary<int, object> hashTable;

        /// <summary>
        /// Default constructor creates HashTable with size = 1000
        /// </summary>
        public HashTable()
        {
            hashTable = new Dictionary<int, object>();
        }

        internal object objectToHash;

        /// <summary>
        /// Constructor to set number of indices during invokation
        /// </summary>
        /// <param name="Size"></param>
        public HashTable(int Size) : this()
        {
            this.Size = Size;
        }

        /// <summary>
        /// Search for a given hash and return the object if found, null otherwise
        /// </summary>
        /// <param name="toFind"></param>
        /// <returns></returns>
        public virtual object Search(object toFind)
        {
            objectToHash = toFind;
            int hash = GetHashCode();

            object found;
            if (hashTable.TryGetValue(hash, out found))
            {
                return found;
            }

            return null;
        }

        /// <summary>
        /// Attempts to insert object into HashTable. Returns true if successful, false otherwise
        /// </summary>
        /// <param name="toInsert"></param>
        /// <returns></returns>
        public virtual bool Insert(object toInsert)
        {
            objectToHash = toInsert;
            int hash = GetHashCode();

            if (!hashTable.ContainsKey(hash))
            {
                hashTable[hash] = toInsert;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Attempts to remove object from the table. Returns true if successful, false otherwise
        /// </summary>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public virtual bool Remove(object toRemove)
        {
            objectToHash = toRemove;
            int hash = GetHashCode();

            object found;
            if (hashTable.TryGetValue(hash, out found))
            {
                hashTable.Remove(hash);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Overridden GetHashCode for custom implementation
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return objectToHash.GetHashCode();
        }
    }    

    /// <summary>
    /// A hash table implementation where collisions are stored in indexed List
    /// Implements the Separate Chaining method
    /// </summary>
    public class HashTableSeparateChaining : HashTable
    {
        /* The hash chaining method is done by attaching a linked list to
         * each index. If a collision happens, we simply add the object into
         * a linked list that attaches to the index.
         * Drawback is that we now have to iterate through the linked list
         */
        new private Dictionary<int, LinkedList<object>> hashTable;

        /// <summary>
        /// Default constructor that will create table with size = 1000
        /// </summary>
        public HashTableSeparateChaining()
        {
            hashTable = new Dictionary<int, LinkedList<object>>();
        }
        
        /// <summary>
        /// Constructor that allows maximum size of table to be specified
        /// </summary>
        /// <param name="size"></param>
        public HashTableSeparateChaining(int size) : this()
        {
            Size = size;
        }

        /// <summary>
        /// Insert the object into the HashTable. This call cannot fail and will always return true
        /// </summary>
        /// <param name="toInsert"></param>
        /// <returns></returns>
        public override bool Insert(object toInsert)
        {
            objectToHash = toInsert;
            int hash = GetHashCode();

            if (hashTable.ContainsKey(hash))
            {
                //we already have an entry for this, so we add it to the LinkedList
                var ll = hashTable[hash];
                ll.AddLast(toInsert);
                hashTable[hash] = ll;
            }
            else
            {
                LinkedList<object> ll = new LinkedList<object>();
                ll.AddLast(toInsert);
                hashTable.Add(hash, ll);
            }

            return true;
        }

        /// <summary>
        /// Search for a given hash and return the object if found, null otherwise
        /// </summary>
        /// <param name="toFind"></param>
        /// <returns></returns>
        public override object Search(object toFind)
        {
            objectToHash = toFind;
            int hash = GetHashCode();

            if (hashTable.ContainsKey(hash))
            {
                //we have an entry, so lets look for it
                var ll = hashTable[hash];
                foreach (object item in ll)
                {
                    if (item.Equals(toFind))
                        return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Removes a given object from the HashTable if found. Returns true if found and removed, false otherwise.
        /// </summary>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public override bool Remove(object toRemove)
        {
            objectToHash = toRemove;
            int hash = GetHashCode();

            if (hashTable.ContainsKey(hash))
            {
                //we have an entry, so let's remove it
                var ll = hashTable[hash];
                if (ll.Contains(toRemove))
                {
                    ll.Remove(toRemove);
                    hashTable[hash] = ll;
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// A hash table implementation to store items with collisions, using basic modulo referencing
    /// Implements the Linear Probing method, only available for integer classes here.
    /// </summary>
    public class HashTableLinearProbing : HashTable
    {
        new private int?[] hashTable;
        private new int objectToHash;
        private int pointer;
        private int prevPointer;

        /// <summary>
        /// Default constructor, with internal array Size = 1000
        /// </summary>
        public HashTableLinearProbing() : this(size: 1000)
        {
            
        }

        /// <summary>
        /// Default constructor to give internal array Size = size
        /// </summary>
        /// <param name="size"></param>
        public HashTableLinearProbing(int size)
        {
            Size = size;
            hashTable = new int?[Size];
        }

        /// <summary>
        /// Attempts to insert given value into the hashTable, will return true if insert was successful.
        /// </summary>
        /// <param name="toInsert"></param>
        /// <returns></returns>
        public bool Insert(int toInsert)
        {
            if (toInsert == int.MinValue)   //int.MinValue is a special value in this class, it indicates a deleted entry
                return false;

            objectToHash = toInsert;
            var hash = GetHashCode();    //the pointer will be the key for this
            pointer = hash;

            do
            {
                if ((hashTable[pointer] == null) || (hashTable[pointer] == int.MinValue))
                    //int.MinValue represents a deleted item, we want to write there if it has been deleted
                { 
                    hashTable[pointer] = toInsert;
                    return true;
                }
                if (hashTable[pointer] == toInsert) //already have this number in the table, cannot reinsert
                    return false;
                IncrementPointer();
            }
            while ((pointer != hash) && (hashTable[prevPointer] != null));
            return false;
        }

        /// <summary>
        /// Search the hashTable for a specific entry.
        /// This method ignores the deleted character (int.MinValue) and searches until a null is found
        /// </summary>
        /// <param name="toFind"></param>
        /// <returns></returns>
        public bool Search(int toFind)
        {
            if (toFind == int.MinValue) //int.MinValue is a special value
                return false;

            objectToHash = toFind;
            var hash = GetHashCode();
            pointer = hash;

            do
            {
                if (hashTable[pointer] == toFind)
                    return true;
                IncrementPointer();
            }
            while ((pointer != hash) && (hashTable[prevPointer] != null));
            return false;
        }

        /// <summary>
        /// Removes the given value from the table, returning true if a match was found and removed.
        /// Removed avlues are marked with the special character (int.MinValue)
        /// </summary>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public bool Remove(int toRemove)
        {
            if (toRemove == int.MinValue) //special value
                return false;

            if (!this.Search(toRemove)) //value is not in table
                return false;

            objectToHash = toRemove;
            var hash = GetHashCode();
            pointer = hash;

            do
            {
                if (hashTable[pointer] == toRemove)
                {
                    hashTable[pointer] = int.MinValue;
                    return true;
                }
                IncrementPointer();
            }
            while ((pointer != hash) && (hashTable[prevPointer] != null));
            return false;
        }

        /// <summary>
        /// Implement the modulo hashing specific for this class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return objectToHash % Size;
        }

        private void IncrementPointer()
        {
            prevPointer = pointer;
            pointer++;
            if (pointer == Size)
                pointer = 0;
        }
    }

    /// <summary>
    /// A hash table implementation to store items with collisions. Implements a int?[] for storage
    /// Implements the Quadratic Probing method
    /// </summary>
    public class HashTableQuadraticProbing : HashTable
    {
        new private int?[] hashTable;
        new private int objectToHash;
        private int pointer;
        private int k;  //the k value that will scan forward if needed
        private int prevPointer = 0; 

        /// <summary>
        /// Default constructor to give a Size = 1000
        /// </summary>
        public HashTableQuadraticProbing() : this(size: 1000)
        {

        }

        /// <summary>
        /// Constructor to specify size of array.
        /// </summary>
        /// <param name="size"></param>
        public HashTableQuadraticProbing(int size)
        {
            Size = size;
            hashTable = new int?[size];
        }

        /// <summary>
        /// Attempts to insert the given value into HashTableQuadraticProbing. Returns true if it could be inserted, false otherwise.
        /// </summary>
        /// <param name="toInsert"></param>
        /// <returns></returns>
        public bool Insert(int toInsert)
        {
            if (toInsert == int.MinValue)
                return false;

            objectToHash = toInsert;
            k = 0;
            pointer = GetHashCode();

            do
            {
                if ((hashTable[pointer] == null) || (hashTable[pointer] == int.MinValue))
                {
                    hashTable[pointer] = toInsert;
                    return true;
                }
                prevPointer = pointer;
                pointer = GetHashCode();
            }
            while ((pointer != int.MinValue) && (hashTable[prevPointer] != null));

            return false;
        }

        public bool Search(int toFind)
        {
            if (toFind == int.MinValue)
                return false;

            objectToHash = toFind;
            k = 0;
            pointer = GetHashCode();

            do
            {
                if (hashTable[pointer] == toFind)
                    return true;
                prevPointer = pointer;
                pointer = GetHashCode();
            }
            while ((pointer != int.MinValue) && (hashTable[prevPointer] != null));

            return false;
        }

        /// <summary>
        /// Implements the quadratic hashing function. Will return int.minvalue if the size of the array is exceeded.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hash = (objectToHash % Size) + (k * k);
            k++;
            if (hash >= Size)
                return int.MinValue;
            return hash;
        }
    }

    /// <summary>
    /// A hash table implementation to store items with collisions
    /// Implements the Double Hash method
    /// </summary>
    public class HashTableDoubleHash : HashTable
    {

    }
}