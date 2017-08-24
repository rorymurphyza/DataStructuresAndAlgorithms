using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.Algorithms;
using DataStructuresAndAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Algorithms.Tests
{
    [TestClass()]
    public class MazeSolvingTests
    {
        #region Sample Mazes for testing
        /// <summary>
        /// A 2x2 matrix that is unsolvable
        /// </summary>
        /// <returns></returns>
        private static GenericStruct.Maze create22Unsolvable()
        {
            var maze = new GenericStruct.Maze();

            maze.Layout = new int[,] { { 1, 0 }, { 0, 0 } };
            maze.StartPos = new int[] { 0, 0 };
            maze.EndPos = new int[] { 1, 1 };

            return maze;
        }

        /// <summary>
        /// A 2x2 matrix that is uniquely solvable, with path length 2.
        /// First element is the maze, 2nd element is the solution
        /// </summary>
        /// <returns></returns>
        private static List<GenericStruct.Maze> create22Solvable()
        {
            var output = new List<GenericStruct.Maze>();

            var maze = new GenericStruct.Maze();
            maze.Layout = new int[,] { { 1, 1 }, { 0, 1 } };
            maze.StartPos = new int[] { 0, 0 };
            maze.EndPos = new int[] { 1, 1 };
            output.Add(maze);

            var solutionMaze = new GenericStruct.Maze();
            solutionMaze.Layout = new int[,] { { 1, 1 }, { 0, 1 } };
            solutionMaze.StartPos = new int[] { 0, 0 };
            solutionMaze.EndPos = new int[] { 1, 1 };
            solutionMaze.PathLength = 2;
            output.Add(solutionMaze);

            return output;
        }

        /// <summary>
        /// A 3x3 matrix that is uniquely solvable, with path length 4.
        /// First element is the maze, 2nd element is the soln
        /// </summary>
        /// <returns></returns>
        private static List<GenericStruct.Maze> create33Solvable()
        {
            var output = new List<GenericStruct.Maze>();

            var maze = new GenericStruct.Maze();
            maze.Layout = new int[,] { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 0, 1 } };
            maze.StartPos = new int[] { 0, 0 };
            maze.EndPos = new int[] { 2, 2 };
            output.Add(maze);

            var solutionMaze = new GenericStruct.Maze();
            solutionMaze.Layout = new int[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 1 } };
            solutionMaze.StartPos = new int[] { 0, 0 };
            solutionMaze.EndPos = new int[] { 2, 2 };
            solutionMaze.PathLength = 4;
            output.Add(solutionMaze);

            return output;
        }

        /// <summary>
        /// A 3x3 matrix that is uniquely solvable, with path length 5.
        /// First element is the maze, 2nd element is the soln
        /// </summary>
        /// <returns></returns>
        private static List<GenericStruct.Maze> create33Solvable5()
        {
            var output = new List<GenericStruct.Maze>();

            var maze = new GenericStruct.Maze();
            maze.Layout = new int[,] { { 1, 0, 0 }, { 1, 0, 1 }, { 1, 1, 1 } };
            maze.StartPos = new int[] { 0, 0 };
            maze.EndPos = new int[] { 1, 2 };
            output.Add(maze);

            var solutionMaze = new GenericStruct.Maze();
            solutionMaze.Layout = new int[,] { { 1, 0, 0 }, { 1, 0, 1 }, { 1, 1, 1 } };
            solutionMaze.StartPos = new int[] { 0, 0 };
            solutionMaze.EndPos = new int[] { 1, 2 };
            solutionMaze.PathLength = 5;
            output.Add(solutionMaze);

            return output;
        }

        /// <summary>
        /// A 4x4 matrix with 2 valid solutions, one with path length 5 and the other with path length 7.
        /// First element is the maze, 2nd element is soln with pathLength=5 and 3rd is soln with pathLength = 7
        /// </summary>
        /// <returns></returns>
        private static List<GenericStruct.Maze> create44With2Soln()
        {
            var output = new List<GenericStruct.Maze>();

            var maze = new GenericStruct.Maze();
            maze.Layout = new int[,] { 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 0, 1 }, 
                { 0, 1, 1, 1 } };
            maze.StartPos = new int[] { 0, 0 };
            maze.EndPos = new int[] { 2, 3 };
            output.Add(maze);

            var solnMaze = new GenericStruct.Maze();
            solnMaze.Layout = new int[,] { 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 0, 0, 0, 1 }, 
                { 0, 0, 0, 0 } };
            solnMaze.PathLength = 5;
            output.Add(solnMaze);

            var otherSolnMaze = new GenericStruct.Maze();
            otherSolnMaze.Layout = new int[,] { 
                { 1, 0, 0, 0 }, 
                { 1, 0, 0, 0 }, 
                { 1, 1, 0, 1 }, 
                { 0, 1, 1, 1 } };
            otherSolnMaze.PathLength = 7;
            output.Add(otherSolnMaze);

            return output;
        }
        
        private static GenericStruct.Maze create1010()
        {
            var maze = new GenericStruct.Maze();

            maze.Layout = new int[,]
            {
                {1,1,1,1,1,0,0,1,1,1},
                {0,1,1,1,1,1,0,1,0,1},
                {0,0,1,0,1,1,1,0,0,1},
                {1,0,1,1,1,0,1,1,0,1},
                {0,0,0,1,0,0,0,1,0,1},
                {1,0,1,1,1,0,0,1,1,0},
                {0,0,0,0,1,0,0,1,0,1},
                {0,1,1,1,1,1,1,1,0,0},
                {1,1,1,1,1,0,0,1,1,1},
                {0,0,1,0,0,1,1,0,0,1}
            };
            maze.StartPos = new int[] { 0, 0 };
            maze.EndPos = new int[] { 7, 5 };
            maze.PathLength = 12;

            return maze;
        }
        #endregion

        [TestClass()]
        public class BacktrackTests
        {
            [TestMethod()]
            public void Unsolvable22Maze()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                //test for the unsolvable matrix
                var maze = create22Unsolvable();
                var solnMaze = mazeSolver.FindShortestPath(maze);
                Assert.AreEqual(null, solnMaze);
            }

            [TestMethod()]
            public void Unique22MazeTest()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                //test for the 2x2 uniquely solvable matrix
                var mazes = create22Solvable();
                var solnMaze = mazeSolver.FindShortestPath(mazes [0]);
                var answer = new GenericStruct.Maze();
                answer.Layout = new int[,] { { 1, 1 }, { 0, 1 } };
                answer.PathLength = 2;
                Assert.AreEqual(answer.PathLength, solnMaze.PathLength);
                Assert.IsTrue(RJM.Personal.Method.AreEqualIntArrays(answer.Layout, solnMaze.Layout));
            }

            [TestMethod()]
            public void Unique33MazeTest()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                //test for the 3x3 uniquely solvable matrix
                var mazes = create33Solvable();
                var solnMaze = new GenericStruct.Maze();
                solnMaze = mazeSolver.FindShortestPath(mazes[0]);
                var answer = mazes[1];
                //answer.Layout = new int[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 1 } };
                //answer.PathLength = 4;
                Assert.AreEqual(answer.PathLength, solnMaze.PathLength);
                Assert.IsTrue(RJM.Personal.Method.AreEqualIntArrays(solnMaze.Layout, answer.Layout));
            }

            [TestMethod()]
            public void Unique33MazeTest5()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                var mazes = create33Solvable5();
                var solnMaze = new GenericStruct.Maze();
                solnMaze = mazeSolver.FindShortestPath(mazes[0]);
                var answer = mazes[1];
                Assert.AreEqual(answer.PathLength, solnMaze.PathLength);
                Assert.IsTrue(RJM.Personal.Method.AreEqualIntArrays(solnMaze.Layout, answer.Layout));
            }

            [TestMethod()]
            public void Multiple44SolutionTest()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                var mazes = create44With2Soln();
                var solnMaze = new GenericStruct.Maze();
                solnMaze = mazeSolver.FindShortestPath(mazes[0]);
                var answer = mazes[1];
                Assert.AreEqual(answer.PathLength, solnMaze.PathLength);
                Assert.IsTrue(RJM.Personal.Method.AreEqualIntArrays(solnMaze.Layout, answer.Layout));
            }

            [TestMethod()]
            public void Unique1010MazeTest()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                var mazes = create1010();
                var solnMaze = new GenericStruct.Maze();
                solnMaze = mazeSolver.FindShortestPath(mazes);
                Assert.AreEqual(mazes.PathLength, solnMaze.PathLength);
            }

            [TestMethod()]
            public void Multiple44SolutionsTest()
            {
                var mazeSolver = new MazeSolvers.BacktrackingAlgorithm();

                var mazes = create44With2Soln();
                var solnMaze = mazeSolver.FindAllSolutions(mazes[0]);
                var answer1 = mazes[1];
                var answer2 = mazes[2];

                Assert.AreEqual(answer1.PathLength, solnMaze[0].PathLength);
                Assert.IsTrue(RJM.Personal.Method.AreEqualIntArrays(answer1.Layout, solnMaze[0].Layout));

                Assert.AreEqual(answer2.PathLength, solnMaze[1].PathLength);
                Assert.IsTrue(RJM.Personal.Method.AreEqualIntArrays(answer2.Layout, solnMaze[1].Layout));
            }

            [TestMethod()]
            public void IsValidMoveTest()
            {
                MazeSolvers.BacktrackingAlgorithm ba = new MazeSolvers.BacktrackingAlgorithm();
                PrivateObject pri = new PrivateObject(ba);
                object[] args = new object[] { 2, 2, 1, 1 };
                bool response = (bool)pri.Invoke("isValidMove", args);
                Assert.IsTrue(response);

                args = new object[] { 2, 2, 3, 1, };
                response = (bool)pri.Invoke("isValidMove", args);
                Assert.IsFalse(response);
            }
        }
    }
}