using System;

//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine(Surface(3, 20));
        Console.WriteLine(Surface(3, 4,5));
        Console.WriteLine(Surface(3 , 4,35.0));


    }

    static double Surface(int a, int h)
    {
        double surface= (a*h)/2;
        return surface; 
    }

    static double Surface(int a, int b, int c)
    {
        //we use the formula √{s (s - a)(s - b)(s - c)} s==p/2;
        double s = (a + b + c) / 2;
        double surface = Math.Sqrt(s * (s - (double)a) * (s - (double)b) * (s - (double)c));
        return surface;
    }

    static double Surface(int a, int b, double angle)
    {
        angle = (angle * Math.PI) / 180; //multiply bi PI and devide by 180 to convert the degrees into radians
        double surface = (a * b * Math.Sin(angle)) / 2;
        return surface;
    }
}