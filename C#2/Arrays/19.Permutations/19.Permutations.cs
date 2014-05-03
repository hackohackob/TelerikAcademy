using System;

//Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
class Permutations
{
    static int n = int.Parse(Console.ReadLine());
    static int k = n;

    public static void Main()
    {


        int[] var = new int[k];
        PermutateIt(var, 0);
    }

    public static void PermutateIt(int[] array, int index)
    {
        if (index == array.Length)
        {
            Print(array);
        }
        else
            for (int i = 1; i <= n; i++)
            {
                bool noseen = true;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] == i && index != 0)
                    {
                        noseen = false;
                    }
                }
                if (noseen)
                {
                    array[index] = i;
                    PermutateIt(array, index + 1);
                }
            }
    }

    public static void Print(int[] array)
    {
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            if (i < array.Length - 1)
            {
                Console.Write(array[i] + ",");
            }
            else
            {
                Console.Write(array[i] + "}");
            }
        }
        Console.WriteLine();
    }
}