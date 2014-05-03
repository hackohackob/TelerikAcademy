using System;

class BaseSToBaseD
{
    static void Main()
    {
        Console.Write("Input first number:");
        string firstNumber = Console.ReadLine();
        Console.Write("Input the base of the number:");
        int firstBase = int.Parse(Console.ReadLine());

        Console.Write("Input the base to convert to:");
        int secondBase = int.Parse(Console.ReadLine());

        char[] firstNumberCharArray = firstNumber.ToCharArray();
        string[] firstNumberArray = new string[firstNumberCharArray.Length];

        for (int i = 0; i < firstNumberCharArray.Length; i++)
        {
            firstNumberArray[i] = firstNumberCharArray[i].ToString();
        }

        for (int i = 0; i < firstNumberArray.Length; i++)
        {
            switch (firstNumberArray[i])
            {
                case "A":
                    firstNumberArray[i] = "10"; break;
                case "B":
                    firstNumberArray[i] = "11"; break;
                case "C":
                    firstNumberArray[i] = "12"; break;
                case "D":
                    firstNumberArray[i] = "13"; break;
                case "E":
                    firstNumberArray[i] = "14"; break;
                case "F":
                    firstNumberArray[i] = "15"; break;
            }
        }

        int resultNumber = new int();

        for (int i = 0; i < firstNumberArray.Length; i++)
        {
            resultNumber = resultNumber + int.Parse(firstNumberArray[i]) * stepen(firstBase, firstNumberArray.Length - i - 1);
        }

        Console.WriteLine(resultNumber);


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