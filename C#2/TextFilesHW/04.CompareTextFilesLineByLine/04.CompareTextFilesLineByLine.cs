using System;
using System.IO;

//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.

class CompareTextFilesLineByLine
{
    static void Main()
    {
        StreamReader input1 = new StreamReader("input1.txt");
        StreamReader input2 = new StreamReader("input2.txt");
        string line1;
        string line2;
        int counterSame=0,counterDifferent=0;
        while((line1=input1.ReadLine())!=null)
        {
            line2=input2.ReadLine();
            if(line1==line2)
            {
                counterSame++;
            }
            else
            {
                counterDifferent++;
            }
        }
        Console.WriteLine("Lines that are the same: {0} \nLines that are different: {1}",counterSame,counterDifferent);
    }
}