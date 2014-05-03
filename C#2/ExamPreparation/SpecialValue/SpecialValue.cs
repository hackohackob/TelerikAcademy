using System;
using System.Collections.Generic;

class SpecialValue
{
     

    static void input(int[,] table,int firstColumn, int maxColumns)
    {
        int N = int.Parse(Console.ReadLine());
             List<string> listTableCols = new List<string>();
   List<string[]> listIntArrays = new List<string[]>();

        for (int i = 0; i < N; i++)
        {
            string numbersWhole = Console.ReadLine();
            listTableCols.Add(numbersWhole);

            string[] numbers = numbersWhole.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            listIntArrays.Add(numbers);
            if (i == 0)
            {
                firstColumn = numbers.Length;
            }
            if (numbers.Length > maxColumns)
            {
                maxColumns = numbers.Length;
            }
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < listIntArrays[i].Length; j++)
            {
                table[i, j] = int.Parse(listIntArrays[i][j]);
            }
        }

    }
    static void Main()
    {
        int firstColumn = 0;
        int maxColumns = 0;
        int[,] table = new int[N, maxColumns];
        

        

        
        bool[,] usedTable = new bool[N, maxColumns];


        input(table,firstColumn,maxColumns);
        

        //listTableCols = new List<string>();
        //listIntArrays = new List<string[]>();

        int row = 0;
        int column = 0;
        int number = 0;
        bool steppedOnUsed = false, steppedOnNegative = false;
        int length = 0;
        int result = 0;
        int maxResult = 0;

        for (int i = 0; i < firstColumn; i++)
        {
            usedTable = new bool[N, maxColumns];
            length = 0;
            result = 0;
            row = 0;
            column = i;
            steppedOnNegative = false;
            steppedOnUsed = false;

            while (!steppedOnUsed && !steppedOnNegative)
            {
                length++;
                number = table[row, column];
                if (usedTable[row, column])
                {
                    steppedOnUsed = true;
                }
                usedTable[row, column] = true;

                if (number < 0)
                {
                    steppedOnNegative = true;
                }
                else
                {
                    row++;
                    if (row > N - 1)
                    {
                        row = 0;
                    }
                    column = number;
                }
                result = length + Math.Abs(number);
            }

            result = length + Math.Abs(number);

            if (result > maxResult && !steppedOnUsed)
            {
                maxResult = result;
            }
        }

        Console.WriteLine(maxResult);
    }
}