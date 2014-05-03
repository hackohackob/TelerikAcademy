using System;

//Write a program that finds the biggest of three integers using nested if statements

class BiggestOfThree
{
    static void Main()
    {
        int first, second, third;
        Console.Write("Input the first number:");
        first = int.Parse(Console.ReadLine());
        Console.Write("Input the second number:");
        second = int.Parse(Console.ReadLine());
        Console.Write("Input the third number:");
        third = int.Parse(Console.ReadLine());
        Console.WriteLine();
        if(first>second && first>third)
        {
            Console.WriteLine("The biggest number is the first");
        }
        else if(second>first && second>third)
        {
            Console.WriteLine("The biggest number is the second");
        }
        else if(third>first && third>second)
        {
            Console.WriteLine("The biggest number is the third");
        }
        else
        {
            Console.WriteLine("The numbers are equal");
        }
    }
}

