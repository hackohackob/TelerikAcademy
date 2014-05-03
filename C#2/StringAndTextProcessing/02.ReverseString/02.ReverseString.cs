using System;
using System.Text;

//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();

        for (int i = input.Length-1; i >=0; i--)
        {
            sb.Append(input[i]);
        }
        string output = sb.ToString();
        Console.WriteLine(output);

    }
}