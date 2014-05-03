using System;

//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

class BinarySearch
{
    static void Main()
    {
        Console.Write("Input the length of the array:"); //inputting the length of the array
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input the searched number:");
        int searched = int.Parse(Console.ReadLine());

        int[] array = new int[n];                       //defining the array

        for (int i = 0; i < n; i++)                     //inputting the array
        {
            Console.Write("Input {0} number:", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);                          //making sure the array is sorted

        int first=0,last=array.Length-1;           //defining variables first and last to help us calculate where is the middle
        int middle;                              //defining variable to save the index of the middle number in the array 

        while(true)
        {
            middle = (((last - first) / 2)+first);  //calculating where the middle is. we calculate it by calculating the half of the distance between the first and the last 
                                                    //checked number. and adding this distance to the first number
            if(searched==array[middle])             //if the searched number is equal to the middle, we print out the index of the number and break the while operator
            {
                Console.WriteLine("The number is with index {0}", middle); break;
            }
            else if(searched<array[middle])         //if the searched number is smaller than the middle, then we "split" the array in half and search only in the left half
            {                                       //this is done by making the current middle, the last number for the next cycle 
                last = middle;
            }
            else if(searched>array[middle])         //if the searched number is bigger than the middle, then we need to search in the right half of the array
            {                                       //this is done by making the current middle, the first number for the next cycle
                first = middle;
            }
        }

    }
}