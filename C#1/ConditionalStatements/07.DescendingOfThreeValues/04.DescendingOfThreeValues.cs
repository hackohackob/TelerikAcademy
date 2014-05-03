using System;

//Sort 3 real values in descending order 
class DescendingOfThreeValues
{
    static void Main()
    {
        int first, second, third, help;
        Console.Write("Input the first number:");
        first = int.Parse(Console.ReadLine());
        Console.Write("Input the second number:");
        second = int.Parse(Console.ReadLine());
        Console.Write("Input the third number:");
        third = int.Parse(Console.ReadLine());
        Console.WriteLine();

        if(first<second)
        {
            help = first;
            first = second;
            second = help;
        }
        if(second<third)
        {
            help = second;
            second = third;
            third = help;
        }
        if(first<second)
        {
            help = first;
            first = second;
            second = help;
        }
        Console.WriteLine("The numbers is descending order are:{0}, {1}, {2}",first,second,third);
    }
}

