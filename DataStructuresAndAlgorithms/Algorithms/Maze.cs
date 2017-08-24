using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructuresAndAlgorithms.DataStructures.GenericStruct;

namespace DataStructuresAndAlgorithms.Algorithms
{
    /// <summary>
    /// Algorithms for creating and moving through mazes
    /// </summary>
    public class MazeSolvers
    {
        
        

        /// <summary>
        /// Basic backtracking algorithm to find a route through a maze, returns length of shortest path.
        /// The algorithm starts at the beginning and attempts to move in each direction.
        /// If it can move in a certain direction, we move there and then recursively check if we can move in any of the four directions again.
        /// We need to keep track of where we have been so that we do not get stuck in a loop.
        /// </summary>
        public class BacktrackingAlgorithm
        {
            List<Maze> solutionMazes = null;
            /// <summary>
            /// Returns the solved maze in a Maze object, showing the shortest path
            /// </summary>
            /// <param name="maze"></param>
            /// <returns></returns>
            public Maze FindShortestPath(Maze maze)
            {
                var visitedMaze = new Maze(maze.Layout.GetUpperBound(0) + 1, maze.Layout.GetUpperBound(1) + 1);
                                
                findPath(maze.Layout, visitedMaze.Layout, 0, 0, maze.EndPos[0], maze.EndPos[1], 0);

                if (solutionMazes != null)
                {
                    if (solutionMazes.Count == 1) //only one solution found, return it
                        return solutionMazes[0];
                    //find the shortest path length and return that maze
                    int minLength = int.MaxValue;
                    int solutionPosition = 0;
                    for (int i = 0; i < solutionMazes.Count; i++)
                    {
                        if (solutionMazes[i].PathLength < minLength)
                        {
                            minLength = solutionMazes[i].PathLength;
                            solutionPosition = i;
                        }
                    }
                    return solutionMazes[solutionPosition];
                }

                return null;
            }

            /// <summary>
            /// Returns all the possible solutions for a maze
            /// </summary>
            /// <param name="maze"></param>
            /// <returns></returns>
            public List<Maze> FindAllSolutions(Maze maze)
            {
                var visitedMaze = new Maze(maze.Layout.GetUpperBound(0) + 1, maze.Layout.GetUpperBound(1) + 1);

                findPath(maze.Layout, visitedMaze.Layout, 0, 0, maze.EndPos[0], maze.EndPos[1], 0);

                if (solutionMazes != null)
                    return solutionMazes;

                return null;
            }

            private void findPath(int[,] maze, int[,] visitedMaze, int currentX, int currentY, int destX, int destY, int distance)
            {
                //mark this spot in the visited maze
                visitedMaze[currentX, currentY] = 1;

                //check if we have found destination
                if ((currentX == destX) && (currentY == destY))
                {
                    //we have found the exit
                    Maze solution = new Maze();
                    //create a shallow copy of array so that nothing changes
                    var shallowArray = (int[,])visitedMaze.Clone();
                    solution.Layout = shallowArray;
                    solution.PathLength = distance;

                    if (solutionMazes == null)
                        solutionMazes = new List<Maze>();//ImmutableList.Create<Maze>();
                    solutionMazes.Add(solution);
                }

                //mark this spot in the visited maze
                //visitedMaze[currentX, currentY] = 1;

                //try move to the right
                if (isValidMove(maze.GetUpperBound(0), maze.GetUpperBound(1), currentX, currentY + 1)
                    && (isSafeToMove(maze, visitedMaze, currentX, currentY + 1)))
                {
                    findPath(maze, visitedMaze, currentX, currentY + 1, destX, destY, distance + 1);
                }

                //try to move down
                if (isValidMove(maze.GetUpperBound(0), maze.GetUpperBound(1), currentX + 1, currentY)
                    && (isSafeToMove(maze, visitedMaze, currentX + 1, currentY)))
                {
                    findPath(maze, visitedMaze, currentX + 1, currentY, destX, destY, distance + 1);
                }

                //try move to the left
                if (isValidMove(maze.GetUpperBound(0), maze.GetUpperBound(1), currentX, currentY - 1)
                    && (isSafeToMove(maze, visitedMaze, currentX, currentY - 1)))
                {
                    findPath(maze, visitedMaze, currentX, currentY - 1, destX, destY, distance + 1);
                }

                //try to move up
                if (isValidMove(maze.GetUpperBound(0), maze.GetUpperBound(1), currentX - 1, currentY)
                    && (isSafeToMove(maze, visitedMaze, currentX - 1, currentY)))
                {
                    findPath(maze, visitedMaze, currentX - 1, currentY, destX, destY, distance + 1);
                }

                visitedMaze[currentX, currentY] = 0;
            }

            /// <summary>
            /// Return true if the given move is valid and remains with the bounds of the matrix
            /// </summary>
            /// <param name="xLength">X Length of the maze</param>
            /// <param name="yLength">Y Length of the maze</param>
            /// <param name="x">x position to check</param>
            /// <param name="y">y position to check</param>
            /// <returns></returns>
            private bool isValidMove(int xLength, int yLength, int x, int y)
            {
                if ((x <= xLength) && (y <= yLength)
                    && (x >= 0) && (y >= 0))
                    return true;

                return false;
            }

            /// <summary>
            /// Return true if we should move to the give position. Checks if a valid location in Maze and we haven't been there before.
            /// </summary>
            /// <param name="maze">The maze to be solved</param>
            /// <param name="visited">The maze currently being solved</param>
            /// <param name="x">The position we want to move to</param>
            /// <param name="y">The postion we want to move to</param>
            /// <returns></returns>
            private bool isSafeToMove(int[,] maze, int[,] visited, int x, int y)
            {
                if ((maze[x, y] == 0) //We can't move to this position
                    || (visited[x, y] == 1)) //we have already been to this position
                    return false;

                return true;
            }
        }
        
        public class LeeAlgorithm
        {

        }
    }
}
