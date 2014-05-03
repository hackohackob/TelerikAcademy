using System;

//We are given integer number n, value v (0 or 1) and a position p. 
//Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
class ChangingBitValue                                           //SEE EXAMPLES BELOW!!!
{                                                                //SEE EXAMPLES BELOW!!!
    static void Main()                                           
    {
        int n, v=2, p;                                                             //Declaring the variables we will need. Making v=2 so that we can enter the "while" operator
        Console.Write("Please input a number:");                                        //Inputting the number from the Console
        n = int.Parse(Console.ReadLine());
        Console.Write("Please input the position of the bit which will be changed:");   //Inputting the position of the bit we will change
        p = int.Parse(Console.ReadLine());
        while (v != 0 && v != 1)                                                        //Using while operator to make sure that v is exactly 0 or 1 and nothing else
        {
            Console.Write("Please input the value for the bit (0 or 1):");              //Inputting the value that we want for the bit
            v = int.Parse(Console.ReadLine());  
        }
        v=v<<p;                                                                         //Moving the one and only bit with a value of 1 to the desired position
        
        if(v==0)                                                                        //If the value that we want for the bit is 0, then we will have to make
        {                                                                               //a number which has bit values only 1 except the value of the bit we want to change
            v = 1;                                                                      //Making the value of the first bit of the value "v" to 1
            v = v << p;                                                                 //Moving the one and only bit with a value of 1 to the desired position
            v = ~v;                                                                     //Reversing the bit values. Making all ones to zeros and all zeros to ones
            n = (n & v);                                                                //Using binary "and" operator to make the bit of the desired position with value 0
            Console.WriteLine(n);                                                       //Writing out the new number to the console 
        }
        else
        {
            n = (n | v);                                                                //if the value that we want for the bit is 1 we use binary "or" operator 
            Console.WriteLine(n);                                                       //Writing out the new number 
        }
    }
}

//EXAMPLE 1: input number: n=123 - 0111 1011
//           position of the bit we want to change: p=2 (counting from 0)
//           the value of the bit we want: 1, v=1 - 0000 0001
//           Moving the only bit with value of 1 to the desired position:
//           v<<p (v<<2) = 0000 0100
//           Applying binary "or" operator to the number "n" and number "v"
//           0111 1011
//        |  0000 0100
//result:    0111 1111  - 127

//EXAMPLE 2: input number: n=123 - 0111 1011
//           position of the bit we want to change: p=4 (counting from 0)
//           the value of the bit we want: 0, v=0 - 0000 0000
//           making the value of first bit in v to 1: v=1 - 0000 0001
//           Moving the only bit with value of 1 to the desired position:
//           v<<p (v<<4) = 0001 0000
//           reversing the bit values by using the binary operator "~"
//           the new value of v is 1110 1111
//           Applying binary "and" operator to the number "n" and number "v"
//           0111 1011
//        &  1110 1111
//result:    0110 1011  - 107      