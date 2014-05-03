using System;

//Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

public struct Point3D
{

    private static readonly string separator = "-";

   public double X { get; private set; }
   public double Y { get; private set; }
   public double Z { get; private set; }

    private static int hacko;
    private static readonly Point3D zero = new Point3D(); //Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

    

    public static Point3D Zero
    {
        get { return zero; }
    }


    public Point3D(double x, double y, double z):this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }


    public  override string ToString()
    {
        string output;
        output="X:"+this.X.ToString()+" Y:"+this.Y.ToString()+" Z:"+this.Z.ToString();
        return output;
    }
}


static class Distance
{
    public static double Calculate(Point3D a, Point3D b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
    }
}
