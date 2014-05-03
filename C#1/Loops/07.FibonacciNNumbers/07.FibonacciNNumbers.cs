using System;

class FibonacciNNumbers
{
    static void Main()
    {
        Console.Write("How many Fibonacci members will be calculated:");
        int n = int.Parse(Console.ReadLine());

        decimal firstNumber = 0m;
        decimal secondNumber = 1m;
        decimal sum;
        decimal total = 0;

        for (int i = 0; i < n; i++)
        {
            total += firstNumber;

            sum = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = sum;
        }

        Console.WriteLine("The sum of the first {0} Fibonacci members is {1}", n, total);
    }
}