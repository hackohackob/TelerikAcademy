using System;

class Program
{
    static string[] array = { "1", "2", "3","5","7","10" };
    static int n = 6;
    static void Main()
    {
        array = InsertAt(2, 4);
        PrintArray(array);
    }

    static string[] InsertAt(int index, int position)
    {
        string wordString = array[index];
        string[] array2 = new string[n];
        if (position > 0)
        {
            position -= 1;
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

    static void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}