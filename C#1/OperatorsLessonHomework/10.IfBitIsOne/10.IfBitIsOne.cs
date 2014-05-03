using System;

//Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has a value of 1. 
class IfBitIsOne
{
    static void Main()
    {
        int a, v=1, p;                                              //Declaring all the variables we need and a varibale "v" to help us calculate the bit number
        Console.Write("Please insert the number:");                 //Inputting the number from the Console
        a = int.Parse(Console.ReadLine());
        Console.Write("Please insert the position of the bit:");    //Inputting the position from the Console
        p = int.Parse(Console.ReadLine());
        Console.Clear();                                            //Clearing the Console
        v = v << p;                                                 //Moving the one and only bit with number 1 on our variable "v" to the position of the bit 
                                                                    //which we will check.
        if((a&v)!=0)                                                //Applying the binary operator "and" and if the result is !=0 then the bit in the position "p" is 1
        {                                                           //if the result is ==0, then the bit on position p is 0.
            Console.WriteLine("The bit on position {0} is 1",p);    //Writing on the Console if the bit is 0 or 1
        }
        else
        {
            Console.WriteLine("The bit on position {0} is 0",p);
        }

        Console.WriteLine((a&v)!=0);                                //Writing it on the Console like a boolean expression
    }
}