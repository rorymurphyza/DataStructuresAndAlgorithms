using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Using various Sort algorithms
/// </summary>
namespace DataStructuresAndAlgorithms.Algorithms
{
    /// <summary>
    /// Various search algorithms implemented
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Sorts by dividing input into two subsets, moving values from one to the other. Returnd set in ascending order
        /// The second subset will be the sorted subset and elements will be placed in their correct order as theyare inserted.
        /// Runs in O(n2) and is widely used, especially where the input is dynamic and changing.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] input)
        {
            return InsertionSort(input, true);
        }

        /// <summary>
        /// Sorts by dividing input into two subsets, moving values from one to the other.
        /// The second subset will be the sorted subset and elements will be placed in their correct order as theyare inserted.
        /// Runs in O(n2) and is widely used, especially where the input is dynamic and changing.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ascending">True - ascending order</param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] input, bool ascending)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i];
                int j = i;
                if (ascending) //sort in ascending order
                {
                    while ((j > 0) && (input[j - 1] > value))
                    {
                        input[j] = input[j - 1];
                        j--;
                    }
                }
                else //sort in descending order
                {
                    while ((j > 0) && (input[j - 1] < value))
                    {
                        input[j] = input[j - 1];
                        j--;
                    }
                }
                input[j] = value;
            }

            return input;
        }
                
        public static int[] SelectionSort(int[] input)
        {
            return SelectionSort(input, true);
        }

        /// <summary>
        /// Very similar to Insertion Sort, but tends to use less memory. 
        /// Uses a maximum of n memory, the size of the list, so is good where memory is limited or expensive to write to.
        /// Runs in O(n2), outperforms bubble sort but is worse than insertion sort
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] SelectionSort(int[] input, bool ascending)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                //find the minimum (or max) element in input, then swop it
                int minMax = i;    //track position of min

                if (ascending)  //sort in ascending order
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] < input[minMax])
                            minMax = j;    //found a new minimum, save its position
                    }
                }
                else //sort in descending order
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] > input[minMax])
                            minMax = j;    //found a new minimum, save its position
                    }
                }
                int swap = input[i];
                input[i] = input[minMax];
                input[minMax] = swap;
            }
            return input;
        }

        /// <summary>
        /// Uses a very simple algorithm, but is typically very slow. 
        /// Works by swapping elements in the array until it is in order.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] input)
        {
            return BubbleSort(input, true);
        }

        public static int[] BubbleSort(int[] input, bool ascending)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = 0; j < input.Length - 1 - i; j++)
                {
                    if (ascending)
                    {
                        if (input[j] > input[j + 1])
                        {
                            int swap = input[j];
                            input[j] = input[j + 1];
                            input[j + 1] = swap;
                        }
                    }
                    else
                    {
                        if (input[j] < input[j + 1])
                        {
                            int swap = input[j];
                            input[j] = input[j + 1];
                            input[j + 1] = swap;
                        }
                    }
                }
            }
            return input;
        }

        /// <summary>
        /// Sorts the array into a collection of objects according to keys. Very suitable for arrays where the variance is small
        /// Sorts in O(nlogn).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] CountingSort(int[] input)
        {
            return CountingSort(input, true);
        }

        public static int[] CountingSort(int[] input, bool ascending)
        {
            int[] sortedArray = new int[input.Length];

            //find the smallest and largest values in the set
            int minValue = input[0];
            int maxValue = input[1];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < minValue)
                    minValue = input[i];
                else if (input[i] > maxValue)
                    maxValue = input[i];
            }

            //create and initialise the array of frequencies
            int[] counts = new int[maxValue - minValue + 1];
            for (int i = 0; i < input.Length; i++)
                counts[input[i] - minValue]++;

            //recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
                counts[i] = counts[i] + counts[i - 1];

            //sort the array
            for (int i = input.Length - 1; i >= 0; i--)
                sortedArray[counts[input[i] - minValue]--] = input[i];

            if (!ascending)
                return sortedArray.Reverse().ToArray();
            return sortedArray;
        }
                
        #region MergeSort
        /// <summary>
        /// This is the most basic divide-and-conquer algorithm. The list is split in two and recursively sorted from there.
        /// This is the TopDown implementation.
        /// Runs in O(nlogn).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] MergeSort(int[] input)
        {
            return MergeSort(input, true);
        }

        public static int[] MergeSort(int[] input, bool ascending)
        {
            splitMerge(input, 0, input.Length - 1, ascending);
            return input;
        }

        private static void splitMerge(int[] input, int left, int right, bool ascending)
        {
            if (input.Length == 1) //nothing to sort
                return;

            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                splitMerge(input, left, mid, ascending);
                splitMerge(input, mid + 1, right, ascending);

                doMerge(input, left, mid + 1, right, ascending);
            }            
        }

        private static void doMerge(int[] input, int left, int mid, int right, bool ascending)
        {
            int[] temp = new int[input.Length];

            int leftEnd = mid - 1;
            int tempPos = left;
            int numElements = right - left + 1;

            while ((left <= leftEnd) && (mid <= right))
            {
                if (ascending)
                {
                    if (input[left] <= input[mid])
                        temp[tempPos++] = input[left++];
                    else
                        temp[tempPos++] = input[mid++];
                }
                else
                {
                    if (input[left] >= input[mid])
                        temp[tempPos++] = input[left++];
                    else
                        temp[tempPos++] = input[mid++];
                }
            }

            while (left <= leftEnd)
                temp[tempPos++] = input[left++];

            while (mid <= right)
                temp[tempPos++] = input[mid++];

            for (int i = 0; i < numElements; i++)
            {
                input[right] = temp[right];
                right--;
            }
        }
        #endregion

        #region Quick Sort
        /// <summary>
        /// Another divide-and-conquer algorithm. Recursively divides the array around a pivot point until sorted.
        /// Worst case run is O(n2) for a bad pivot, best is O(nlogn). Various pivot-choosing mechanisms are available, here we just use one end of the array.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] QuickSort(int[] input)
        {
            return QuickSort(input, true);
        }

        public static int[] QuickSort(int[] input, bool ascending)
        {
            quickSort(input, 0, input.Length - 1, ascending);
            return input;
        }

        private static void quickSort(int[] input, int start, int end, bool ascending)
        {
            if (start >= end)
                return;

            int pivot = quickSortPartition(input, start, end, ascending);

            quickSort(input, start, pivot - 1, ascending);
            quickSort(input, pivot + 1, end, ascending);
        }

        private static int quickSortPartition(int[] input, int start, int end, bool ascending)
        {
            int pivot = input[end];
            int pivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (ascending)
                {
                    if (input[i] <= pivot)
                    {
                        int temp2 = input[i];
                        input[i] = input[pivotIndex];
                        input[pivotIndex] = temp2;
                        pivotIndex++;
                    }
                }
                else
                {
                    if (input[i] >= pivot)
                    {
                        int temp2 = input[i];
                        input[i] = input[pivotIndex];
                        input[pivotIndex] = temp2;
                        pivotIndex++;
                    }
                }
            }

            int temp = input[pivotIndex];
            input[pivotIndex] = input[end];
            input[end] = temp;

            return pivotIndex;
        }
        #endregion

        #region Randomised Quick Sort
        /// <summary>
        /// The same algorithm as a normal QuickSort, but we use a random pivot instead.
        /// On large sets, this will run in O(nlogn), the best case for a QuickSort.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] RandomQuickSort(int[] input)
        {
            return RandomQuickSort(input, true);
        }

        public static int[] RandomQuickSort(int[] input, bool ascending)
        {
            randomQuickSort(input, 0, input.Length - 1, ascending);
            return input;
        }

        private static void randomQuickSort(int[] input, int start, int end, bool ascending)
        {
            if (start < end)
            {
                int pivot = randomPartition(input, start, end, ascending);

                randomQuickSort(input, start, pivot - 1, ascending);
                randomQuickSort(input, pivot + 1, end, ascending);
            }
        }

        private static int randomPartition(int[] input, int start, int end, bool ascending)
        {
            Random rnd = new Random();
            int i = rnd.Next(start, end);

            int pivot = input[i];
            input[i] = input[end];
            input[end] = pivot;

            return randomQuickSortPartition(input, start, end, ascending);
        }

        private static int randomQuickSortPartition(int[] input, int start, int end, bool ascending)
        {
            int pivot = input[end];
            int temp;

            int i = start;
            for (int j = start; j < end; j++)
            {
                if (ascending)
                {
                    if (input[j] <= pivot)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                else
                {
                    if (input[j] >= pivot)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
            }

            input[end] = input[i];
            input[i] = pivot;

            return i;
        }

        #endregion

        #region Radix Sort
        /// <summary>
        /// Radix sort uses the individual digits of the input, this is the Least Significant Digit sorting algorithm
        /// Runs with worst case O(n * number of digits)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] RadixSort(int[] input)
        {
            return RadixSort(input, true);
        }

        public static int[] RadixSort(int[] input, bool ascending)
        {
            if (ascending)
                return radixSortAux(input, 1);
            return radixSortAux(input, 1).Reverse().ToArray();
        }

        private static int[] radixSortAux(int[] input, int digit)
        {
            bool empty = true;

            KVEntry[] digits = new KVEntry[input.Length];
            int[] sortedArray = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                digits[i] = new KVEntry();
                digits[i].Key = i;
                digits[i].Value = (input[i] / digit) % 10;
                if ((input[i] / digit) != 0)
                    empty = false;
            }

            if (empty)
                return input;

            KVEntry[] sortedDigits = radixCountingSort(digits);
            for (int i = 0; i < sortedArray.Length; i++)
                sortedArray[i] = input[sortedDigits[i].Key];

            return radixSortAux(sortedArray, digit * 10);
        }

        private static KVEntry[] radixCountingSort(KVEntry[] inputA)
        {
            int[] inputB = new int[MaxValue(inputA) + 1];
            KVEntry[] inputC = new KVEntry[inputA.Length];

            for (int i = 0; i < inputB.Length; i++)
                inputB[i] = 0;

            for (int i = 0; i < inputA.Length; i++)
                inputB[inputA[i].Value]++;

            for (int i = 1; i < inputB.Length; i++)
                inputB[i] += inputB[i - 1];

            for (int i = inputA.Length - 1; i >= 0; i--)
            {
                int value = inputA[i].Value;
                int index = inputB[value];

                inputB[value]--;
                inputC[index - 1] = new KVEntry();
                inputC[index - 1].Key = i;
                inputC[index - 1].Value = value;
            }

            return inputC;
        }

        private static int MaxValue(KVEntry[] input)
        {
            int max = input[0].Value;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i].Value > max)
                    max = input[i].Value;
            }
            return max;
        }

        struct KVEntry
        {            
            private int key;
            public int Key
            {
                get
                {
                    return key;
                }
                set
                {
                    if (key >= 0)
                        key = value;
                    else
                        throw new Exception("Invalid Key Value");
                }
            }

            private int value;
            public int Value
            {
                get
                {
                    return value;
                }
                set
                {
                    this.value = value;
                }
            }
        }
        #endregion
    }
}
