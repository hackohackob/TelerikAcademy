using System;

class Program
{
    static void Main()
    {
        //Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

        Point3D tochka = new Point3D(2, 3, 4);
        Point3D tochka2 = new Point3D();
        Console.WriteLine(tochka2.ToString());
        Console.WriteLine( tochka.ToString());

        Console.WriteLine( Distance.Calculate(tochka, tochka2));
    }
}
