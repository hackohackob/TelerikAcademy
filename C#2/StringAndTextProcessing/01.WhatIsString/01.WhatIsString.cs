using System;
using System.Threading;

//Describe the strings in C#. What is typical for the string data type? Describe the most important methods of the String class.

class WhatIsString
{
    static void Main()
    {
        string explanation = "The string in C# is refferential data type. It can hold any kind of symbols.You see it like a text, but actually it is char array. Tipycal for the string is that you cant change the array itself. If you want to change it you should make a new different array with teh desired changes and change the variable to point to the new char array in the memory. Most important methods of the string class are: \nInfexOf (which finds the index of desired letter ot word), \nLength (which gets the count of the characters in the string) \nPadLeft,PadRight \nRemove, Split, Substring";
        for (int i = 0; i < explanation.Length; i++)
        {
            Console.Write(explanation[i]);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }
}