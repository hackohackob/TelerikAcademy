using System;

//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

class LeapYear
{
    static void Main()
    {
        Console.Write("Input year:");
        int year=int.Parse(Console.ReadLine());

        Console.WriteLine(IsLeap(year));
    }

    static bool IsLeap(int year)
    {
        return DateTime.IsLeapYear(year);
    }
}