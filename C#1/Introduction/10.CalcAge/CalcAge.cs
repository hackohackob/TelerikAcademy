using System;


class Age
{
    static void Main()
    {
        int age;

        Console.Write("Please input your age: ");
        age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Your age after 10 years: ");
        Console.WriteLine(age + 10);

    }
}

