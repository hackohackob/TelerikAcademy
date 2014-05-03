using System;

//Write a program to convert binary numbers to their decimal representation.

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Input a binary number:");
        string binaryNumber = Console.ReadLine(); ;

        int decimalNumber = new int();

        for (int i= binaryNumber.Length-1; i >=0; i--)
        {
            decimalNumber += int.Parse(binaryNumber[i].ToString()) * stepen(2, binaryNumber.Length - i -1);
        }
        Console.WriteLine(decimalNumber);
    }

    static int stepen(int number,int power)
    {
        int returnedNumber = number;
        if(power==0)
        {
            return 1;
        }
        for (int i = 0; i < power-1; i++)
        {
            returnedNumber = returnedNumber * number;
        }
        return returnedNumber;
    }
}