﻿using System;

//Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

class SortingArray
{
    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] +  " ");
        }
    }


    static void Swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    // Returns the min/max element starting from position i to the end of the array
    static int GetBestFromPosition(int[] arr, int i, bool descending)
    {
        int best = i;

        for (i++; i < arr.Length; i++)
        {
            if (descending ? arr[i] < arr[best] : arr[best] < arr[i])
            {
                best = i;
            }
        }
        return best;
    }

    static void SelectionSort(int[] arr, bool descending = false)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Swap(arr, i, GetBestFromPosition(arr, i, descending));
        }
    }

    static void Main()
    {
        int[] arr = { -1, -3, 4, -5, 6, -7 };

        SelectionSort(arr);
        PrintArray(arr);

        Console.WriteLine();
        SelectionSort(arr, descending: true);
        PrintArray(arr);
        Console.WriteLine();
    }
}