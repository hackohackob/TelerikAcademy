using System;

//Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
//--Use the method from the previous exercise.

class FirstBiggerThanNeighbours
{
    static bool bigger = false;
    static void CompareWithNeighbors(int[] array, int pos)
    {
        bigger = false;
        if (pos > 1 && pos < array.Length)
        {
            if (array[pos] > array[pos - 1] && array[pos] > array[pos + 1])
            {
                bigger = true;
            }
        }
        else if (pos == 1)
        {
            if (array[pos] > array[pos + 1])
            {
                bigger = true;
            }
        }
        else if (pos == array.Length)
        {
            if (array[pos] > array[pos + 1])
            {
                bigger = true;
            }
        }

        if (bigger)
        {
            Console.WriteLine("The number with index {0} is the first number bigger than its neighbors",pos);
        }

    }
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 3, 2, 4, 5, 6, 7, 6, 5 };
        for (int i = 0; i < array.Length; i++)
        {
            CompareWithNeighbors(array, i);
            if(bigger)
            {
                break;
            }
        }

    }
}