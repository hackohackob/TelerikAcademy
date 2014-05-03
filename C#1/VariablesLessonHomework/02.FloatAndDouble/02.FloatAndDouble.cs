using System;

//which of the following values can be assigned to float and which to double: 12.345, 3456.091, 34.567839023, 8923.1234857

class FloatAndDouble
{
    static void Main()
    {
        float a, b;  //Declaring float variables
        double c, d; //Declaring double variables
        a = 12.345f;
        b = 3456.091f;
        c = 34.567839023;
        d = 8923.1234857;
        Console.WriteLine("{0}\n{1}\n{2}\n{3}",a,b,c,d);
    }
}