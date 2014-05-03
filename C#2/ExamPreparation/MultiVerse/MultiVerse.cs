using System;
class MultiVerse
{
    static void Main()
    {
        string wholeNumber = Console.ReadLine();

        int countNumbers = wholeNumber.Length / 3;
        string[] arrayOfLetters = new string[countNumbers];
        for (int i = 0; i < wholeNumber.Length; i++)
        {
            arrayOfLetters[i / 3] += wholeNumber[i].ToString();
        }

        for (int i = 0; i < arrayOfLetters.Length; i++)
        {
            switch (arrayOfLetters[i])
            {
                case "CHU": arrayOfLetters[i] = "0"; break;
                case "TEL": arrayOfLetters[i] = "1"; break;
                case "OFT": arrayOfLetters[i] = "2"; break;
                case "IVA": arrayOfLetters[i] = "3"; break;
                case "EMY": arrayOfLetters[i] = "4"; break;
                case "VNB": arrayOfLetters[i] = "5"; break;
                case "POQ": arrayOfLetters[i] = "6"; break;
                case "ERI": arrayOfLetters[i] = "7"; break;
                case "CAD": arrayOfLetters[i] = "8"; break;
                case "K-A": arrayOfLetters[i] = "9"; break;
                case "IIA": arrayOfLetters[i] = "10"; break;
                case "YLO": arrayOfLetters[i] = "11"; break;
                case "PLA": arrayOfLetters[i] = "12"; break;
            }
        }

        long sum = 0;
        for (int i = arrayOfLetters.Length - 1; i >= 0; i--)
        {

            sum = sum + (long)(long.Parse(arrayOfLetters[i]) * (Math.Pow(13, arrayOfLetters.Length - i - 1)));
        }
        Console.WriteLine(sum);
    }


}