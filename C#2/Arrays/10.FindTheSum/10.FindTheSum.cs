using System;

//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
class FindTheSum
{
    static void Main()
    {
        Console.Write("Input the length of the array:"); //inputting the length of the array
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input the sum:");
        int s = int.Parse(Console.ReadLine());

        int[] array = new int[n];                       //defining the array

        for (int i = 0; i < n; i++)                     //inputting the array
        {
            Console.Write("Input {0} number:", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        int i1 = 0, j1 = 0;                         //defining variables in which we will save the first index and the last index of the subset with the wanted sum

        for (int i = 0; i < n; i++)                     //using a for operator to cycle trough the numbers 
        {
            int currentsum = 0;                         //defining a variable in which we will store the current sum

            for (int j = i; j < n; j++)                 //adding a for operator and with the help of it we will add all of the numbers with all of the following numbers 
            {                                           //one by one 
                currentsum += array[j];                 //Example: if we have {2,3,-6,-1,2,-1,6,4,-8,8} first we will add 2+3, then 2+3-6, then 2+3-6-1 ...
                if (currentsum == s)                   //then we do the same with the second number. First 3-6, then 3-6-1, then 3-6-1+2....
                {                                       //if the current sum is equal to the wanted sum we save the first index and the last index in the variables i1,j1
                    i1 = i;
                    j1 = j;
                }
            }

        }

        Console.Write("The numbers which make the wanted sum are:"); //printing out the numbers
        for (int i = i1; i <=j1; i++)
        {
            Console.Write(array[i]+" ");
        }
        Console.WriteLine();
    }
}