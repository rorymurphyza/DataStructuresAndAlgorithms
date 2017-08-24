using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// Contains generic structures used in the solutions, nothing special
    /// </summary>
    public class GenericStruct
    {
        /// <summary>
        /// Represents a basic rectangular maze
        /// </summary>
        public class Maze
        {
            /// <summary>
            /// The layout of the rectangular maze
            /// </summary>
            public int[,] Layout;

            /// <summary>
            /// The entry point to the maze
            /// </summary>
            public int[] StartPos;

            /// <summary>
            /// The destination point within the maze
            /// </summary>
            public int[] EndPos;

            /// <summary>
            /// The current position in the maze
            /// </summary>
            public int[] CurrentPos;

            /// <summary>
            /// The length of the path found between StartPos and EndPos
            /// </summary>
            public int PathLength;

            /// <summary>
            /// Constructor to create a blank maze of specified size
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Maze(int x, int y)
            {
                this.Layout = new int[x, y];
                Array.Clear(this.Layout, 0, this.Layout.Length);
                this.StartPos = new int[] { 0, 0 };
                this.EndPos = new int[] { 0, 0 };
                this.CurrentPos = this.StartPos;
                this.PathLength = -1;
            }

            /// <summary>
            /// Default Consttructor
            /// </summary>
            public Maze()
            {

            }
        }
    }
}
