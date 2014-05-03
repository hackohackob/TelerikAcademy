using System;

class MagicWords
{
    static int n;
    static string[] array;
    static void Main()
    {
        Inputting();
        Reorder();
        Print();
    }

    static void Reorder()
    {
        string whole = string.Empty;

        for (int i = 0; i < array.Length; i++)
        {
            whole += array[i];
        }

        string[] newString = new string[n];
        for (int i = 0; i < array.Length; i++)
        {
            int newPosition = array[i].Length % (n + 1);

            //Console.WriteLine("insert i:{0}:{1} at {2}",i,array[i],newPosition);
            array = InsertAt(i, newPosition);
            //PrintArray(array);
        }
        //Console.WriteLine(whole);

    }

    static void Print()
    {
        int maxLength = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i].Length>maxLength)
            {
                maxLength = array[i].Length;
            }
        }

        int k = 0;
        for (int m = 0; m < maxLength; m++)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > k )
                {
                    Console.Write(array[i][k]);

                }
            }
            k++;
        }
        Console.WriteLine();
    }

    static string[] InsertAt(int index, int position)
    {
        string wordString = array[index];
        string[] array2 = new string[n];
        if (position > 0)
        {
            //position -= 1;
        }
        array2[position] = wordString;
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    if (array2[j] == null)
                    {
                        array2[j] = array[i];
                        break;
                    }
                }
            }

        }
        return array2;
    }
    static void Inputting()
    {
        n = int.Parse(Console.ReadLine());
        
        array = new string[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = Console.ReadLine();
        }

    }

    
}