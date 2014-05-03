using System;

//Write an expression that checks if given point (x,y) is within a circle K(0,5)
class PointInCircle
{
    static void Main()
    {
        int x, y;
        double p;

        Console.Write("Please input X: ");          //Inputting X from the Console
        x = int.Parse(Console.ReadLine());
        Console.Write("Please input Y: ");          //Inputting X from the Console
        y = int.Parse(Console.ReadLine());
        p = Math.Sqrt(x * x + y * y);               //Calculating the distance between the O(0,0) and the Point
        if(p<=5)                                    //Checking if the distance is smaller or equal to the radius.
        {
            Console.WriteLine("The point is IN the area of the circle");        //If the distance is smaller or equal to the radius, the point is in the area of the circle
        }
        else
        {
            Console.WriteLine("The point is OUT of the area of the circle");
        }
    }
}
