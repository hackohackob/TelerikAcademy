using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirTree
{
    class FirTree
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int ateriks = 1;
            int wide = (2 * (n-1)) - 1;
            int center = wide / 2 + 1;
            

            for (int i = 1; i <=n; i++)
            {
                int pos = 1;
                for (int j = 1; j <= wide; j++)
                {
                    if ((pos>center-i && pos<center+i) && i!=n)
                    {
                        Console.Write("*");
                    }
                    else if(i==n && pos==center)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    pos++;

                }
                Console.WriteLine();
            }
        }
    }
}
