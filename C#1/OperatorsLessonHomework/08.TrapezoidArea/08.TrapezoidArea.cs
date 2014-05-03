using System;

class TrapezoidArea
{
    static void Main()
    {
        double a, b, h, S;
        Console.Write("Plese input a: ");         //Inputting a
        a = int.Parse(Console.ReadLine());
        Console.Write("Plese input b: ");         //Inputting b
        b = int.Parse(Console.ReadLine());
        Console.Write("Plese input h: ");         //Inputting h
        h = int.Parse(Console.ReadLine());
        Console.Clear();                          //Clearing the Console
        S = ((a + b) / 2) * h;                    //Calculating the Area of the trapezoid
        Console.WriteLine("Area: {0}",S);

    }
}