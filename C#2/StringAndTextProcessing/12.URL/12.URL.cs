using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class URL
{
    public static void ExtractURL(string url)
    {
        int index = 0;
        index = url.IndexOf(':');
        Console.WriteLine("[protocol] = \"{0}\"", url.Substring(0, index));
        url = url.Replace(url.Substring(0, index + 3), "");

        index = url.IndexOf('/');
        Console.WriteLine("[server] = \"{0}\"", url.Substring(0, index));
        url = url.Replace(url.Substring(0, index), "");

        Console.WriteLine("[resource] = \"{0}\"", url);

    }

    static void Main()
    {
        string url = @"https://telerikacademy.com/Courses/Courses/Details/151";
        ExtractURL(url);
    }
}