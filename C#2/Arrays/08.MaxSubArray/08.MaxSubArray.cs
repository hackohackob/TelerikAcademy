using System;

//Write a program that finds the sequence of maximal sum in given array. Example:
//{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//Can you do it with only one loop (with single scan through the elements of the array)?

class MaxSubArray
{
    static void Main()
    {
        Console.Write("Input the length of the array:"); //inputting the length of the array
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];                       //defining the array

        for (int i = 0; i < n; i++)                     //inputting the array
        {
            Console.Write("Input {0} number:", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxsum = int.MinValue;                      //defining a variable in which we will store the maximal sum
        int maxi = 0, maxj = 0;                         //defining a variable in which we will store from which to which number is the maximal sum
        for (int i = 0; i < n; i++)                     //using a for operator to cycle trough the numbers 
        {
            int currentsum = 0;                         //defining a variable in which we will store the current sum

            for (int j = i; j < n; j++)                 //adding a for operator and with the help of it we will add all of the numbers with all of the following numbers 
            {                                           //one by one 
                currentsum += array[j];                 //Example: if we have {2,3,-6,-1,2,-1,6,4,-8,8} first we will add 2+3, then 2+3-6, then 2+3-6-1 ...
                if(currentsum>maxsum)                   //then we do the same with the second number. First 3-6, then 3-6-1, then 3-6-1+2....
                {                                       //and we same the maximal sum in the variable maxsum. We save the starting number in maxi, and the current number in
                    maxsum = currentsum;                //maxj
                    maxi = i;
                    maxj = j;
                }
            }

        }
        Console.Write("The numbers that form the max sum are:");    //now we just simply print the numbers with indexes from maxi to maxj (including)
        for (int i = maxi; i <=maxj; i++)
        {
            Console.Write(array[i]+" ");
        }
        Console.WriteLine();
        Console.WriteLine("The max sum is:{0}",maxsum);

    }
}