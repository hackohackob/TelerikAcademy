using System;

//Write a program that print the first 100 members of the sequence of Fibonacci: 0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,...
class FibonacciMembers
{
    static void Main()
    {
        ulong first, second, third;                 //Declaring 3 variables, so that we can split the Fibonacci members by groups of 3 numbers.
        first = 0;                                  //First 2 numbers are given
        second = 1;
        Console.Write("{0} \n{1}",first,second);    //We print them out

        for (int i = 1; i <=98; i=i+3)              //We should print 98 more numbers, because we have printed already the first two. i gets i+3, because we print 3 numbers
        {                                           //per one cycle of the "for" operator
            third = second + first;                 //Calculating the third number 
            first = second + third;                 //Calculating the first number in the next group of 3 numbers
            second = first + third;                 //Calculatung the second number in the next group of 3 members
            
            Console.Write("\n{0} \n{1} \n{2} ",third,first,second); //Printing out the third number from the previuos group of 3 members and the 
        }
        Console.WriteLine();
    }
}
