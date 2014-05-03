using System;

//Write a program that enters the coefficients a, b and c of a quadratic equation
//a*x2 + b*x + c = 0
//and calculates and prints its real roots. 
//Note that quadratic equations may have 0, 1 or 2 real roots.


class QuadraticEquation
{
    static void Main()
    {
        double a, b, c, D;
        Console.Write("Input \"a\":");
        a = int.Parse(Console.ReadLine());
        Console.Write("Input \"b\":");
        b = int.Parse(Console.ReadLine());
        Console.Write("Input \"c\":");
        c = int.Parse(Console.ReadLine());

        D = (b * b) - 4 * a * c;

        if(D<0)
        {
            Console.WriteLine("The equations doesn't have real roots");
        }
        if(D==0)
        {
            double x1=-b/2*a;
            Console.WriteLine("The equation has 1 real root: {0:0.00}", x1);
        }
        if(D>0)
        {
            double x1,x2;
            x1=(-b+Math.Sqrt(D))/2*a;
            x2=(-b-Math.Sqrt(D))/2*a;
            Console.WriteLine("The equation has 2 real roots: {0:0.00} and {1:0.00}",x1,x2);
        }
    }
}