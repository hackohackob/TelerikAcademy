using System;

class ExchangingValues
{
    static void Main()
    {
        int a = 5;                      //Declaring two variables
        int b = 3;
        int temp;                       //Declaring a third variables to temporary store one of the values
                                        //                                      a=5 b=3 temp=0
        Console.WriteLine(a + " " + b); //Writing the values of the two variables on the Console
        temp = a;                       //Assinging value of "a" to "temp"      a=5 b=3 temp=5
        a = b;                          //Assinging value of "b" to "a"         a=3 b=3 temp=5
        b = temp;                       //Assinging value of "temp" to "b"      a=3 b=5 temp=5
        Console.WriteLine(a + " " + b); //Writing the values of the two variables on the Console
    }
}
