using System;

class Program
{
    public class Coordinates
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public Coordinates(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public static Coordinates RotatedCoordinates(Coordinates newCoordinates, double angle)
    {
        double sin = Math.Abs(Math.Sin(angle));
        double cos = Math.Abs(Math.Cos(angle));

        return new Coordinates(
          cos * newCoordinates.X + sin * newCoordinates.Y,
          sin * newCoordinates.X + cos * newCoordinates.Y);
    }

}