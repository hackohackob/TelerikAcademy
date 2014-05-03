using System;

//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

class Encode
{
    static void Main()
    {
        string textToEncode = Console.ReadLine();
        string cipher = Console.ReadLine();

        int maxLetter = Math.Max(textToEncode.Length, cipher.Length);
        int indexText = 0;
        int indexCipher = 0;

        while(true)
        {
            Console.Write("{0}",(textToEncode[indexText]^cipher[indexCipher]));
            indexText++;
            indexCipher++;
            if(indexText==maxLetter || indexCipher==maxLetter)
            {
                break;
            }
            if(indexText==textToEncode.Length)
            {
                indexText = 0;
            }
            if(indexCipher==cipher.Length)
            {
                indexCipher = 0;
            }
        }
        Console.WriteLine();
    }
}