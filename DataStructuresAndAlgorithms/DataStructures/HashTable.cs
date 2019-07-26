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

        private Dictionary<int, object> hashTable;

        /// <summary>
        /// Default constructor creates HashTable with size = 1000
        /// </summary>
        public HashTable()
        {
            hashTable = new Dictionary<int, object>();
        }

        private object objectToHash;

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
         
        
    }

    /// <summary>
    /// A hash table implementation to store items with collisions
    /// Implements the Linear Probing method
    /// </summary>
    public class HashTableLinearProbing : HashTable
    {
    }

    /// <summary>
    /// A hash table implementation to store items with collisions
    /// Implements the Quadratic Probing method
    /// </summary>
    public class HashTableQuadraticProbing : HashTable
    {

    }

    /// <summary>
    /// A hash table implementation to store items with collisions
    /// Implements the Double Hash method
    /// </summary>
    public class HashTableDoubleHash : HashTable
    {

    }
}