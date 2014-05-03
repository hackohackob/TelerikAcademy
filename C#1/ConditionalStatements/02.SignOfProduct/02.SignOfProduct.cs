using System;

//Write a program that shows the sign (+ or -) of the product of three numbers without calculating it
class SignOfProduct
{
    static void Main()
    {
        double first,second,third;
        Console.Write("Input the first number:");                       //We have 4 options. 1: One of the numbers is 0 
        first = double.Parse(Console.ReadLine());                          //2:One number is negative - the result is negative
        Console.Write("Input the second number:");                      //3:Two numbers are negative - the result is positive
        second = double.Parse(Console.ReadLine());                         //4:Three numbers are negative - the result is negative
        Console.Write("Input the third number:");                       //5:No numbers are negative - the result is positive
        third = double.Parse(Console.ReadLine());
        Console.WriteLine();
        if(first==0 || second==0 ||third==0 )                                   //Here we check for option 1
        {
            Console.WriteLine("One of the numbers is 0, the product is 0!");
        }
        else if(((first*second)<0 && third>0) || ((second*third)<0 && first>0)) //Here we check for option 2
        {
            Console.WriteLine("The sign is negative");
        }
        else if(first<0 && second<0 && third<0)                                 //Here we check for option 4
        {
            Console.WriteLine("The sign is negative");
        }
        else                                                                    //If the numbers are not like in options 1,2,4 they are positive
        {
            Console.WriteLine("The sign is positive");
        }
    }
}

