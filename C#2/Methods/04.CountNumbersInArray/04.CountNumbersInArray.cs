using System;

//Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.


class CountNumbersInArray
{
    static void FindMyNumber(int[] array,int searched)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i]==searched)
            {
                counter++;
            }
        }
        Console.WriteLine("The number {0} is seen {1} times in the array",searched,counter);
    }
    static void Main()
    {
        int[] array = { 1, 7, 4, 2, 6, 3, 8, 9, 4, 3, 1, 5, 2, 2 };
        int searchedNumber = 2;
        FindMyNumber(array, searchedNumber);
    }
}