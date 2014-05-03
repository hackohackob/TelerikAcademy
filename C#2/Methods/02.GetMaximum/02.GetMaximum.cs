using System;

//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

class GetMaximum
{
    static int GetMax(int firstNumber,int secondNumber)
    {
        int max = firstNumber;
        if(secondNumber>firstNumber)
        {
            max = secondNumber;
        }
        return max;
    }
    static void Main()
    {
        int a = 4, b = 8, c = -10;
        Console.WriteLine(GetMax(a, GetMax(b, c)));

    }
}