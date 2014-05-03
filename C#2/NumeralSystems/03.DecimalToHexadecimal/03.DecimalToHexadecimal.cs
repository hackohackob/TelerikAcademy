using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Input decimal number:");
        int decimalInt = int.Parse(Console.ReadLine()) ;
        string reversedHex = "";
        while(decimalInt>0)
        {
            reversedHex = reversedHex + decimalInt % 16 + " ";
            decimalInt = decimalInt / 16;
        }

        reversedHex= reversedHex.Remove(reversedHex.Length - 1);

        string[] hexArray = reversedHex.Split(' ');
        Array.Reverse(hexArray);
        for (int i = 0; i < hexArray.Length; i++)
        {
            switch(hexArray[i])
            {
                case "10":
                    hexArray[i] = "A";
                    break;
                case "11":
                    hexArray[i] = "B";
                    break;
                case "12":
                    hexArray[i] = "C";
                    break;
                case "13":
                    hexArray[i] = "D";
                    break;
                case "14":
                    hexArray[i] = "E";
                    break;
                case "15":
                    hexArray[i] = "F";
                    break;
            }
        }
        for (int i = 0; i < hexArray.Length; i++)
        {
            Console.Write(hexArray[i]);
        }
        Console.WriteLine();
    }
}