using System;

//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinarySearch() finds the largest number in the array which is <= K.

class BinarySearch
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        
        if(array[0]>k)
        {
            Console.WriteLine("There is no number that is less or equal to k");
        }
        else
        {
            if(Array.BinarySearch(array,k)>0)
            {
                Console.WriteLine("The index of the element which has a value K is:{0}", Array.BinarySearch(array, k));
            }
            else
            {
                Console.WriteLine("The is no number with a value of K in the array. \nThe biggest number that is smaller than K is with index:{0}", Math.Abs(Array.BinarySearch(array, k))-2);
            }
        }
    }
}