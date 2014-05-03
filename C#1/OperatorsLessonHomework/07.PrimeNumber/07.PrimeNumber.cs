using System;

//Write and expression that checks if given psitive integer number n (n<=100) is prime.

class PrimeNumber
{
    static void Main()
    {
        int a,br=0;
        Console.Write("Please input a number to check if it is prime:");
        a = int.Parse(Console.ReadLine());                  //Inputting number from the Console
        Console.Clear();                                    //Clearing the Console
        for (int i = 1; i <=a; i++)                         //Using a "for" operator, to generate every single number which is smaller ot equal to the checked number.
        {
            if (a % i == 0)                                 //If the checked number divides without remainder to the generated number, 1 is added to the variable "br" 
            {                                               
                br++;
            }
            
        }                                                   //The variable "br" represents the number of the divisors that checked number have.
        if (br == 2)                                        //A prime number have only 2 divisors (1 and itself). Now we check if "br" ==2. If "br"==2 the number is prime.
        {
            Console.WriteLine("The number is prime.");
        }
        else                                                //If the number have more than 2 divisors, then the number is not prime.
        {
            Console.WriteLine("The number is not prime.");
        }
    }
}