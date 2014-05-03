using System;

//Write a program to convert decimal numbers to their binary representation.

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Input a number:");
        int decimalNumber = int.Parse(Console.ReadLine());
        string reversedBinary = "";
        while(decimalNumber>0)
        {
            reversedBinary += decimalNumber % 2;
            decimalNumber = decimalNumber / 2;
        }

        char[] reversedBinaryArray = reversedBinary.ToCharArray();
        Array.Reverse(reversedBinaryArray);
        string binaryNumber = "";
        for (int i = 0; i < reversedBinaryArray.Length; i++)
        {
            binaryNumber += reversedBinaryArray[i];
        }
        Console.WriteLine(binaryNumber);
    }
}