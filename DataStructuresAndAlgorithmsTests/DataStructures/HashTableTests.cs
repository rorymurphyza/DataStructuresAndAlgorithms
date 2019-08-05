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

    [TestClass()]
    public class HashTableQuadraticProbingTests
    {
        [TestMethod]
        public void QuadraticProbingDefaultConstructor()
        {
            HashTable table = new HashTableQuadraticProbing();
            Assert.IsNotNull(table);
            Assert.AreEqual(1000, table.Size);
            PrivateObject pri = new PrivateObject(table);
            Assert.IsNotNull((int?[])pri.GetFieldOrProperty("hashTable"));

            table = new HashTableQuadraticProbing(12);
            Assert.IsNotNull(table);
            Assert.AreEqual(12, table.Size);
            pri = new PrivateObject(table);
            Assert.IsNotNull((int?[])pri.GetFieldOrProperty("hashTable"));
        }

        [TestMethod]
        public void QuadraticProbingInsert()
        {
            HashTableQuadraticProbing table = new HashTableQuadraticProbing(100);
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(0));
            Assert.IsTrue(table.Insert(1));
            Assert.IsTrue(table.Insert(2));

            Assert.IsTrue(table.Insert(20));
            Assert.IsTrue(table.Insert(30));

            Assert.IsTrue(table.Insert(120));   //should be in table position 21
            Assert.IsTrue(table.Insert(220));   //should be in table position 24
            Assert.IsTrue(table.Insert(320));   //should be in table position 29

            PrivateObject pri = new PrivateObject(table);
            var hashTable = (int?[])pri.GetFieldOrProperty("hashTable");
            Assert.AreEqual(0, hashTable[0]);
            Assert.AreEqual(1, hashTable[1]);
            Assert.AreEqual(2, hashTable[2]);
            for (int i = 3; i < 20; i++)
                Assert.IsNull(hashTable[i]);

            Assert.AreEqual(20, hashTable[20]);
            Assert.AreEqual(120, hashTable[21]);
            Assert.IsNull(hashTable[22]);
            Assert.IsNull(hashTable[23]);
            Assert.AreEqual(220, hashTable[24]);
            Assert.IsNull(hashTable[25]);
            Assert.IsNull(hashTable[26]);
            Assert.IsNull(hashTable[27]);
            Assert.IsNull(hashTable[28]);
            Assert.AreEqual(320, hashTable[29]);
            Assert.AreEqual(30, hashTable[30]);
            for (int i = 31; i < table.Size; i++)
                Assert.IsNull(hashTable[i]);
        }

        [TestMethod]
        public void QuadraticProbingInsertMultiple()
        {
            var table = new HashTableQuadraticProbing(10);
            Assert.IsTrue(table.Insert(0));
            Assert.IsTrue(table.Insert(1));     //k = 0, table[1]
            Assert.IsTrue(table.Insert(11));    //k = 1, table[2]
            Assert.IsTrue(table.Insert(21));    //k = 2, table[5]
            Assert.IsTrue(table.Insert(5));     //k = 1, table[6]

            Assert.IsFalse(table.Insert(31));    //k = 3, table[10] -> error

            PrivateObject pri = new PrivateObject(table);
            var hashTable = (int?[])pri.GetFieldOrProperty("hashTable");
            Assert.AreEqual(0, hashTable[0]);
            Assert.AreEqual(1, hashTable[1]);
            Assert.AreEqual(11, hashTable[2]);
            Assert.IsNull(hashTable[3]);
            Assert.IsNull(hashTable[4]);
            Assert.AreEqual(21, hashTable[5]);
            Assert.AreEqual(5, hashTable[6]);
            Assert.IsNull(hashTable[7]);
            Assert.IsNull(hashTable[8]);
            Assert.IsNull(hashTable[9]);
        }

        [TestMethod]
        public void QuadraticProbingSearch()
        {
            var table = new HashTableQuadraticProbing(100);
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Insert(0));     //k = 0, HashTable[0]
            Assert.IsTrue(table.Insert(1));     //k = 0, HashTable[1]
            Assert.IsTrue(table.Insert(10));    //k = 2, HashTable[4]
            Assert.IsTrue(table.Insert(20));    //k = 3, HashTable[9]
            Assert.IsTrue(table.Insert(30));    //k = 4, HashTable[16]

            Assert.IsTrue(table.Search(0));
            Assert.IsTrue(table.Search(1));
            Assert.IsTrue(table.Search(10));
            Assert.IsTrue(table.Search(20));
            Assert.IsTrue(table.Search(30));

            Assert.IsFalse(table.Search(12));
            Assert.IsFalse(table.Search(17));
            Assert.IsFalse(table.Search(29));
        }

        [TestMethod]
        public void QuadraticProbingRemove()
        {
            var table = new HashTableQuadraticProbing(10);
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(0));     //k = 0, HashTable[0]
            Assert.IsTrue(table.Insert(1));     //k = 0, HashTable[1]
            Assert.IsTrue(table.Insert(2));     //k = 0, HashTable[2]
            Assert.IsTrue(table.Insert(10));    //k = 2, HashTable[4]

            Assert.IsTrue(table.Search(1));
            Assert.IsTrue(table.Remove(1));     //HashTable[1] = int.MinValue
            Assert.IsTrue(table.Search(0));
            Assert.IsFalse(table.Search(1));
            Assert.IsTrue(table.Search(2));

            PrivateObject pri = new PrivateObject(table);
            var hashTable = (int?[])pri.GetFieldOrProperty("hashTable");
            Assert.AreEqual(0, hashTable[0]);
            Assert.AreEqual(int.MinValue, hashTable[1]);
            Assert.AreEqual(2, hashTable[2]);
            Assert.IsNull(hashTable[3]);
            Assert.AreEqual(10, hashTable[4]);
            for (int i = 5; i < table.Size; i++)
                Assert.IsNull(hashTable[i]);
        }

        [TestMethod]
        public void QuadraticProbingRemoveMultiple()
        {
            var table = new HashTableQuadraticProbing(10);
            Assert.IsNotNull(table);

            Assert.IsTrue(table.Insert(0));     //k = 0, HashTable[0]
            Assert.IsTrue(table.Insert(1));     //k = 0, HashTable[1]
            Assert.IsTrue(table.Insert(2));     //k = 0, HashTable[2]
            Assert.IsTrue(table.Insert(33));    //k = 0, HashTable[3]
            Assert.IsTrue(table.Insert(10));    //k = 2, HashTable[4]
            Assert.IsTrue(table.Insert(20));    //k = 3, HashTable[9]

            Assert.IsTrue(table.Search(1));
            Assert.IsTrue(table.Remove(1));
            Assert.IsFalse(table.Search(1));

            Assert.IsTrue(table.Insert(11));
            Assert.IsTrue(table.Search(11));
            Assert.IsTrue(table.Remove(11));
            Assert.IsFalse(table.Search(11));
        }
    }

    [TestClass]
    public class HashTableDoubleHashTests
    {
        [TestMethod]
        public void DoubleHashDefaultConstructor()
        {
            var table = new HashTableDoubleHash();
            Assert.IsNotNull(table);
            Assert.IsInstanceOfType(table, typeof(HashTableDoubleHash));
            Assert.AreEqual(table.Size, 1000);

            table = new HashTableDoubleHash(100);
            Assert.IsNotNull(table);
            Assert.IsInstanceOfType(table, typeof(HashTableDoubleHash));
            Assert.AreEqual(table.Size, 100);
        }

        [TestMethod]
        public void DoubleHashInsert()
        {
            var table = new HashTableDoubleHash(100);   //Prime = 97
            Assert.IsTrue(table.Insert(0));     //table[0]
            Assert.IsTrue(table.Insert(1));     //table[1]
            Assert.IsTrue(table.Insert(2));     //table[2]

            Assert.IsTrue(table.Insert(30));    //table[30]
            Assert.IsTrue(table.Insert(31));    //table[31]

            Assert.IsTrue(table.Insert(100));   //table[97]
            Assert.IsTrue(table.Insert(200));   //table[94]

            Assert.IsTrue(table.Insert(130));   //table[64]
            Assert.IsTrue(table.Insert(230));   //table[61]

            Assert.IsTrue(table.Insert(131));   //table[63]

            PrivateObject pri = new PrivateObject(table);
            var hashTable = (int?[])pri.GetFieldOrProperty("hashTable");
            Assert.AreEqual(0, hashTable[0]);
            Assert.AreEqual(1, hashTable[1]);
            Assert.AreEqual(2, hashTable[2]);
            for (int i = 3; i < 30; i++)
                Assert.IsNull(hashTable[i]);
            Assert.AreEqual(30, hashTable[30]);
            Assert.AreEqual(31, hashTable[31]);

            Assert.AreEqual(100, hashTable[97]);
            Assert.AreEqual(200, hashTable[94]);
            Assert.AreEqual(130, hashTable[64]);
            Assert.AreEqual(230, hashTable[98]);
            Assert.AreEqual(131, hashTable[63]);
        }

        [TestMethod]
        public void DoubleHashInsertIntoFullTable()
        {
            int size = 100;
            var table = new HashTableDoubleHash(size);
            Assert.IsNotNull(table);
            for (int i = 0; i < size; i++)
                Assert.IsTrue(table.Insert(i));
            Assert.IsFalse(table.Insert(0));
            Assert.IsFalse(table.Insert(10));

            size = 10;
            Random rnd = new Random();
            table = new HashTableDoubleHash(size);
            Assert.IsNotNull(table);
            for (int i = 0; i < size; i++)
                Assert.IsTrue(table.Insert(rnd.Next(10)));
            Assert.IsFalse(table.Insert(0));
            Assert.IsFalse(table.Insert(rnd.Next(10)));
        }

        [TestMethod]
        public void DoubleHashInsertMultiple()
        {

        }
    }
}
