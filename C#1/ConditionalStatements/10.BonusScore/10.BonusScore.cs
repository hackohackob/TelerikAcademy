using System;
//Write a program that applies bonus scores to given scores in the range [1..9]. 
//The program reads a digit as an input. 
//If the digit is between 1 and 3, the program multiplies it by 10; 
//if it is between 4 and 6, multiplies it by 100; 
//if it is between 7 and 9, multiplies it by 1000. 
//If it is zero or if the value is not a digit, the program must report an error.
//Use a switch statement and at the end print the calculated new value in the console.
class BonusScore
{
    static void Main()
    {
        int number;
        Console.Write("Input a number:");
        if(int.TryParse(Console.ReadLine(),out number))
        {
            if(number>=1 && number<=3)                                              //Checks if the number is between 1 and 3
            {
                number = number * 10;
                Console.WriteLine("Your number with bonus score is: {0}",number);
            }
            else if (number >= 4 && number <= 6)                                    //Checks if the number is between 4 and 6
            {
                number = number * 100;
                Console.WriteLine("Your number with bonus score is: {0}", number);
            }
            else if (number >= 7 && number <= 9)                                    //Checks if the number is between 7 and 9
            {
                number = number * 1000;
                Console.WriteLine("Your number with bonus score is: {0}", number);
            }
            else                                                                    //If the input is a number and its not between 1 and 9, we report an error
            {
                Console.WriteLine("The number is not in the interval [0..9]");
            }
        }
        else                                                                        //If the input is not a number, we report an error
        {
            Console.WriteLine("The input is not a number");
        }
        
    }
}