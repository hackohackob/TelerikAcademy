using System;

//Write a program that finds the most frequent number in an array. Example:
//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

class Program
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

        int maxFrequencyNumber = 0;                     //defining a variable in which we will store the most frequent number
        int maxFrequencyTimes = 0;                      //defining a variable in which we will store how many of this numbers there are in the array

        for (int i = 0; i < n-1; i++)                   //using a for operator to cycle trough all the numbers
        {
            int currentFrequency = 0;                   //defining a variable to store the frequency of the current number

            for (int j = i+1; j < n; j++)               //checking for every number (for i=0 to n-1) how many equal numbers it have in the array(forj=i+1 to n)
            {
                if(array[i]==array[j])
                {
                    currentFrequency++;
                }
            }

            if(currentFrequency>maxFrequencyNumber)    //if the current frequency is bigger than the max recorded frequency
            {
                maxFrequencyNumber = array[i];         //saving the value of the number
                maxFrequencyTimes = currentFrequency + 1; ; //saving how many times this number can be seen in the array
            }
            
        }

        Console.WriteLine("Max frequency number is {0} ({1} times)",maxFrequencyNumber,maxFrequencyTimes); //printing out the results



    }
}