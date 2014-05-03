using System;

//Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.
class NumbersInInterval
{
    static void Main()
    {
        int n;
        Console.Write("Please input number: ");
        n = int.Parse(Console.ReadLine());              //Reading a number from the console

        for (int i = 1; i <=n; i++)                     //Using a for operator to cycle trough all the numbers from 1 to n and print them out
        {
            Console.WriteLine(i);
        }
    }
}
