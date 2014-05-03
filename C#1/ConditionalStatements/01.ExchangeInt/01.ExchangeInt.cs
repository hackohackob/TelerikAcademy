using System;

//Write an if statement that examines two integer variables 
//and exchanges their values if the first one is greater than the second one.
class ExchangeInt
{
    static void Main()
    {
        int first, second, help;
        Console.Write("Input the first number:");
        first = int.Parse(Console.ReadLine());
        Console.Write("Input the second number:");
        second = int.Parse(Console.ReadLine());
        Console.WriteLine();
        if(first<second)
        {
            Console.WriteLine("The first number is smaller than the second. No exchanging.");
        }
        else if(first==second)
        {
            Console.WriteLine("The first is equal to the second. No exchanging");
        }
        else
        {
            help = first;
            first = second;
            second = help;
            Console.WriteLine("The first is bigger than the second. The numbers have been exchanged.");
        }
    }
}

