using System;

class ConvertStringToUnicode
{
    static void Main()
    {
        string str = "Hi!";

        foreach (var symbol in str)
        {
            Console.WriteLine("\\u{0:X4}", (int)symbol);
        }
    }
}