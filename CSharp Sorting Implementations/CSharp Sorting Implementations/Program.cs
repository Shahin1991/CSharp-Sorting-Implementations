using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Sorting_Implementations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] inputUnsortedNumbers = new int[] { 65, 45, 36, 89, 21, 76, 87, 23, 34 };
                //int[] selectionSortedNumber = SelectionSortImpl(inputUnsortedNumbers);
                //int[] bubbleSortedNumber = BubbleSortImpl(inputUnsortedNumbers);
                //int[] insertionSortedNumber = InsertionSortImpl(inputUnsortedNumbers);
                //int[] mergeSortedNumber = MergeSortMain(inputUnsortedNumbers);
                int[] quickSortedNumber = QuickSortImpl(inputUnsortedNumbers, 0, inputUnsortedNumbers.Length - 1);



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        static int[] SelectionSortImpl(int[] input)
        {
            try
            {
                int[] inputArray = input;

                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    int indexmin = i;
                    for (int j = i + 1; j < inputArray.Length; j++)
                    {
                        if (inputArray[j] < inputArray[indexmin])
                        {
                            indexmin = j;
                        }
                    }
                    int temp = inputArray[i];
                    inputArray[i] = inputArray[indexmin];
                    inputArray[indexmin] = temp;
                }
                return inputArray;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static int[] BubbleSortImpl(int[] input)
        {
            try
            {
                int[] inputArray = input;
                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    bool swapInCurrentIteration = false;
                    for (int j = 0; j < inputArray.Length - i - 1; j++)
                    {
                        if (inputArray[j + 1] < inputArray[j])
                        {
                            //swap
                            int temp = inputArray[j];
                            inputArray[j] = inputArray[j + 1];
                            inputArray[j + 1] = temp;
                            swapInCurrentIteration = true;
                        }
                    }
                    //to prevent redundant pass
                    if (!swapInCurrentIteration)
                    {
                        break;
                    }
                }
                return inputArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static int[] InsertionSortImpl(int[] input)
        {
            try
            {
                int[] inputArray = input;
                for (int i = 1; i < inputArray.Length; i++)
                {
                    int hole = i;
                    int currentComparingValue = inputArray[i];

                    while (hole != 0 && inputArray[hole - 1] > currentComparingValue)
                    {
                        inputArray[hole] = inputArray[hole - 1];
                        hole -= 1;
                    }
                    inputArray[hole] = currentComparingValue;
                }
                return inputArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static int[] MergeSortMain(int[] input)
        {
            int arrayLength = input.Length;
            int middle = ((arrayLength % 2) == 0) ? arrayLength / 2 : ((arrayLength + 1) / 2);

            //When array length becomes 1, we have to return as we cannot split it any further
            if (arrayLength < 2)
            {
                return input;
            }

            //left array until middle or (middle+1) elements and right array is the remaining elements
            int[] leftArray = new int[middle];
            int[] rightArray = new int[arrayLength - middle];

            for (int i = 0; i < middle; i++)
            {
                leftArray[i] = input[i];
            }
            for (int j = 0; j < (arrayLength - middle); j++)
            {
                rightArray[j] = input[middle + j];
            }

            //Call this same method recursively for the left and right sides so that it is broken down by 2 with each recursion and eventually becomes a 1 element array
            leftArray = MergeSortMain(leftArray);
            rightArray = MergeSortMain(rightArray);

            //Once we have the single element array, we have to start merging them. That is done inside this function. 
            int[] outputArray = MergeSortMergeFunction(leftArray, rightArray);
            return outputArray;
        }

        static int[] MergeSortMergeFunction(int[] leftArray, int[] rightArray)
        {

            int nL = leftArray.Length;
            int nR = rightArray.Length;
            int[] outputArray = new int[nL + nR];
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < nL && j < nR)
            {
                if (leftArray[i] <= rightArray[j])  // equality to make stability
                {
                    outputArray[k] = leftArray[i];
                    i++;
                    k++;
                }
                else
                {
                    outputArray[k] = rightArray[j];
                    j++;
                    k++;
                }
            }

            while (i < nL)
            {
                outputArray[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < nR)
            {
                outputArray[k] = rightArray[j];
                j++;
                k++;
            }
            return outputArray;
        }

        static int[] QuickSortImpl(int[] inputArray, int startIndex, int endIndex)
        {
            try
            {
                //need to do the recursive calls only as long as this condition is satisfied
                if (startIndex < endIndex)
                {
                    //partition method
                    //we are replacing the input array with the output argument in Partition method
                    int pIndex = QuickSortPartition(inputArray, startIndex, endIndex, out inputArray);
                    //Now we need quick sorts on left and right subarrays of the pivot;
                    //left subarray is from start index to pIndex-1
                    //right subarray is from pIndex+1 to endIndex
                    QuickSortImpl(inputArray, startIndex, pIndex - 1);
                    QuickSortImpl(inputArray, pIndex + 1, endIndex);
                }
                return inputArray;
            }

            catch (Exception ex)
            {
                return inputArray;
                throw;
            }
        }

        static int QuickSortPartition(int[] inputArray, int startIndex, int endIndex, out int[] outputArray)
        {
            try
            {
                int pivot = inputArray[endIndex];
                int nextFillablePosition = startIndex;
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (inputArray[i] < pivot)
                    {
                        //swap nextfillable index with index i
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[nextFillablePosition];
                        inputArray[nextFillablePosition] = temp;
                        nextFillablePosition++;
                    }
                }
                //swap pivot with the nextfillable position
                int temp1 = inputArray[endIndex];
                inputArray[endIndex] = inputArray[nextFillablePosition];
                inputArray[nextFillablePosition] = temp1;

                outputArray = inputArray; //our original array has been rearranged here, so we are passing that as the output
                return nextFillablePosition; //next fillable position is the pivot position at the end
            }
            catch (Exception ex)
            {
                outputArray = inputArray; //Exceptions wont occur; If it occurs, the sorting process would fail
                return 0;
                throw;
            }
        }
    }
}
