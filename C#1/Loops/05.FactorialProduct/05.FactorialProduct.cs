using System;
using System.Numerics;

//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
//N!*K! / (K-N)! = N! * K(K-1)(K-2)...(K-N+1)class ProductFactorial

class FactorialProduct
{
    static void Main()
    {
        Console.Write("Input N (N > 1):");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input K (K > N):");
        int k = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        if (1 < n && n < k)
        {
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            for (int i = k - n + 1; i <= k; i++)
            {
                result *= i;
            }
        }
        else
        {
            Console.WriteLine("Invalid Numbers");
        }

        Console.WriteLine("N!*K! / (K-N)! = {0}", result);
    }
}
