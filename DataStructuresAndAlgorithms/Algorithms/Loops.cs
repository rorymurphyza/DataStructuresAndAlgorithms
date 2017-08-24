using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Testing and practice for different algorithms
/// </summary>
namespace DataStructuresAndAlgorithms.Algorithms
{
    /// <summary>
    /// Looking at different ways to replace the for loop
    /// </summary>
    public class Loops
    {
        /// <summary>
        /// Return sum of all elements in an integer array, using FOR loop to do the sum 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int SumOfArrayUsingForLoop(int[] input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
                sum += input[i];
            return sum;
        }

        /// <summary>
        /// Return the sum of all elements in an integer array, using FOREACH loop
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int SumOfArrayUsingForEachLoop(int[] input)
        {
            int sum = 0;
            foreach (int element in input)
                sum += element;
            return sum;
        }

        /// <summary>
        /// Return sum of all elements in an integer array, using the LINQ AGGREGATE function.
        /// This method provides a substantially faster way of doing the sum than using the FOR loop.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int SumOfArrayUsingAggregate(int[] input)
        {
            return input.Aggregate((a, b) => a + b);
        }

        /// <summary>
        /// Return a new array, created from the input array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] CreateNewArrayFromOldForLoop(int[] input)
        {
            int[] newArray = new int[input.Length];
            for (int i = 0; i < newArray.Length; i++)
                newArray[i] = input[i];
            return newArray;
        }

        /// <summary>
        /// Return a new array, created from the input array using a FOREACH loop
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] CreateNewArrayFromOldForeachLoop(int[] input)
        {
            int[] newArray = new int[input.Length];
            int index = 0;
            foreach(int element in input)
            {
                newArray[index] = input[index];
                index++;
            }
            return newArray;
        }

        /// <summary>
        /// Return a new array, using LINQ SELECT
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] CreateNewArrayFromOldWithMap(int[] input)
        {
            return input.Select(element => element).ToArray();
        }

        public static int[] ReturnSubsetArrayUsingFor(int[] input, int start, int end)
        {
            var output = new int[end - start + 1];
            for (int i = 0; i < output.Length; i++)
                output[i] = input[i + start];
            return output;
        }

        public static int[] ReturnSubsetArrayUsingRange(int[] input, int start, int end)
        {
            return input.Skip(start).Take(end - start + 1).ToArray();
        }
    }
}
