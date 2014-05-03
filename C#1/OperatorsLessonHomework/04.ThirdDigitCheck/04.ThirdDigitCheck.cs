using System;

//Write an expression that checks for given integer if its third digit (right to left) is 7.
class ThirdDigitCheck
{
    static void Main()
    {
        int a=898765;
        Console.WriteLine((a/100)%10==7); //Deviding the number by 100 to remove the last 2 digits. Example:               12345/100==123, 898765/100=8987. 
                                          //Then checking if the remainder after deviding that number by 10 is 7. Example: 123%10==3     , 8987%10==7.
    }
}
