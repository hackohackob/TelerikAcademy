using System;

class HexadecimalToBinary
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();

        char[] hexNumberCharArray = hexNumber.ToCharArray();

        string[] hexNumberArray = new string[hexNumberCharArray.Length];

        for (int i = 0; i < hexNumberCharArray.Length; i++)
        {
            hexNumberArray[i] = hexNumberCharArray[i].ToString();
        }

        for (int i = 0; i < hexNumberArray.Length; i++)
        {
            hexNumberArray[i]=ConvertToBase2(hexNumberArray[i]);
        }

        for (int i = 0; i < hexNumberArray.Length; i++)
        {
            Console.Write(hexNumberArray[i]);
        }
        Console.WriteLine();
    }
    static string ConvertToBase2(string hexNumber)
    {
        switch(hexNumber)
        {
            case "A":
                hexNumber = "10"; break;
            case "B":
                hexNumber = "11"; break;
            case "C":
                hexNumber = "12"; break;
            case "D":
                hexNumber = "13"; break;
            case "E":
                hexNumber = "14"; break;
            case "F":
                hexNumber = "15"; break;
        }
        int intHexNumber = int.Parse(hexNumber);

        string reversedBinary = "";
        while (intHexNumber > 0)
        {
            reversedBinary += intHexNumber % 2;
            intHexNumber = intHexNumber / 2;
        }

        char[] reversedBinaryArray = reversedBinary.ToCharArray();
        Array.Reverse(reversedBinaryArray);
        string binaryNumber = "";
        for (int i = 0; i < reversedBinaryArray.Length; i++)
        {
            binaryNumber += reversedBinaryArray[i];
        }

        return binaryNumber;
    }
}