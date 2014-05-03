using System;
class BritainFlag
{
    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());
        int posRow = 1, posCol = 1;
        for (int i = 1; i <=n / 2; i++)
        {
            for (int j = 1; j <= n / 2; j++)
            {
                if (j==i)
                {
                    Console.Write("\\");                    
                }
                else
                {
                    Console.Write(".");                    
                }                
            }

            Console.Write("|");

            for (int j = n/2; j >0 ; j--)
            {
                if (j == i)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
        for (int i = 1; i <=n; i++)
        {
            if(i==n/2+1)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write("-");
            }
        }
        Console.WriteLine();

        for (int i = 1; i <= n / 2; i++)
        {
            for (int j = n / 2; j > 0; j--)
            {
                if (j == i)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(".");
                }
            }
            

            Console.Write("|");

            for (int j = 1; j <= n / 2; j++)
            {
                if (j == i)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
    }
}