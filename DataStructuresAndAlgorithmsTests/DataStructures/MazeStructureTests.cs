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
    public class MazeStructureTests
    {
        [TestMethod()]
        public void MazeConstructorTest()
        {
            var maze = new GenericStruct.Maze(5, 5);
            Assert.AreEqual((5 * 5), maze.Layout.Length);
            Assert.AreEqual(5 - 1, maze.Layout.GetUpperBound(0));
            Assert.AreEqual(5 - 1, maze.Layout.GetUpperBound(1));
            int sum = 0;
            for (int i = 0; i < maze.Layout.GetUpperBound(0); i++)
            {
                for (int j = 0; j < maze.Layout.GetUpperBound(1); j++)
                {
                    sum += maze.Layout[i, j];
                }
            }
            Assert.AreEqual(0, sum);
            Assert.AreEqual(0, maze.StartPos[0]);
            Assert.AreEqual(0, maze.StartPos[1]);
            Assert.AreEqual(0, maze.EndPos[0]);
            Assert.AreEqual(0, maze.EndPos[1]);
            Assert.AreEqual(0, maze.CurrentPos[0]);
            Assert.AreEqual(0, maze.CurrentPos[1]);
            Assert.AreEqual(-1, maze.PathLength);

            maze = new GenericStruct.Maze(3, 2);
            Assert.AreEqual((3 * 2), maze.Layout.Length);
            Assert.AreEqual(3 - 1, maze.Layout.GetUpperBound(0));
            Assert.AreEqual(2 - 1, maze.Layout.GetUpperBound(1));
        }
    }
}