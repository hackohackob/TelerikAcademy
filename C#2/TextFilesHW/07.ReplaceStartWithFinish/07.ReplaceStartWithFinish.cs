using System;
using System.IO;

//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

class ReplaceStartWithFinish
{
    static void Main()
    {
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter output = new StreamWriter("output.txt");
        string line;

        using (reader)
        {
            using (output)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] array = line.Split(' ');
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].Contains("start"))
                        {
                            array[i]=array[i].Replace("start", "finish");
                        }
                    }
                    string output2 = "";
                    for (int i = 0; i < array.Length; i++)
                    {
                        output2 = output2 + array[i] + " ";
                    }
                    output.WriteLine(output2);
                }
            }
        }
    }
}