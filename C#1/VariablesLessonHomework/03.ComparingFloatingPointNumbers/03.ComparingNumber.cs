using System;

//Write a program that compares two numbers of type double with a precision of 0.000001
class ComparingNumbers
{
    static void Main()
    {
        double a, b; //Declaring two double variables
        bool result; //Declaring a bool variable to save the result
        a = 5.00000000000004; //Inputing the two numbers
        b = 4.99999999990001;
        result = b - a < Math.Abs(0.00001);  //Calculating the absolute value of the difference between the numbers
        Console.WriteLine(result);           //Writing the result on to the Console
        
    }
}