using System;

//Write an expression that checks if given integer is odd or even
class EvenOrOdd
{
    static void Main()
    {
        int a = 45;
        Console.WriteLine(a % 2 == 0 ? "Even" : "Odd"); //Checking if the number divided by 2 has a remainder or not. If the number have a remainder then
                                                        //the number is Odd. If the number have not a remainder then the number is even.
    }
}

