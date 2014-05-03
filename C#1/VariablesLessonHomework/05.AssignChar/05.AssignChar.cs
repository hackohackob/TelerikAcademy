using System;

//Declare a character variable and assign it with the symbol that has Unicode code 72
//Hint:First use the Windows Calculator to find the hexadecimal representation of 72
class AssignChar
{
    static void Main()
    {                              //72 Dec = 48 Hex
        char letter = (char)0x48;  //Using the Hex representation of 72 to assing the 72nd character to the variable "letter"
        Console.WriteLine(letter); //Writing the value of the variable on the Console
    }
}

