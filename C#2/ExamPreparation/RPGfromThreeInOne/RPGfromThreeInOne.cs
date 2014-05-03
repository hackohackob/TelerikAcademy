using System;
using System.Linq;

class RPG
{
    static void problem3()
    {
        var number = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

        int[] current = number.Take(3).ToArray();
        int[] target = number.Skip(3).Take(3).ToArray();
        const int Gold=0;
        const int silver=1;
        const int bronze=2;

        int operations = 0;
        while (true)
        {
            while (current[silver] > target[silver])
            {
                if (current[Gold] < target[Gold])
                {
                    if (current[silver] - target[silver] >= 11)
                    {
                        current[silver] -= 11;
                        current[Gold] += 1;
                        operations += 1;
                    }
                }
                else if (current[bronze] < target[bronze])
                {
                    if (current[silver] - target[silver] >= 1)
                    {
                        current[silver] -= 1;
                        current[bronze] += 9;
                        operations += 1;
                    }
                }
                else
                {
                    Console.WriteLine(operations);
                    return;
                }
            }

            while (current[silver] < target[silver])
            {
                if (current[Gold] > target[Gold])
                {

                    current[silver] += 9;
                    current[Gold] -= 1;
                    operations += 1;

                }
                else if (current[bronze] - target[bronze] >= 11)
                {

                    current[silver] += 1;
                    current[bronze] -= 11;
                    operations += 1;

                }
                else
                {
                    Console.WriteLine(-1);
                }

            }

            if (current[Gold] < target[Gold])
            {
                if (current[bronze] - target[bronze] >= 11)
                {

                    current[silver] += 1;
                    current[bronze] -= 11;
                    operations += 1;

                }
                else
                {
                    Console.WriteLine(-1);
                }
            }

            if (current[bronze] < target[bronze])
            {
                if (current[Gold] > target[Gold])
                {
                    current[silver] += 9;
                    current[Gold] -= 1;
                    operations += 1;
                }
                else 
                {
                    Console.WriteLine(-1);
                }
            }
            if(current[Gold]>=target[Gold] && current[silver]>=target[silver] && current[bronze]>=target[bronze])
            {
                Console.WriteLine(operations);
                return;
            }
        }
    }
    static void Main()
    {
        problem3();
    }
}