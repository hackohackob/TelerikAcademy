using System;

//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
class ThirdBit
{
    static void Main()
    {
        int a,b = 8;
        Console.Write("Please input a number: ");   
        a = int.Parse(Console.ReadLine());          //Inputting a number from the console
        if ((a & b) == 0)                           //Applying binary "and" to the number and 8                                 Example:  106 - 0110 1010  
        {                                           //                                                                                    & 8 - 0000 1000
            Console.WriteLine("Third bit: 0");            //If the result is ==0, then third bit (counting from 0) is 0.        Result:         0000 1000 - !=0 bit3:1
        }
        else                                                                                                                  //Example:  166 - 1010 0110 
        {                                                                                                                     //          & 8 - 0000 1000
            Console.WriteLine("Third bit:1");            //If the result is !=0, then the third bit (counting from 0) is 1.     Result:         0000 0000 - ==0 bit3:0
        }
    }
}