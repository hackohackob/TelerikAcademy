using System;
using System.IO;

//Write a program that reads a text file and prints on the console its odd lines
class PrintOddLines
{
    static void Main()
    {
        int n = 1;

        using (StreamReader input = new StreamReader("test.txt"))
        {
            for (string line; (line = input.ReadLine()) != null; n++)
            {
                if (n % 2 == 1)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}