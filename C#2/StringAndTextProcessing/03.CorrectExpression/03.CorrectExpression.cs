using System;

//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

class CorrectExpression
{
    static void Main()
    {
        string input = Console.ReadLine();

        int count = 0;
        bool correct = true;

        for (int i = 0; i < input.Length; i++)
        {
            if(input[i]=='(')
            {
                count++;
            }
            else if(input[i]==')')
            {
                count--;
            }
            if(count<0)
            {
                correct = false;
                break;
            }
            if (i == input.Length - 1 && count!=0)
            {
                correct = false;
                break;

            }
        }

        if(correct)
        {
            Console.WriteLine("The expression is correct");
        }
        else
        {
            Console.WriteLine("The expression is NOT correct");
        }
    }
}