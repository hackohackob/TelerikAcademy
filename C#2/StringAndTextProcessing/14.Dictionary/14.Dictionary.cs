using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {

        string dictionary = ".NET - platform for applications from Microsoft\n"
                               + "CLR - managed execution environment for .NET\n"
                                + "namespace - hierarchical organization of classes\n";

        string[] words = dictionary.Split('-', '\n');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Trim();
        }

        Console.WriteLine("Which word you are looking for?");
        string word = Console.ReadLine();
        for (int i = 0; i < words.Length - 1; i += 2)
        {
            if (word == words[i])
            {
                Console.WriteLine("The definition of \"{0}\" is:\n{1}", word, words[i + 1]);
                break;
            }
            else if (i == words.Length - 3)
            {
                Console.WriteLine("There is no such word!");
            }
        }

    }
}