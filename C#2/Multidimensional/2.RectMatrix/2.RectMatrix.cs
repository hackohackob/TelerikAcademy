using System;

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

class RectMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int maxsum = int.MinValue;
        int currentsum = 0;
        int maxi = 0, maxj = 0;
        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 1; i < n-1; i++)
        {
            for (int j = 1; j < m-1; j++)
            {
                currentsum = 0;

                for (int h = i-1; h <=i+1; h++)
                {
                    for (int k = j-1; k < j+1; k++)
                    {
                        currentsum = currentsum + matrix[h, k];
                    }
                }
                if(currentsum>maxsum)
                {
                    maxsum = currentsum;
                    maxi = i;
                    maxj = j;
                }

            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i,j].ToString().PadRight(3));
            }
            Console.WriteLine();
        }
        Console.WriteLine("Maxsum:{0}",maxsum);
        Console.WriteLine("Maxsum square index i:{0}",maxi);
        Console.WriteLine("Maxsum square index j:{0}", maxj);
    }
}