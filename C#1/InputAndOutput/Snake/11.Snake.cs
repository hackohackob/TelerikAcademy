using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    //Implement the "Falling rocks" game. 
    //Instead of "Falling rocks" game i decided to implement the snake game
    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Snake
    {
        static void Main(string[] args)
        {
            int slp = 0, width;
            Console.BufferHeight = Console.WindowHeight;



            Console.Clear();
            Console.CursorVisible = false;
            width = Console.WindowWidth;
            for (int space = 0; space < 4; space++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("{0,42}", "MENU");
            Console.WriteLine();
            Console.WriteLine("{0,44}", "P-Pause");
            Console.WriteLine();
            Console.WriteLine("{0,44}", "L-Level");
            Console.WriteLine();
            Console.WriteLine("{0,50}", "Press Enter to start");
            Console.ReadLine();
            Console.Clear();
            for (int space = 0; space < 4; space++)
            {
                Console.WriteLine();
            }
            Console.Write("{0,48}", "Input level number:");
            while (!int.TryParse(Console.ReadLine(), out slp))
            {
                Console.Clear();
                Console.Write("Input a valid number!");
            }
            slp = 100 / slp;


            Position[] directions = new Position[]
            {
                new Position(0,1),  //right
                new Position(0,-1), //left
                new Position(1,0),  //down
                new Position(-1,0), //up
            };

            int direction = 0;      //0

            Random randomNumberGenerator = new Random();

            Position food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth));

            Position antiFood = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth));

            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 38; i < 43; i++)
            {
                snakeElements.Enqueue(new Position(10, i));
            }

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.Write("*");
            }



            while (true)
            {


                if (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if ((userInput.Key == ConsoleKey.LeftArrow || userInput.Key == ConsoleKey.A) && direction != 0)
                    {
                        direction = 1;
                    }
                    if ((userInput.Key == ConsoleKey.RightArrow || userInput.Key == ConsoleKey.D) && direction != 1)
                    {
                        direction = 0;
                    }
                    if ((userInput.Key == ConsoleKey.DownArrow || userInput.Key == ConsoleKey.S) && direction != 3)
                    {
                        direction = 2;
                    }
                    if ((userInput.Key == ConsoleKey.UpArrow || userInput.Key == ConsoleKey.W) && direction != 2)
                    {
                        direction = 3;
                    }
                    if (userInput.Key == ConsoleKey.D0)
                    {
                        break;
                    }
                    if (userInput.Key == ConsoleKey.P)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2);
                        Console.Write("PAUSE");
                        //Console.WriteLine("{0,42}","PAUSE");
                        //Console.WriteLine("{0,51}","Press Enter to continue");
                        Console.ReadLine();
                    }
                    if (userInput.Key == ConsoleKey.L)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2);
                        Console.Write("CHOOSE LEVEL:");
                        //Console.WriteLine("{0,42}","PAUSE");
                        //Console.WriteLine("{0,51}","Press Enter to continue");
                        slp = int.Parse(Console.ReadLine());
                        slp = 100 / slp;
                    }
                }





                Position snakeHead = snakeElements.Last();

                Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);


                //if(snakeNewHead.row<0 || snakeNewHead.col<0 ||
                //    snakeNewHead.row>=Console.WindowHeight ||
                //    snakeNewHead.col>=Console.WindowWidth)
                //{
                //    Console.Clear();
                //    Console.WriteLine("Game OVER");
                //    Console.WriteLine("Your points:{0}", snakeElements.Count-6);
                //    Console.ReadLine();
                //    direction = 0;
                //    snakeNewHead.row = 0;
                //    snakeNewHead.col = 0;

                //}
                if (snakeNewHead.row < 0)
                {
                    snakeNewHead.row = Console.WindowHeight - 1;
                }
                if (snakeNewHead.col < 0)
                {
                    snakeNewHead.col = Console.WindowWidth - 1;
                }
                if (snakeNewHead.row == Console.WindowHeight)
                {
                    snakeNewHead.row = 0;
                }
                if (snakeNewHead.col == Console.WindowWidth)
                {
                    snakeNewHead.col = 0;
                }

                if (snakeElements.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 17, Console.WindowHeight / 2);
                    Console.WriteLine("You tried to eat yourself! Game Over!");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                snakeElements.Enqueue(snakeNewHead);



                Console.Clear();
                Console.SetCursorPosition(food.col, food.row);
                Console.Write("@");

                Console.SetCursorPosition(antiFood.col, antiFood.row);
                Console.Write("X");


                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    food.col = randomNumberGenerator.Next(0, Console.WindowWidth);
                    food.row = randomNumberGenerator.Next(0, Console.WindowHeight);
                    Console.Beep(7000, 50);
                }
                else
                {
                    snakeElements.Dequeue();
                }

                if (snakeHead.col == antiFood.col && snakeHead.row == antiFood.row)
                {
                    snakeElements.Dequeue();
                    snakeElements.Dequeue();
                    snakeElements.Dequeue();
                    antiFood.col = randomNumberGenerator.Next(0, Console.WindowWidth);
                    antiFood.row = randomNumberGenerator.Next(0, Console.WindowHeight);
                    Console.Beep(1000, 50);
                }

                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write("*");
                }

                if (direction == 0)
                {
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.Write("O");
                }
                if (direction == 1)
                {
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.Write("O");
                }
                if (direction == 2)
                {
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.Write("O");
                }
                if (direction == 3)
                {
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.Write("O");
                }

                Thread.Sleep(slp);


            }
        }
    }
}
