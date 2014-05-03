using System;

//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
//string = "43 68 9 23 318"  result = 461

class SumIntegersFromString
{
    static void Main()
    {
        Console.Write("Input string a positive integers separated by spaces:");
        string stringInts = Console.ReadLine();
        string[] stringArray = stringInts.Split(' ');
        int sum = 0;

        for (int i = 0; i < stringArray.Length; i++)
        {

            sum += int.Parse(stringArray[i]);
        }
        Console.WriteLine(sum);
    }
}