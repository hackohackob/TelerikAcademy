using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpet
{
    class Carpet
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int lines = n, elementsOnLine = n, center = elementsOnLine / 2;
            for (int i = 1; i <= center; i++)
            {
                int curPos = 1;
                while (curPos <= elementsOnLine)
                {
                    if ((curPos <= center - i) || (curPos > center + i))
                    {
                        Console.Write(".");
                        curPos++;
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("/");
                                curPos++;
                            }
                            else
                            {
                                Console.Write(" ");
                                curPos++;
                            }

                        }
                        for (int j = i; j > 0; j--)
                        {
                            if (j % 2 != 0)
                            {
                                Console.Write("\\");
                                curPos++;
                            }
                            else
                            {
                                Console.Write(" ");
                                curPos++;
                            }

                        }
                    }

                }
                Console.WriteLine();

            }

            for (int i = center; i > 0; i--)
            {
                int curPos = 1;
                while (curPos <= elementsOnLine)
                {
                    if ((curPos <= center - i) || (curPos > center + i))
                    {
                        Console.Write(".");
                        curPos++;
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("\\");
                                curPos++;
                            }
                            else
                            {
                                Console.Write(" ");
                                curPos++;
                            }

                        }
                        for (int j = i; j > 0; j--)
                        {
                            if (j % 2 != 0)
                            {
                                Console.Write("/");
                                curPos++;
                            }
                            else
                            {
                                Console.Write(" ");
                                curPos++;
                            }

                        }
                    }
                }
                Console.WriteLine();

            }

        }
    }
}

