using System;
using System.Collections.Generic;

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

class SieveOfEratosthenes
{
    static void Main()
    {
        List<int> list = new List<int>();
        int maxNumber = 10000000;
        DateTime first = DateTime.Now;
        for (int i = 0; i < maxNumber; i++)
        {
            list.Add(i + 1);
        }

        for (int i = 2; i < Math.Sqrt(list.Count); i++)
        {
            if (list[i-1] != 0)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] % i == 0)
                    {
                        list[j] = 0;
                    }
                }
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            if(list[i]!=0)
            {
            Console.WriteLine(list[i]+" ");
            }
        }
        DateTime second = DateTime.Now;
        Console.WriteLine("Time used: {0}",second-first);
    }
}