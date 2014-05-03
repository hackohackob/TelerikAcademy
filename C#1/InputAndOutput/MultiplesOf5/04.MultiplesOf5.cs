using System;

//Write a program that reads two positive integer numbers and prints how many numbers "p" exist between them such that the reminder of the division by 5 is 0(inclusive). Example: p(17,25) = 2

class MultiplesOf5
{
    static void Main()
    {
        int a, b,p=0;                         //Defininf a, b and p
        Console.Write("Input first number:"); //Inputting a and b
        a = int.Parse(Console.ReadLine());
        Console.Write("Input second number:");
        b = int.Parse(Console.ReadLine());

        for (int i = a; i <=b; i++)           //Using for operator to cycle trough all the number between number "a" and number "b" inclusive
        {
            if(i%5==0)                        //Checking if the current number can be devided by 5 and if it can, adding 1 to the variable "p"
            {
                p = p + 1;
            }
        }
        Console.WriteLine("There are {0} numbers that can be devided by 5, between the numbers {1} and {2}",p,a,b);
    }
}
