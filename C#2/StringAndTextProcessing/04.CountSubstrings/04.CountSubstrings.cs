using System;

//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).

class CountSubstrings
{
    static void Main()
    {
        string substring = "in";
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        int index = 0;
        int count = 0;

        while (index !=-1)
        {
            index=text.IndexOf(substring, index);
            count++;
            if(index==-1)
            {
                break;
            }
            index += substring.Length;

        }
        Console.WriteLine(count);
    }
}