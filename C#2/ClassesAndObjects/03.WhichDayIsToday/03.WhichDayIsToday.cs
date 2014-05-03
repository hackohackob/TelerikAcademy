using System;

//Write a program that prints to the console which day of the week is today. Use System.DateTime.

class WhichDayIsToday
{
    static void Main()
    {
        System.DateTime now = DateTime.Now;
        Console.WriteLine("Today is: "+now.DayOfWeek);

    }
}