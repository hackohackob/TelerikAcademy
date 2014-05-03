using System;
using System.IO;

//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

class InsertLineNumbers
{
    static void Main()
    {
        StreamReader input = new StreamReader("input.txt");
        StreamWriter output = new StreamWriter("output.txt");
        string line= "";
        int n = 1;
        using (input)
        {
            using (output)
            {
                while ((line=input.ReadLine()) != null)
                {
                    output.WriteLine(n + " " + line);
                    n++;
                }
            }
        }
    }
}