using System;

//Marketing firm wants to keep record of its employees. Choose appropriate type of variable for the following characteristics:
//first name, family name, age, gender(m or f), ID number, unique employee number(27560000 to 27569999)

class FirmEmployees

{
    static void Main()
    {
        string firstName = "Hacko";
        string lastName = "Hackob";
        byte age = 19;
        char gender = 'm';
        string idNumber = "123456789";   //second way: ulong idNumber="123456789";      There is no need for the ID Number and the Unique Employee Number to be saved
        string uEmplNumber = "27561234"; //second way: ulong uEmplNumber="27561234";    as number, because they take a lot of memery and they are used only as strings.
        Console.WriteLine("Number 1 employee of the month:");
        Console.WriteLine("Name: {0} {1} \nAge: {2} \nGender: {3} \nID Number: {4} \nuEmplNumber: {5}",firstName,lastName,age,gender,idNumber,uEmplNumber);

    }
}

