using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



                            //FUCK THAT SHIT!!!!!!!
namespace TelerikLogo
{
    class TelerikLogo
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            int y = x;
            int z = (x / 2) + 1;
            int height = (3 * x) - 2;
            int width = (2 * z) + (2 * y) - 3;
            int horns = x / 2;
            int middleDots = width - (2 * z);

            Console.Write(new string('.', horns));
            Console.Write("*");
            Console.Write(new string('.', middleDots));
            Console.Write("*");
            Console.WriteLine(new string('.', horns));
            middleDots = middleDots - 2;

            int firstHornDots=x/2-1;
            int dotsAfterHorn=0;
            for (int i = 1; i < y; i++)
            {
                if(i<=x/2)
                {
                    Console.Write(new string('.',firstHornDots));
                    Console.Write("*");
                    Console.Write(new string('.',dotsAfterHorn));
                    
                }
                else
                {
                    Console.Write(new string('.', horns));
                }
                

                for (int j = 1; j <= i; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                Console.Write(new string('.', middleDots));
                if (middleDots > 1)
                {
                    middleDots = middleDots - 2;
                }
                else
                {
                    middleDots = 0;
                }
                if (i != y - 1)
                {
                    Console.Write("*");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(".");
                }

                 
                if (i <= x / 2)
                {
                    Console.Write(new string('.', dotsAfterHorn));
                    
                    Console.Write("*");
                    Console.Write(new string('.', firstHornDots));
                    
                }
                else
                {
                    Console.Write(new string('.', horns));
                }
                
                Console.WriteLine();
                firstHornDots--;
                dotsAfterHorn++;
                
            }

            int leftRightDots = x - 2;
            middleDots = 1;

            for (int i = 0; i < x-1; i++)
            {
                Console.Write(new string('.', horns));
                Console.Write(new string('.',leftRightDots));
                Console.Write("*");
                Console.Write(new string('.',middleDots));
                Console.Write("*");
                Console.Write(new string('.', leftRightDots));
                Console.Write(new string('.', horns));
                middleDots += 2;
                leftRightDots--;
                Console.WriteLine();

            }
            middleDots -= 4;
            for (int i = 1;  i < x-1; i++)
            {
                Console.Write(new string('.', horns));
                Console.Write(new string('.',i));
                Console.Write("*");
                Console.Write(new string('.',middleDots));
                Console.Write("*");
                Console.Write(new string('.', i));
                Console.Write(new string('.', horns));
                middleDots -= 2;
                Console.WriteLine();

            }
            Console.Write(new string('.',width/2));
            Console.Write("*");
            Console.Write(new string('.',width/2));

        }
    }
}
