using System;

namespace SortingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 990, 888, 1, 3, 101, 20, 696 };

            //Just uncomment the function below to run every sorting algorithm.
            BubbleSort(arr);
            //InsertionSort(arr);
            //SelectionSort(arr);
            //MergeSort(arr, 0, arr.Length - 1);
            //QuickSort(arr, 0, arr.Length - 1);
            //HeapSort(arr, arr.Length);

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.ReadKey();
        }

        static void ConsoleWriteArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.Write("\n");
        }

        static int[] BubbleSort(int[] arr)
        {
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }

        static int[] BubbleSortWithSteps(int[] arr)
        {
            ConsoleWriteArray(arr);
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
                ConsoleWriteArray(arr);
            }

            return arr;
        }

        static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;

                int temp = arr[i];
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = temp;
            }
            return arr;
        }

        static int[] InsertionSortWithSteps(int[] arr)
        {
            ConsoleWriteArray(arr);
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;

                int temp = arr[i];
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = temp;
                ConsoleWriteArray(arr);
            }
            return arr;
        }

        static int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int temp = arr[i];
                int tempInt = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        tempInt = j;
                    }

                }
                arr[i] = min;
                arr[tempInt] = temp;
            }

            return arr;
        }

        static int[] SelectionSortWithSteps(int[] arr)
        {
            ConsoleWriteArray(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int temp = arr[i];
                int tempInt = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        tempInt = j;
                    }

                }
                arr[i] = min;
                arr[tempInt] = temp;
                ConsoleWriteArray(arr);
            }

            return arr;
        }

        static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        static int Partition(int[] arr, int low,
                                   int high)
        {
            int pivot = arr[high];

            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static void HeapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, n, largest);
            }
        }
    }
}
