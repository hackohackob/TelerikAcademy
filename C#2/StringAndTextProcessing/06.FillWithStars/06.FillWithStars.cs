using System;
using System.Text;

//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

class FillWithStars
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        sb.Append(input);
        if(input.Length<20)
        {
            for (int i = input.Length; i <20; i++)
            {
                sb.Append('*');
            }
        }
        string output = sb.ToString();
        Console.WriteLine(output);
    }
}