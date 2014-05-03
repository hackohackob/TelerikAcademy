using System;

//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

class SortByLength
{
    static void Main()
    {
        string[] sArray = { "abbbbcdddefggf", "abc", "cbde", "abcdef", "abcdeefgh", "ab", "abcde" };
        string shelp;
        int[] length = new int[sArray.Length];
        int ihelp;
        int minI=int.MaxValue;
        int minVal = 0;

        for (int i = 0; i < length.Length; i++)
        {
            length[i] = sArray[i].Length;
        }

        Console.WriteLine("-----UNSORTED-----");
        for (int i = 0; i < sArray.Length; i++)
        {
            Console.WriteLine(sArray[i]);
        }

        for (int i = 0; i < length.Length-1; i++)
        {
            minI=i;
            minVal = length[i];
            for (int j=i+1; j < length.Length; j++)
            {
                if(length[j]<minVal)
                {
                    minI = j;
                    minVal = length[j];

                }
            }

            ihelp = length[i];
            length[i] = length[minI];
            length[minI] = ihelp;

            shelp = sArray[i];
            sArray[i] = sArray[minI];
            sArray[minI] = shelp;
            
        }

        Console.WriteLine("------SORTED------");
        for (int i = 0; i < sArray.Length; i++)
        {
            Console.WriteLine(sArray[i]);
        }
    }
}