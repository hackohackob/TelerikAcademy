using System;

//see requirements for this exercise in the video 
class PrintMatrix
{
    static void Main()
    {
        int n = 8;
        int[,] matrix1 = new int[n, n];
        int matrix1C=1;
        int[,] matrix2 = new int[n, n];
        int matrix2C=1;
        int[,] matrix3 = new int[n, n];
        int matrix3C=1;


        Console.WriteLine("Matrix 1:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix1[j, i] = matrix1C;
                matrix1C++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix1[i, j].ToString().PadRight(3));
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\n\n");
        Console.WriteLine("Matrix 2:");
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix2[j, i] = matrix2C;
                    matrix2C++;
                }
            }
            else
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    matrix2[j, i] = matrix2C;
                    matrix2C++;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix2[i, j].ToString().PadRight(3));
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\n\n");
        Console.WriteLine("Matrix 3:");
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j < n - i; j++)
            {
                matrix3[i + j, j] = matrix3C;
                matrix3C++;
            }

        }

        for (int i = n - 1; i >= 1; i--)
        {
            for (int j = 0; j < i; j++)
            {
                matrix3[j, j + n - i] = matrix3C;
                matrix3C++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix3[i, j].ToString().PadRight(3));
            }
            Console.WriteLine();
        }
    }
}