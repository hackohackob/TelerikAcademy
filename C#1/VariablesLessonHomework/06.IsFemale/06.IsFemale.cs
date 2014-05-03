using System;

//Declare a variable of type bool and assing it with appropriate value corresponding to your gender

class IsFemale
{
    static void Main()
    {
        bool isFemale;    //Declaring a bool variable
        isFemale = false; //Assinging the bool variable with false value, because I'm a man
        
        if (isFemale==true) //Checking if the value of the variable is true or false
        {
            Console.WriteLine("WOMAN");  //Writing "WOMAN" on the Console if the value is True
        }
        else
        {
            Console.WriteLine("MAN");    //Writing "MAN" on the Console if the value is false
        }
    }
}

