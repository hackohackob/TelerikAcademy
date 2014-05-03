using System;

//Write a program that prints a isoscale triangle of 9 copyright symbols
//NOTE THAT YOU MIGHT SEE THE LETTER AS NORMAL "C" 
class CopyrightTriangle
{
    static void Main()
    {
        char c='\u00A9';
        int cursorPosY = 0;                                                 //Declaring two variables to specify the position x and y of the cursor 
        int cursorPosX = 2;


        for (int i= 1; i <=5; i=i+2)                                        //"for" operator for counting and going trough the rows
        {
            for (int j = 1; j <= i; j=j+1)                                  //"for" operator for printing all the symbols on 1 row
            {
                if (j==1)                                                   // checking if the program is going to type the first symbol for the row 
                {
                    Console.SetCursorPosition(cursorPosX,cursorPosY);       //using SetCursorPosition to specify the position of the first symbol in every row
                    Console.Write(c);                                       //writing the first symbol on the desired place
                }
                else
                {
                    Console.Write(c);                                       //writing remaining symbols
                }
            }
            cursorPosY = cursorPosY + 1;                                    //moving on to the next row 
            cursorPosX = cursorPosX - 1; 
        }
        Console.WriteLine();                                                //Leaving two empty rows
        Console.WriteLine();
    }
}

