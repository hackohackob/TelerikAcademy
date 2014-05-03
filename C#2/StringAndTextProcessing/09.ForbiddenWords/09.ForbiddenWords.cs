using System;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        string sample = "Microsoft announced its next generation PHP compiler today." +
        "It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string forbiddenWords = "PHP, CLR, Microsoft";
        string[] words = forbiddenWords.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder sb = new StringBuilder();
        sb.Append(sample);

        for (int i = 0; i < words.Length; i++)
        {
            sb.Replace(words[i], new string('*', words[i].Length));
        }
        Console.WriteLine(sb.ToString());
    }
}