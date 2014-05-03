using System;

//Write an expression that checks for given point (x,y) if it is within the circle K([1,1],3) and out of the rectangle R(top=1, left=-1, width=6, height=2).
class PointInCircleOrRectangle
{
    static void Main()
    {
        int x, y;
        double p;
        Console.Write("Please input x:");       //Inputting x
        x = int.Parse(Console.ReadLine());
        Console.Write("Please input y:");       //Inputting y
        y = int.Parse(Console.ReadLine());
        Console.Clear();                          //Clearing the Console
        x = x - 1;                              //Changing x value to x-1 and y value to y+1 so we can calculate the distance to O(-1,1)
        y = y + 1;
        p = Math.Sqrt(x * x + y * y);           //Calculating the distance to 
        if (p<=3)
        {
            Console.Write("The point is IN the area of the circle ");       //If the distance to the point(x,y) is smaller or equal to 3 (the radius) 
        }                                                                   //then the point is in the circle
        else
        {
            Console.Write("The point is OUT of the circle ");
        }
        x=x+1;                                                              //Returning x and y to their orinigal values
        y=y-1;                                                              
        if(x>=1 && x<=7 && y<=-1 && y>=-3)                                  //The rectangle is with the following values TopLeft(1,-1), TopRight(7,-1)
        {                                                                   //BottomLeft(1,-3), BottomRight(7,-3)
            Console.WriteLine("and IN the area of the rectangle.");         //Checking if the point is in the range of the rectangle and writing it out on the Console.
        }
        else
        {
            Console.WriteLine("and OUT of the rectangle.");
        }

    }
}