using System;

//Write a program that reads 3 integer numbers from the console and prints their sum
class ThreeIntegers
{
    static void Main()
    {
        int num, sum=0;                             

        for (int i = 0; i < 3; i++)                     //Using for operator to do the following operations 3 times: reading a number and adding it to the sum
        {
            Console.Write("Input {0} number:",i+1);
            num = int.Parse(Console.ReadLine());
            sum = sum + num;
        }
        Console.WriteLine("The sum of the integers is:{0}",sum);       //Printing out the sum
    }
}
