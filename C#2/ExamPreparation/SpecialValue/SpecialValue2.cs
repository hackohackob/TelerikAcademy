using System;
using System.Collections.Generic;

class SpecialValue
{
    static int[,] input()
    {
        int N = int.Parse(Console.ReadLine());
        int maxColumns = 0;
        int firstColumn = 0;
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
        int[,] table = new int[N, maxColumns];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < listIntArrays[i].Length; j++)
            {
                table[i, j] = int.Parse(listIntArrays[i][j]);
            }
        }
        return table;
    }
    static void Main()
    {
        int[,] table2 = input();
       
        
        

        
        //bool[,] usedTable = new bool[N, maxColumns];



        


        int row = 0;
        int column = 0;
        int number = 0;
        bool steppedOnUsed = false, steppedOnNegative = false;
        int length = 0;
        int result = 0;
        int maxResult = 0;

        for (int i = 0; i < firstColumn; i++)
        {
            for (int j= 0; j < usedTable.GetLength(0); j++)
            {
                for (int k = 0; k < usedTable.GetLength(1); k++)
                {
                    usedTable[j, k] = false;
                    
                }
                
            }
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