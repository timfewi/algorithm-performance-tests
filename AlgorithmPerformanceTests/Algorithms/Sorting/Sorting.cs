using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPerformanceTests.Algorithms.Sorting
{
    internal class Sorting
    {
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;
            }
        }

        public static void MergeSort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        public static void ParallelMergeSort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, left, mid);
            Array.Copy(array, mid, right, 0, right.Length);

            Parallel.Invoke(
                () => ParallelMergeSort(left),
                () => ParallelMergeSort(right)
            );

            Merge(array, left, right);
        }


        private static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(array, left, middle);
                Sort(array, middle + 1, right);

                Merge(array, left, middle, right);
            }
        }
        private static void Merge(int[] array, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(array, left, leftArray, 0, middle - left + 1);
            Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    array[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }


        }
        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            for (int k = 0; k < array.Length; k++)
            {
                if (i == left.Length)
                {
                    array[k] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    array[k] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
            }
        }



        private const int Threshold = 10;

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int low, int high)
        {
            while (low < high)
            {
                // Insertion Sort für kleine Teilmengen
                if (high - low < Threshold)
                {
                    InsertionSort(array, low, high);
                    break;
                }

                int pivotIndex = Partition(array, low, high);

                // Rekursion auf den kleineren Teil des Arrays anwenden
                if (pivotIndex - low < high - pivotIndex)
                {
                    QuickSort(array, low, pivotIndex - 1);
                    low = pivotIndex + 1;
                }
                else
                {
                    QuickSort(array, pivotIndex + 1, high);
                    high = pivotIndex - 1;
                }
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            // Zufällige Wahl des Pivots
            int pivotIndex = new Random().Next(low, high);
            int pivot = array[pivotIndex];
            array[pivotIndex] = array[high]; // Pivotelement ans Ende verschieben
            array[high] = pivot;

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void InsertionSort(int[] array, int low, int high)
        {
            for (int i = low + 1; i <= high; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= low && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
