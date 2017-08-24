using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJM.Personal;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace DataStructuresAndAlgorithms.Algorithms
{
    /// <summary>
    /// Any sort of methods to compare how long tasks take
    /// </summary>
    public class AsyncAndParallel
    {
        /// <summary>
        /// Notes: it looks like using ASYNC with a void call is substantially faster than anything else.
        /// This makes sense, the async call doesn't wait for anything. The next trick will be to test if this holds true for methods with a return of some sort
        /// </summary>
        public class AsyncOrParallel
        {
            private int LoopCounter = 1200;
            //Question: I have a void method that I want to run while the rest of a method completes
            //Is it better to somehow async this call or create it in a new thread/task?
            //Should the new thread/task start in the main method or in the method being called?

            #region void calls
            //This method will start what we are doing and call the task method in various ways
            public void Start()
            {
                Console.WriteLine("Starting work");
                Console.WriteLine(string.Format("AsyncTaskTime: {0}", Method.Time(AsyncTask)));
                Console.WriteLine();
                Thread.Sleep(5000);
                Console.WriteLine("Starting test using async call in method.");
                Console.WriteLine(string.Format("Total time for using async: {0}", Method.Time(TaskWithAsync)));
                Console.WriteLine();
                Thread.Sleep(5000);
                Console.WriteLine("Starting test using parallel call in method");
                Console.WriteLine(string.Format("Total time with parallel call: {0}", Method.Time(TaskWithParallelCall)));
                Thread.Sleep(5000);
                Console.WriteLine("Starting test using parallel method");
                Console.WriteLine(string.Format("Total time with external parallel call: {0}", Method.Time(TaskWtihMethodCall)));
            }

            /// <summary>
            /// This method will do some work, call an async method and carry on.
            /// I am interested in the total time this method runs for
            /// </summary>
            public void TaskWithAsync()
            {
                for (int i = 0; i < LoopCounter; i++)
                {
                    long j = findPrime(i);
                }
                Console.WriteLine(string.Format("AsyncTaskTime: {0}", Method.Time(AsyncTask)));
                //AsyncTask();
            }

            /// <summary>
            /// This method will do some work, then create a Task to do something else and return.
            /// I am interested in the total time this method runs for
            /// </summary>
            public void TaskWithParallelCall()
            {
                for (int i = 0; i < LoopCounter; i++)
                {
                    long j = findPrime(i);
                }
                Parallel.For(0, LoopCounter,
                    index => { findPrime(index); });
            }

            /// <summary>
            /// This method will do some work and then call a method that creates its own Task
            /// </summary>
            public void TaskWtihMethodCall()
            {
                for (int i = 0; i < LoopCounter; i++)
                {
                    long j = findPrime(i);
                }
                Console.WriteLine(string.Format("ParallelTask: {0}", Method.Time(ParallelTask)));
            }

            public void ParallelTask()
            {
                Parallel.For(0, LoopCounter,
                    index => { findPrime(index); });
            }

            /// <summary>
            /// Async task, meant to be called and forgotten
            /// </summary>
            async void AsyncTask()
            {
                for (int i = 0; i < LoopCounter; i++)
                {
                    long k = await Task.Run(() => findPrime(i));
                }
            }
            #endregion
            #region List return types
            /// <summary>
            /// Question here: is it quicker to fill a list with ASYNC or parallel.for?
            /// Parallel for is far faster, which makes sense. async is not parallelising, just waiting still
            /// </summary>
            public async void StartWithReturn()
            {
                Console.WriteLine("Starting testing with a return list");
                Console.WriteLine("Populating list from async call:");
                Stopwatch sw = Stopwatch.StartNew();
                List<long> outputAsync = await GetPrimesAsync();
                sw.Stop();
                Console.WriteLine(string.Format("Time: {0}", sw.Elapsed));
                Console.WriteLine();

                Console.WriteLine("Populating list from parallel.for:");
                sw = Stopwatch.StartNew();
                List<long> outputFor = GetPrimesParallel();
                sw.Stop();
                Console.WriteLine(string.Format("Time: {0}", sw.Elapsed));

                if (outputAsync.Count == outputFor.Count)
                    Console.WriteLine("same length");
            }

            public async Task<List<long>> GetPrimesAsync()
            {
                List<long> output = new List<long>();
                for (int i = 0; i < LoopCounter; i++)
                {
                    long result = await Task.Run(() => findPrime(i));
                    output.Add(result);
                }
                return output;
            }

            public List<long> GetPrimesParallel()
            {
                ConcurrentBag<long> output = new ConcurrentBag<long>();
                Parallel.For(0, LoopCounter, index => { output.Add(findPrime(index)); });
                return output.ToList();
            }
            #endregion

            /// <summary>
            /// Find the nth prime number
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            private long findPrime(int n)
            {
                int count = 0;
                long a = 2;
                while (count < n)
                {
                    long b = 2;
                    int prime = 1;
                    while (b * b <= a)
                    {
                        if (a % b == 0)
                        {
                            prime = 0;
                            break;
                        }
                        b++;
                    }
                    if (prime > 0)
                        count++;
                    a++;
                }
                return (--a);
            }
        }
    }
}
