using System;

//We are given a matrix of strings of size NxM. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix. 

class LongestEqualSequence
{
    static void Main()
    {
        string[,] matrix = { { "ha", "ho", "ho", "ho" , "i", "i", "i", "i", "i", "ho"}, 
                             { "ha", "ha", "ho", "xx" , "ho", "ho", "hi", "ho", "hi", "ho"}, 
                             { "hi", "ho", "ha", "xx" , "ha", "xx", "ha", "ho", "ha", "xx"},
                             { "ha", "ha", "hi", "ha", "ha", "xx", "ho", "xx", "ha", "xx"}};

        int currentSequence = 0;
        int max = 0;
        string typeMax="";
        int imax = 0;
        int jmax = 0;

        //horizontal search
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            currentSequence = 0;
            for (int j = 0; j < matrix.GetLength(1)-1; j++)
            {
                if(matrix[i,j]==matrix[i,j+1])
                {
                    currentSequence++;
                    if (currentSequence > max)
                    {
                        max = currentSequence;
                        typeMax = "horizontal";
                        imax = i;
                        jmax = j;
                    }
                }
                else
                {
                    currentSequence = 0;
                }
               

            }
        }

        //vertial search
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            currentSequence = 0;
            for (int j = 0; j < matrix.GetLength(0)-1; j++)
            {
                if (matrix[j,i] == matrix[j+1,i])
                {
                    currentSequence++;
                    if (currentSequence > max)
                    {
                        max = currentSequence;
                        typeMax = "vertical";
                        imax = i;
                        jmax = j;
                    }
                }
                else
                {
                    currentSequence = 0;
                }


            }
        }


        //diagonal search (diagonal from upleft to down right)
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            currentSequence = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                int i1 = i, j1 = j;
                currentSequence = 0;

                while(i1<matrix.GetLength(0)-1 && j1<matrix.GetLength(1)-1)
                {
                    if(matrix[i1,j1]==matrix[i1+1,j1+1])
                    {
                        currentSequence++;
                        if (currentSequence > max)
                        {
                            max = currentSequence;
                            typeMax = "diagonal";
                            imax = i;
                            jmax = j;
                        }
                    }
                    else
                    {
                        currentSequence = 0;

                    }
                    i1++;
                    j1++;
                }
            }
        }

        //diagonal search (diagonal from up right to down left )
        for (int i = 0; i < matrix.GetLength(0)-1; i++)
        {
            currentSequence = 0;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                int i1 = i, j1 = j;
                currentSequence = 0;

                while (i1 <matrix.GetLength(0)-1 && j1 >0)
                {
                    if (matrix[i1, j1] == matrix[i1 + 1, j1 - 1])
                    {
                        currentSequence++;
                        if (currentSequence > max)
                        {
                            max = currentSequence;
                            typeMax = "diagonal";
                            imax = i;
                            jmax = j;
                        }
                    }
                    else
                    {
                        currentSequence = 0;

                    }
                    i1++;
                    j1--;
                }
            }
        }

        for (int i = 0; i <=max; i++)
        {
            Console.Write(matrix[imax,jmax]+" ");
        }
        Console.WriteLine();
        //Console.WriteLine("The maximum sequence is: {0}",typeMax);
    }
}