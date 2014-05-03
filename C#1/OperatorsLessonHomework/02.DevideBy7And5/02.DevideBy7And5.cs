using System;

//Write a boolean expression that checks for given integer if it can be devided (without remainder) by 7 and 5 in the same time
class DevideBy7And5
{
    static void Main()
    {
        int a = 35;
        if (a%7==0 && a%5==0)                                                               //Checking if the remainders are 0, after deviding the number by 7 and 5 
        {
            Console.WriteLine("The number CAN be devided by 7 and 5 without remainder");
        }
        else
        {
            Console.WriteLine("The number CAN'T be devided by 7 and 5 without remainder");
        }
    }
}