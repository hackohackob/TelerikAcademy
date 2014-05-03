using System;
using System.IO;

//Write a program that concatenates two text files into another text file.


class JoinTwoTextFiles
{
    static void Main()
    {
        StreamReader reader1 = new StreamReader("test1.txt");
        StreamReader reader2 = new StreamReader("test2.txt");
        string joined = reader1.ReadToEnd() + " " + reader2.ReadToEnd();
        Console.WriteLine(joined);
    }
}