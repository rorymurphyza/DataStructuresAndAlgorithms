using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Algorithms
{
    /// <summary>
    /// Testing and learning for various types of search mechanisms
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Searched through an ordered list to find value. Ensure list is sorted
        /// Runs in O(logn), assuming list is sorted
        /// </summary>
        /// <param name="input"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool BinarySearch(int[] input, int target)
        {
            int low = 0;
            int high = input.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (target == input[mid])   //found at position mid
                    return true;
                else if (target < input[mid])
                    high = mid - 1; //aim to search the lower half of the set
                else
                    low = mid + 1; //aim to search higher half of set
            }

            return false;
        }

        /// <summary>
        /// Traverses a tree or graph to find the value.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool BreadthFirstSearch(int[] input, int target)
        {
            return false;
        }

        public static bool DepthFirstSearch(int[] input, int target)
        {
            return false;
        }
    }
}
