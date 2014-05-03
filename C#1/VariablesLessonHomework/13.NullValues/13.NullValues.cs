using System;

//Create a program that assings null values to an integer and a double variable.Try to print them out. Try to add some values and see the result.
class NullValues
{
    static void Main()
    {
        int? first  = null;                         //Assinging null values to integer and double variables
        double? second = null;
        Console.WriteLine(first+"\n"+second) ;      //Printing them out on the Console
        first = first + 5;                          //Adding 5 to the integer and 6.6 to the double variable
        second = second + 6.66;
        Console.WriteLine(first + "\n" + second);   //Printing out the result
    }
}

