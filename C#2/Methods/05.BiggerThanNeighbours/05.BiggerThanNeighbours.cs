using System;

//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

class BiggerThanNeighbours
{
    static void CompareWithNeighbors(int[] array, int pos)
    {
        bool bigger = false;

        if(pos>1 && pos<array.Length)
        {
            if(array[pos]>array[pos-1] && array[pos]>array[pos+1])
            {
                bigger = true;
            }
        }
        else if(pos==1)
        {
            if(array[pos]>array[pos+1])
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

        if(bigger)
        {
            Console.WriteLine("The number at the position is bigger than its neighbors");
        }
        else
        {
            Console.WriteLine("The number at the position is not bigger than its neighbors");
        }
    }
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
        int position = 6;
        if (array.Length > 1)
        {
            CompareWithNeighbors(array, position);
        }

    }
}