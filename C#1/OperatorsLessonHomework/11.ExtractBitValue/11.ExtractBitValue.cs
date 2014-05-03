using System;

//Write an expression that extracts from a given integer i the value of a given bit number b.
class ExtractBitValue
{
    static void Main()
    {
        int i, b, v = 1;                                        //Declaring all the variables we need and a varibale "v" to help us calculate the bit number
        Console.Write("Please input the number:");              //Inputting the number from the Console
        i = int.Parse(Console.ReadLine());
        Console.Write("Please input the position of the bit:"); //Inputting the position from the Console
        b = int.Parse(Console.ReadLine());
        Console.Clear();                                        //Clearing the Console
        v = v << b;                                             //Moving the one and only bit with number 1 on our variable "v" to the position of the bit 
                                                                //which we will check.   

        if ((i & v) != 0)                                                   //Applying the binary operator "and" and if the result is !=0 then the bit in the position "p" is 1
        {                                                                   //if the result is ==0, then the bit on position p is 0.
            Console.WriteLine("The bit on position {0} have number 1", b);  //Writing on the Console if the bit is 0 or 1
        }
        else
        {
            Console.WriteLine("The bit on position {0} have number 0",b);
        }
            
    }                                                           
}                                                               
                                                                
                                                                