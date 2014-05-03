using System;

//Declare two string variables and assing them with "Hello" and "World"
//Declare an object variable and assing it with the concatenation of the two strings
//Declare a third string variable and assing it with the object value

class StringToObjectToString
{
    static void Main()
    {
        string firstName, secondName;                   //Declaring two string variables
        object firstAndSecond;                          //Declaring an object variable
        firstName = "Hello";                            //Assinging the first variable with the value "Hello"
        secondName = "World";                           //Assinging the second variable with the value "World"
        firstAndSecond = firstName + " " + secondName;  //Assinging the object variable with the value of the two string variables, separeted by space
        string twoNames;                                //Declaring a third string variable
        twoNames = (string)firstAndSecond;              //Assinging the third string variable with the object's value by casting the object to string
        Console.WriteLine(twoNames);                    //Writing the third string variable's value on the Console
    }
}

