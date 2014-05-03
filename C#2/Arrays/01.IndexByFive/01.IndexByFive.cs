using System;

//Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.

class IndexByFive
{
    static void Main()
    {
        int[] array = new int[20]; //defining the array

        for (int i = 0; i < array.Length; i++) //initializing each of the elements by the its index multiplied by 5
        {
            array[i] = i * 5;   
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]+" ");    //printing the array
        }
        Console.WriteLine();
    }
}