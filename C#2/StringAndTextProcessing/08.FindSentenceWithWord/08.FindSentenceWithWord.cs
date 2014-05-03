using System;

class FindSentenceWithWord
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";

        string[] sentences = text.Split('.');
        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i]=sentences[i].Trim();
        }

        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i];

            string[] sentenceArray = sentence.Split(' ');
            for (int j = 0; j < sentenceArray.Length; j++)
            {
                if(sentenceArray[j]==word)
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}