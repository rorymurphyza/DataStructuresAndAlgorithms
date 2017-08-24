using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJM.Personal
{
    /// <summary>
    /// Useful methods that can be used in a static context
    /// </summary>
    public static class Method
    {
        /// <summary>
        /// Times the given method. Returns a TimeSpan showing the time that elapsed.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TimeSpan Time(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();    //create a new stopwatch object and start it
            action();                               //execute the method that was sent to it
            sw.Stop();                              //stop the stopwatch
            return sw.Elapsed;                      //return the time the stopwatch ran for
        }

        /// <summary>
        /// Compare two int[,] arrays for equality
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool AreEqualIntArrays(int[,] array1, int[,] array2)
        {
            return ((array1.Rank == array2.Rank) //rank
                    && (Enumerable.Range(0, array1.Rank).All(dimension => array1.GetLength(dimension) == array2.GetLength(dimension)))
                    && (array1.Cast<int>().SequenceEqual(array2.Cast<int>())));
        }
    }
}
