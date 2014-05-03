using System;

//A company has name, adress, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a comapny and its manager and prints them on the console.
class Comapany
{
    static void Main()
    {
        string cName, cAdress, cPhone, cFax, cWeb, mFirstName, mLastname, mPhone;
        byte mAge;
        Console.Write("Input company's name:");
        cName = Console.ReadLine();
        Console.Write("Input company's adress:");
        cAdress = Console.ReadLine();
        Console.Write("Input company's Phone number:");                             //Most of the variables are string because they will take a lot of memory like numbers 
        cPhone = Console.ReadLine();                                                //and they dont need to be used like numbers
        Console.Write("Input company's Fax number:");
        cFax = Console.ReadLine();
        Console.Write("Input comapny's web site:");
        cWeb = Console.ReadLine();
        Console.Write("Input manager's first name:");
        mFirstName = Console.ReadLine();
        Console.Write("Input manager's last name:");
        mLastname = Console.ReadLine();
        Console.Write("Input manager's phone:");
        mPhone = Console.ReadLine();
        Console.Write("Input magaer's age:");
        mAge = byte.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Company information \nName:{0} \nAdress:{1} \nPhone:{2} \nFax:{3} \nWeb Site:{4} \nManager information \nFirst Name:{5} \nLast Name:{6} \nPhone{7} \nAge:{8}",cName,cAdress,cPhone,cFax,cWeb,mFirstName,mLastname,mPhone,mAge);
    }
}
