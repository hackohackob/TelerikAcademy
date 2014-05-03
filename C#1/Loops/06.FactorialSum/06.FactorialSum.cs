using System;
using System.Numerics;


//Write a program that, for a given two integer numbers N and X,
//calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

class FactorialSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());


        BigInteger xPowN = 1, factorial = 1, sum = 0;
        

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            xPowN *= x;
            sum += (factorial / xPowN);
        }

        Console.WriteLine(sum);
    }
}