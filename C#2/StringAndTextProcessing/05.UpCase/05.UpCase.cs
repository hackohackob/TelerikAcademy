using System;
//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 
class UpCase
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> <upcase>e</upcase>lse.";

        int index = 0;
        int lastIndex = 0;

        while(true)
        {
            index = text.IndexOf("<upcase>");
            if(index==-1)
            {
                break;
            }
            lastIndex = text.IndexOf("</upcase>");
            string toMakeBigger = "";
            for (int i = index+8; i < lastIndex; i++)
            {
                toMakeBigger += text[i];

            }
            toMakeBigger = toMakeBigger.ToUpper();
            text=text.Remove(index, 17+toMakeBigger.Length);
            text = text.Insert(index, toMakeBigger);
        }
        Console.WriteLine(text);

    }
}