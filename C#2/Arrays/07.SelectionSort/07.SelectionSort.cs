using System;

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

class SelectionSort
{
    static void Main()
    {
        Console.Write("Input the length of the array:");    //Inputting the length of the array
        int n = int.Parse(Console.ReadLine()); 

        int[] array = new int[n]; //defining the array

        for (int i = 0; i < n; i++) //inputting the array
        {
            Console.Write("Input {0} element",i+1);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Unsorted:"); //Printing out the unsorted array
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i]+" ");
        }
        Console.WriteLine();

        for (int i = 0; i < n; i++) //Using for operator to cycle trough all the numbers in the array and to sort them.
        {
            int smallest = int.MaxValue; //defining a variable to hold the smallest number in the array
            int smallestIndex = 0;       //defining a variable to hold the index of the smallest number
            int help = 0;                //defining a variable to hold the number we will swap with the smallest number

            for (int j = i; j < n; j++)  //finding the smallest number and its index. !j=i because firts time we will search trough all the numbers and will put the smallest
            {                            //at first place. After that we know that the first number is the smallest so we will search for the smallest numbers after it
                if(array[j]<smallest)
                {
                    smallest = array[j];
                    smallestIndex = j;
                }
            }

            help = array[i];            //putting the value of the number we will swap with the smallest in a helping variable
            array[i] = smallest;        //putting the smallest number in its place
            array[smallestIndex] = help;//putting the number from the variable "help", where we have get the smallest number
        }
        

        Console.WriteLine("Sorted:"); //Printing the sorted array
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i] + " "); 
        }
        Console.WriteLine();
    }
}