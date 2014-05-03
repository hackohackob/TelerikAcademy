using System;


//Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum.
class SumOfNumbers
{
    static void Main()
    {
        int n,a, sum = 0;
        Console.Write("Please input hwo many numbers you want to sum: ");   //Inputing how many numbers will be calculated
        n = int.Parse(Console.ReadLine());

        for (int i = 1; i <=n; i++)                                         //Using a for operator to request inputing a number and adding it to the sum- n times
        {
            Console.Write("Input the {0} number: ", i);
            a = int.Parse(Console.ReadLine());                              //Reading the number    
            sum = sum + a;                                                  //Adding it to the sum
        }
                                        
        Console.WriteLine("The sum of the numbers is: {0}",sum);            //Printing out the sum

    }
}
