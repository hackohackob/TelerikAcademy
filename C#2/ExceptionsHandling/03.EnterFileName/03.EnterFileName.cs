using System;

//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Security;

class EnterFileName
{
    static void Main()
    {
        try
        {
            Console.Write("Please enter the file path:");
            string filePath = Console.ReadLine();
            Console.WriteLine(File.ReadAllText(@filePath));
        }

        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("I'm sorry to inform you that the path is null.");
        }

        catch (ArgumentException)
        {
            Console.Error.WriteLine("Please make sure that the path length is not zero or empty space or it has invalid characters");
        }

        catch (PathTooLongException)
        {
            Console.Error.WriteLine("I'm sorry to inform you that the path lenght is too long");
        }

        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Plase make sure the path is valid");
        }

        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("I'm sorry, but there isn't such file in that path");
        }

        catch (IOException)
        {
            Console.Error.WriteLine("An I/O error occured");
        }

        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("Sorry, but you dont have the permissions to open this file");
        }

        catch (NotSupportedException)
        {
            Console.Error.WriteLine("Please make sure the path is valid");
        }

        catch (SecurityException)
        {
            Console.Error.WriteLine("Sorry, but you dont have the permissions to open this file");
        }
    }
}