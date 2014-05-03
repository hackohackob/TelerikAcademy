using System;

//Declare two string variables and assing them with the following value: The "use" of quotation causes difficulties.
//Do the above in two different ways.

class EscapingQuotes
{
    static void Main()
    {
        string firstQuote, secondQuote;                                     //Declaring two string variables
        firstQuote = "The \"use\" of quotation causes difficulties.";       //Escaping the quotes with \" 
        secondQuote = @"The ""use"" of quotation causes difficulties.";     //Escaping the quotes with @ at the start
        Console.WriteLine(firstQuote);                                      //Writing the first variable's value on the Console
        Console.WriteLine(secondQuote);                                     //Writing the second variable's value on the Console

    }
}

