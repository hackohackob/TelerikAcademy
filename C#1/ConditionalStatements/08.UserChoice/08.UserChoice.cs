using System;
//Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.
class UserChoice
{
    static void Main()
    {
        byte choice;
        Console.Write("Input type of variable 1-int 2-double 3-string:");
        choice = byte.Parse(Console.ReadLine());
        switch(choice)
        {

            case 1:
                {
                    int temp;
                    Console.Write("Input integer:");
                    temp = int.Parse(Console.ReadLine());
                    temp = temp + 1;
                    Console.WriteLine("Your integer number +1 = {0}", temp); break;
                }
            case 2:
                {
                    double temp;
                    Console.Write("Input double:");
                    temp = double.Parse(Console.ReadLine());
                    temp = temp + 1;
                    Console.WriteLine("Your integer number +1 = {0:0.00}", temp); break;
                }
            case 3:
                {
                    string temp;
                    Console.Write("Input string:");
                    temp = Console.ReadLine();
                    temp = temp + "*";
                    Console.WriteLine("Your integer number +\"*\" = {0}", temp); break;
                }
                
        }

        
        
        
    }
}