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
}
