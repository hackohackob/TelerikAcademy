using System;

//Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

class LettersIndexes
{
    static void Main()
    {
        char[] array = new char[26];        //defining the array

        for (int i = 0; i < array.Length; i++) //filling the array with the letters
        {
            array[i] = (char)('a' + i);
        }

        Console.Write("Input a word:");     //inputting a word and converting it to lower case
        string word = Console.ReadLine();
        word = word.ToLower();

        for (int i = 0; i < word.Length; i++) //for each of the letters of the word, printing the difference between the letter and the char 'a'
        {
            Console.WriteLine("{0} index:{1}",word[i],word[i]-'a');
        }
    }
}