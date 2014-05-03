using System;

//Write an expression that calculates rectangle's area by given width and height
class RectangleArea
{
    static void Main()
    {
        double a, b;
        Console.Write("Please input a:");
        a = int.Parse(Console.ReadLine());
        Console.Write("Please input b:");
        b = int.Parse(Console.ReadLine());
        Console.WriteLine("Width:  {0} \nHeight: {1} \nArea:   {2}",a,b,a*b);  //Writing the width, height and the area of the rectangle
    }
}