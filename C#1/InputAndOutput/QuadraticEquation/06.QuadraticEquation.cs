using System;

//Write a program that reads the coefficients a,b and c of a quadratic equation ax^2+bx+c=0 and solves it (prints its real roots).
class QuadraticEquation
{
    static void Main()
    {
        double a, b, c,D,x1=0,x2;
        Console.WriteLine("Please fill the coefficients in the quadratic quation");

        Console.Write("a=");                        //Reading the coefficients from the console
        a = double.Parse(Console.ReadLine());
        Console.Write("b=");
        b = double.Parse(Console.ReadLine());
        Console.Write("c=");
        c = double.Parse(Console.ReadLine());
        Console.Clear();                            //Clearing the console

        if (c >= 0)                                             //Printing out the equation (if c<0 then we wont print the last + sing)
        {
            Console.WriteLine("{0}x^2+{1}x+{2}=", a, b, c);
        }
        else
        {
            Console.WriteLine("{0}x^2+{1}x{2}=", a, b, c);
        }
        Console.WriteLine();

        D = (b * b) - 4 * a * c;                                //Calculating the discriminant

        Console.WriteLine("D={0}",D);                           //Printing out the Discriminant
        Console.WriteLine();

        if (D < 0)                                              //Printing put the result, depending on the value of the Discriminant
        {
            Console.WriteLine("D<0! The quadratic equation doesn't have real roots!");
        }
        else if (D == 0)
        {
            Console.WriteLine("x1=x2= {0}",-b / 2 * a);
        }
        else
        {
            Console.WriteLine("x1= {0:0.00}", (-b + Math.Sqrt(D)) / 2 * a);
            Console.WriteLine("x2= {0:0.00}", (-b - Math.Sqrt(D)) / 2 * a);
        }

    }
}
