using System;
using System.Numerics;

//Write a program that calculates N!/K! for given N and K (1<K<N).
class DivisionFactorial
{
    static void Main()
    {
        Console.Write("Input K (K > 1):");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Input N (N > K)");
        int n = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        if (1 < k && k < n)
        {
            for (int i = k + 1; i <= n; i++)
            {
                result *= i;
            }
        }
        else
        {
            Console.WriteLine("Invalid numbers");
        }

        Console.WriteLine("N!/K! = {0}", result);
    }
}