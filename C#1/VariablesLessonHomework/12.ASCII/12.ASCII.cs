using System;

//Write a program that prints the ASCII table
class ASCII
{
    static void Main()
    {
        for (int i = 1; i <=255; i++)                       //using "for" operator to go trough all the symbols
        {
            if (i>6&&i<11)                                  //using "if" operator to exclude symbols 7 to 10, because they do not have letter representation
            {
                Console.WriteLine("{0}: ",i);               //writing only the number for symbols 7 to 10
            }
            else
            {
                Console.WriteLine("{0}: {1}", i, (char)i);  //writing the number and the symbol for the rest of the symbols
            }
        }

    }
}

