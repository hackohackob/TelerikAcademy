using System;

//Write a program that reads from the console a sequence of N integer numbers 
//and returns the minimal and maximal of them.

class MinAndMax
{
    static void Main()
    {
        int input,max=int.MinValue, min=int.MaxValue;

        Console.Write("How many numbers you'll input:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <=n; i++)
        {
            Console.Write("Enter number {0}:", i );
            input = int.Parse(Console.ReadLine());

            if (input > max)
            {
                max = input;
            }
            if (input < min)
            {
                min = input;
            }
        }

        Console.WriteLine("The smallest of the numbers is: {0} and the biggest is: {1}",min,max);
    }
}