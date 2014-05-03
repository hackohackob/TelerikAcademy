using System;

//Write a program that reads the radius r of a circle and prints its perimeter and area
class CircleRadiusAndArea
{
    static void Main()
    {
        double r, per, area;
        Console.Write("Please input the radius: ");
        r = double.Parse(Console.ReadLine());           //Inputting r from the console
        per = 2 * Math.PI * r;                          //Calculating the perimeter by the formula : Perimeter=2*Pi*R
        area = Math.PI * r * r;                         ////Calculating the perimeter by the formula : Perimeter=Pi*R*R
        Console.WriteLine("The perimeter of the cirsle is {0:0.00} and the area is {1:0.00}",per,area); //Printing out the perimeter an dthe area using string formating
    }
}
