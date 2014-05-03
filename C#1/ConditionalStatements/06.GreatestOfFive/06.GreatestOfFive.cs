using System;
//Write a program that finds the greatest of given 5 variables.

class GreatestOfFive
{
    static void Main()
    {
        int biggest=0,temp;
        for (int i = 1; i <=5; i++)
        {
            Console.Write("Input {0} number:",i);
            temp = int.Parse(Console.ReadLine());
            if (temp>biggest)
            {
                biggest = temp;
            }
        }
        Console.WriteLine("The biggest number is:{0}",biggest);
    }
}