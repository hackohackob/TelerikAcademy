using System;

//Write a program that converts a number in the range [0...999] 
//to a text corresponding to its English pronunciation. 
class NumberToText
{
    static void Main()
    {
        int number;
        Console.Write("Input a number between 1 and 999:");
        number = int.Parse(Console.ReadLine());

        if(number>0 && number<1000)
        {
            int ones = number % 10;
            number = number / 10;
            int tens = number % 10;
            number = number / 10;
            int hundreds = number % 10;

            switch (hundreds)
            {
                case 1: Console.Write("one hundred "); break;
                case 2: Console.Write("two hundred "); break;
                case 3: Console.Write("three hundred "); break;
                case 4: Console.Write("four hundred "); break;
                case 5: Console.Write("five hundred "); break;
                case 6: Console.Write("six hundred "); break;
                case 7: Console.Write("seven hundred "); break;
                case 8: Console.Write("eight hundred "); break;
                case 9: Console.Write("nine hundred "); break;
                case 0: break;
            }

            if (hundreds != 0)
            {
                Console.Write("and ");
            }

            switch (tens)
            {
                case 2: Console.Write("twenty "); break;
                case 3: Console.Write("thirty "); break;
                case 4: Console.Write("fourty "); break;
                case 5: Console.Write("fifty "); break;
                case 6: Console.Write("sixsty "); break;
                case 7: Console.Write("seventy "); break;
                case 8: Console.Write("eighty "); break;
                case 9: Console.Write("ninety "); break;
            }
            if(tens==1)
            {
                if (tens == 1 && ones == 0)
                {
                    Console.Write("ten");
                }
                if(tens==1 && ones==1)
                {
                    Console.Write("eleven");
                }
                if(tens==1 && ones==2)
                {
                    Console.Write("twelve");
                }
                if(tens==1 && ones==3)
                {
                    Console.Write("thirteen");
                }
                if(tens==1 && ones==4)
                {
                    Console.Write("fourteen");
                }
                if(tens==1 && ones==5)
                {
                    Console.Write("fifteen");
                }
                if(tens==1 && ones==6)
                {
                    Console.Write("sixteen");
                }
                if(tens==1 && ones==7)
                {
                    Console.Write("seventeen");
                }
                if(tens==1 && ones==8)
                {
                    Console.Write("eighteen");
                }
                if(tens==1 && ones==9)
                {
                    Console.Write("nineteen");
                }
            }

            if(tens!=1)
            {
                if(ones==1)
                {
                    Console.Write("one ");
                }
                if (ones == 2)
                {
                    Console.Write("two ");
                }
                if (ones == 3)
                {
                    Console.Write("three ");
                }
                if (ones == 4)
                {
                    Console.Write("four ");
                }
                if (ones == 5)
                {
                    Console.Write("five ");
                }
                if (ones == 6)
                {
                    Console.Write("six ");
                }
                if (ones == 7)
                {
                    Console.Write("seven ");
                }
                if (ones == 8)
                {
                    Console.Write("eight ");
                }
                if (ones == 9)
                {
                    Console.Write("nine ");
                }
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid number");
        }
        
    }
}