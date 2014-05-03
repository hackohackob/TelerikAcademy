using System;
using System.Net;

//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.

class DownloadAFile
{
    static void Main()
    {
        try
        {
            WebClient downloader = new WebClient();
            downloader.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "logo.jpg");
        }
        catch (WebException)
        {
            Console.Error.WriteLine("The address is invalid.");
        }

        catch (NotSupportedException)
        {
            Console.Error.WriteLine("The invoked method is not supported.");
        }

        finally
        {
            Console.WriteLine("Goodbye :]");
        }
    }
}