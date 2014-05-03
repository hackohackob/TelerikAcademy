using System;
//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. using System;

class VariationsClass
{
    static int n = int.Parse(Console.ReadLine());
    static int k = int.Parse(Console.ReadLine());

    public static void Main()
    {


        int[] var = new int[k];
        Variations(var, 0);
    }

    public static void Variations(int[] array, int index)
    {
        if (index == array.Length)
        {
            Print(array);
        }
        else
            for (int i = 1; i <= n; i++)
            {
                array[index] = i;
                Variations(array, index + 1);
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