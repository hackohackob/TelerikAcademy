using System;

class ShortToBinary
{
    static string ToBinary(short s)
    {
        string b = String.Empty;

        for (int i = 0; i < 16; i++)
        {
            b = (s >> i & 1) + b;
        }

        return b;
    }

    static void Main()
    {
        Console.Write("Input a 16 bit integer number(short):");
        short number = short.Parse(Console.ReadLine());
        Console.WriteLine(ToBinary(number));
    }
}