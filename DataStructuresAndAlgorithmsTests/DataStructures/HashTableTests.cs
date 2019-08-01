using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresAndAlgorithms.DataStructures;

namespace DataStructuresAndAlgorithms.DataStructures.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        [TestMethod()]
        public void HashTableDefaultConstructorTest()
        {
            HashTable table = new HashTable();
            Assert.IsNotNull(table);
            Assert.AreEqual(1000, table.Size);
            PrivateObject pri = new PrivateObject(table);
            Assert.IsNotNull((Dictionary<int, object>)pri.GetFieldOrProperty("hashTable"));

            table = new HashTable(1234);
            Assert.IsNotNull(table);
            Assert.AreEqual(1234, table.Size);
            pri = new PrivateObject(table);
            Assert.IsNotNull((Dictionary<int, object>)pri.GetFieldOrProperty("hashTable"));
        }
               
        [TestMethod]
        public void HashTableInsert()
        {
            HashTable table = new HashTable();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(12));
            Assert.IsFalse(table.Insert(12));

            Assert.IsTrue(table.Insert("1234"));
        }

        [TestMethod]
        public void HashTableSearch()
        {
            HashTable table = new HashTable();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(12));
            Assert.IsTrue(table.Insert(13));
            Assert.IsTrue(table.Insert("14"));

            object found = table.Search(12);
            Assert.IsNotNull(found);
            Assert.AreEqual(12, found);

            found = table.Search("14");
            Assert.IsNotNull(found);
            Assert.AreEqual("14", found);

            found = table.Search(17);
            Assert.IsNull(found);
        }

        [TestMethod]
        public void HashTableRemove()
        {
            HashTable table = new HashTable();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Insert(2));
            Assert.IsTrue(table.Insert(3));

            object found = table.Search(1);
            Assert.IsNotNull(found);
            Assert.IsTrue(table.Remove(found));
            Assert.IsNull(table.Search(found));
        }

        [TestMethod]
        public void HashTableManyItems()
        {
            HashTable table = new HashTable();
            Assert.IsNotNull(table);

            for (int i = 0; i < table.Size; i++)
            {
                Assert.IsTrue(table.Insert(i));
            }

            //generate an array with lots of items, with each value being something that should be in the hash table
            int[] testItems = new int[10000];
            Random rnd = new Random();
            for (int i = 0; i < testItems.Length; i++)
            {
                testItems[i] = rnd.Next(0, table.Size);
            }

            //now check that each item in the array resolves to an entry in the hash table
            for (int i = 0; i < testItems.Length; i++)
            {
                Assert.IsNotNull(table.Search(testItems[i]));
            }
        }

        [TestMethod]
        public void HashTableMultipleItems()
        {
            HashTable table = new HashTable();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Insert(200));

            Assert.IsFalse(table.Insert(1));
        }
    }

    [TestClass()]
    public class HashTableSeparateChainingTests
    {
        [TestMethod()]
        public void SeparateChainingDefaultConstructorTest()
        {
            HashTableSeparateChaining table = new HashTableSeparateChaining();
            Assert.IsNotNull(table);
            Assert.AreEqual(1000, table.Size);
            PrivateObject pri = new PrivateObject(table);
            Assert.IsNotNull((Dictionary<int, LinkedList<object>>)pri.GetFieldOrProperty("hashTable"));

            table = new HashTableSeparateChaining(1234);
            Assert.IsNotNull(table);
            Assert.AreEqual(1234, table.Size);
            pri = new PrivateObject(table);
            Assert.IsNotNull((Dictionary<int, LinkedList<object>>)pri.GetFieldOrProperty("hashTable"));
        }

        [TestMethod]
        public void SeparateChainingInsert()
        {
            HashTableSeparateChaining table = new HashTableSeparateChaining();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(12));
            Assert.IsTrue(table.Insert(12));

            Assert.IsTrue(table.Insert("1234"));
        }

        [TestMethod]
        public void SeparateChainingSearch()
        {
            HashTableSeparateChaining table = new HashTableSeparateChaining();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(12));
            Assert.IsTrue(table.Insert(13));
            Assert.IsTrue(table.Insert("14"));

            object found = table.Search(12);
            Assert.IsNotNull(found);
            Assert.AreEqual(12, found);

            found = table.Search("14");
            Assert.IsNotNull(found);
            Assert.AreEqual("14", found);

            found = table.Search(17);
            Assert.IsNull(found);
        }

        [TestMethod]
        public void SeparateChainingRemove()
        {
            HashTableSeparateChaining table = new HashTableSeparateChaining();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Insert(2));
            Assert.IsTrue(table.Insert(3));

            object found = table.Search(1);
            Assert.IsNotNull(found);
            Assert.IsTrue(table.Remove(found));
            Assert.IsNull(table.Search(found));
            Assert.IsFalse(table.Remove(found));
        }

        [TestMethod]
        public void HashTableManyItems()
        {
            HashTableSeparateChaining table = new HashTableSeparateChaining();
            Assert.IsNotNull(table);

            for (int i = 0; i < table.Size; i++)
            {
                Assert.IsTrue(table.Insert(i));
            }

            //generate an array with lots of items, with each value being something that should be in the hash table
            int[] testItems = new int[10000];
            Random rnd = new Random();
            for (int i = 0; i < testItems.Length; i++)
            {
                testItems[i] = rnd.Next(0, table.Size);
            }

            //now check that each item in the array resolves to an entry in the hash table
            for (int i = 0; i < testItems.Length; i++)
            {
                Assert.IsNotNull(table.Search(testItems[i]));
            }
        }

        [TestMethod]
        public void SeparateChainingMultipleItems()
        {
            HashTableSeparateChaining table = new HashTableSeparateChaining();
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Insert(200));

            Assert.IsTrue(table.Insert(1));
        }
    }

    [TestClass()]
    public class HashTableLinearProbingTests
    {
        [TestMethod]
        public void LinearProbingDefaultConstructor()
        {
            HashTableLinearProbing table = new HashTableLinearProbing();
            Assert.IsNotNull(table);
            Assert.AreEqual(1000, table.Size);
            PrivateObject pri = new PrivateObject(table);
            Assert.IsNotNull((int?[])pri.GetFieldOrProperty("hashTable"));

            table = new HashTableLinearProbing(12);
            Assert.IsNotNull(table);
            Assert.AreEqual(12, table.Size);
            pri = new PrivateObject(table);
            Assert.IsNotNull((int?[])pri.GetFieldOrProperty("hashTable"));
        }

        [TestMethod]
        public void LinearProbingInsert()
        {
            HashTableLinearProbing table = new HashTableLinearProbing(10);
            Assert.IsTrue(table.Insert(0));
            Assert.IsTrue(table.Insert(5));
            Assert.IsTrue(table.Insert(16));
            Assert.IsTrue(table.Insert(6));

            PrivateObject pri = new PrivateObject(table);
            var hashTable = (int?[])pri.GetFieldOrProperty("hashTable");
            //manually check each entry in the array that has come back
            Assert.AreEqual(0, hashTable[0]);
            Assert.IsNull(hashTable[1]);
            Assert.IsNull(hashTable[2]);
            Assert.IsNull(hashTable[3]);
            Assert.IsNull(hashTable[4]);
            Assert.AreEqual(5, hashTable[5]);
            Assert.AreEqual(16, hashTable[6]);
            Assert.AreEqual(6, hashTable[7]);
            Assert.IsNull(hashTable[8]);
            Assert.IsNull(hashTable[9]);
        }

        [TestMethod]
        public void LinearProbingInsertMaximum()
        {
            int size = 10;
            HashTableLinearProbing table = new HashTableLinearProbing(size);
            for (int i = 0; i < size; i++)
                table.Insert(i);

            Assert.IsFalse(table.Insert(0));
            Assert.IsFalse(table.Insert(4));
        }

        [TestMethod]
        public void LinearProbingInsertDuplicate()
        {
            HashTableLinearProbing table = new HashTableLinearProbing(10);
            Assert.IsTrue(table.Insert(10));
            Assert.IsTrue(table.Insert(20));

            Assert.IsFalse(table.Insert(10));
            Assert.IsFalse(table.Insert(int.MinValue));
        }

        [TestMethod]
        public void LinearProbingSearch()
        {
            HashTableLinearProbing table = new HashTableLinearProbing(10);
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Insert(0));
            Assert.IsTrue(table.Insert(5));
            Assert.IsTrue(table.Insert(16));

            Assert.IsTrue(table.Search(0));
            Assert.IsTrue(table.Search(5));
            Assert.IsTrue(table.Search(16));

            Assert.IsFalse(table.Search(2));
            Assert.IsFalse(table.Search(200));
            Assert.IsFalse(table.Search(int.MinValue));
        }

        [TestMethod]
        public void LinearProbingRemove()
        {
            HashTableLinearProbing table = new HashTableLinearProbing(10);
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Insert(0));
            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Insert(11));

            Assert.IsTrue(table.Search(1));
            Assert.IsTrue(table.Remove(1));
            Assert.IsFalse(table.Search(1));
            Assert.IsFalse(table.Remove(1));
        }

        [TestMethod]
        public void LinearProbingRemoveWithReplace()
        {
            HashTableLinearProbing table = new HashTableLinearProbing(10);
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Insert(0));
            Assert.IsTrue(table.Insert(10));
            Assert.IsTrue(table.Insert(20));
            Assert.IsTrue(table.Insert(5));

            Assert.IsTrue(table.Remove(10));
            Assert.IsTrue(table.Search(0));
            Assert.IsTrue(table.Search(20));

            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Remove(5));

            PrivateObject pri = new PrivateObject(table);
            var hashTable = (int?[])pri.GetFieldOrProperty("hashTable");
            //check each entry manually
            Assert.AreEqual(0, hashTable[0]);
            Assert.AreEqual(1, hashTable[1]);
            Assert.AreEqual(20, hashTable[2]);
            Assert.IsNull(hashTable[3]);
            Assert.IsNull(hashTable[4]);
            Assert.AreEqual(int.MinValue, hashTable[5]);
            Assert.IsNull(hashTable[6]);
            Assert.IsNull(hashTable[7]);
            Assert.IsNull(hashTable[8]);
            Assert.IsNull(hashTable[9]);
        }
    }
}
