using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorithms.AsyncAndParallel.AsyncOrParallel a = new Algorithms.AsyncAndParallel.AsyncOrParallel();
            //a.Start(); //do the void calls for Async testing. 
            a.StartWithReturn();
            Console.ReadLine();
        }
    }
}
