using System;
using System.Collections.Generic;

//Write a method that reverses the digits of given decimal number. Example: 256  652

class ReverseDigits
{
    static void Reverse(int number)
    {
        string numberAsString = number.ToString();
        string reversedAsString="";

        for (int i = numberAsString.Length-1; i >= 0; i--)
        {
            reversedAsString = reversedAsString + numberAsString[i];
        }
        int reversedNumber = int.Parse(reversedAsString);
        Console.WriteLine(reversedNumber);
    }
    static void Main()
    {
        int a = 1826;

        Reverse(a);
    }
}