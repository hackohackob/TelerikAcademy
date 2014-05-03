using System;

//Write a program to convert hexadecimal numbers to their decimal representation.

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Input hexadecimal number:");
        string hexNumber = Console.ReadLine(); ;
        char[] hexNumberCharArray = hexNumber.ToCharArray();
        string[] hexNumberArray = new string[hexNumberCharArray.Length];
        for (int i = 0; i < hexNumberCharArray.Length; i++)
        {
            hexNumberArray[i] = hexNumberCharArray[i].ToString();
        }

        for (int i = 0; i < hexNumberArray.Length; i++)
        {
            switch (hexNumberArray[i])
            {
                case "A":
                    hexNumberArray[i] = "10";
                    break;
                case "B":
                    hexNumberArray[i] = "11";
                    break;
                case "C":
                    hexNumberArray[i] = "12";
                    break;
                case "D":
                    hexNumberArray[i] = "13";
                    break;
                case "E":
                    hexNumberArray[i] = "14";
                    break;
                case "F":
                    hexNumberArray[i] = "15";
                    break;
            }
        }

        int decimalNumber = 0;

        for (int i = 0; i < hexNumberArray.Length; i++)
        {
            decimalNumber = decimalNumber + int.Parse(hexNumberArray[i]) * stepen(16, hexNumberArray.Length - i - 1);

        }
        Console.WriteLine(decimalNumber);

    }

    static int stepen(int number, int power)
    {
        int returnedNumber = number;
        if (power == 0)
        {
            return 1;
        }
        for (int i = 0; i < power - 1; i++)
        {
            returnedNumber = returnedNumber * number;
        }
        return returnedNumber;
    }
}