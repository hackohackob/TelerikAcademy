using System;

//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

class QuickSort
{
    static void Main()
    {
        string[] arrayUnsorted = { "f", "a", "k", "c", "o", "f", "f" };

        for (int i = 0; i < arrayUnsorted.Length; i++)
        {
            Console.Write(arrayUnsorted[i]+" ");
        }
        Console.WriteLine();

        QuickSortIt(arrayUnsorted,0,arrayUnsorted.Length-1);

        for (int i = 0; i < arrayUnsorted.Length; i++)
        {
            Console.Write(arrayUnsorted[i] + " ");
        }
        Console.WriteLine();
    }

    public static void QuickSortIt(IComparable[] elements, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap
                IComparable tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        // Recursive calls
        if (left < j)
        {
            QuickSortIt(elements, left, j);
        }

        if (i < right)
        {
            QuickSortIt(elements, i, right);
        }

    }
}