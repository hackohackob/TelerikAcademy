using System;
using System.Numerics;

class gag
{
    static void Main()
    {
        //string input = "!!!&*!";
        string input = Console.ReadLine();
        string digitBaseNine="";
        int index = 0;
        string checkedNumber = "";

        while(input.Length>0)
        {
            //Console.WriteLine("-----");
            checkedNumber += input[index];
            //Console.WriteLine(input.PadRight(10) +"input"  );
            //Console.WriteLine(checkedNumber.PadRight(10) + "checkedNumber");
            if(Convert(checkedNumber)!="nope")
            {
                digitBaseNine += Convert(checkedNumber);

                //Console.WriteLine(digitBaseNine.PadRight(5) + "convertedDigit");
                input = input.Remove(0, index + 1);
                checkedNumber = "";
                index = -1;
            }
            index++;
            //Console.WriteLine();
        }

        BigInteger digitDecimal = 0;
        for (int i = digitBaseNine.Length-1; i >=0; i--)
        {
            digitDecimal+=BigInteger.Parse(digitBaseNine[i].ToString())*(BigInteger)Math.Pow(9,digitBaseNine.Length-i-1);
        }
        Console.WriteLine(digitDecimal);
    }

    static string Convert(string gagNumber)
    {
        string result = "nope";
        switch(gagNumber)
        {
            case "-!": result = "0"; break;
            case "**": result = "1"; break;
            case "!!!": result = "2"; break;
            case "&&": result = "3"; break;
            case "&-": result = "4"; break;
            case "!-": result = "5"; break;
            case "*!!!": result = "6"; break;
            case "&*!": result = "7"; break;
            case "!!**!-": result = "8"; break;
        }
        return result;
    }
}