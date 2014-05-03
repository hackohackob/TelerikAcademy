using System;

//Write a program that gets two numbers from the console and prints the greater of them. Don't use if statements.
class GreaterNumber
{
    static void Main()
    {
        int first, second;
        string str;
        Console.Write("Enter the first number:");
        first = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number:");
        second = int.Parse(Console.ReadLine());
        Console.WriteLine();

        str = (first>second) ? "The first number is bigger" : "The second number is bigger"; //If the statement (first>second) is true, the variable "str" will be assinged
        Console.WriteLine(str);                                                              //with "The first number is bigger". If the statement is not true then "str"
                                                                                             //will be assinged with "The second number is bigger". Then we print out "str"
    }
}
