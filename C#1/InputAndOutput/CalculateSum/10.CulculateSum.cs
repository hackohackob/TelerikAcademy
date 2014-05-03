using System;

//Write a program to calculate the sum (with accuracy of 0.001): 1+1/2-1/3+1/4-1/5
class CalculateSum
{
    static void Main()
    {
        double sum = 1;

        for (int i = 2; i <1000; i++)                  //The sum needs to be with accuracy  of 0.001, so the last digit we will add to the sum is 1/1000
        {                                              
            sum = sum + 1.0 / i;
            i = i + 1;
            sum = sum - 1.0 / i;
        }
        Console.WriteLine("The sum is:{0:0.000}",sum);  //Then we print out the sum using string formatting
    }
}
