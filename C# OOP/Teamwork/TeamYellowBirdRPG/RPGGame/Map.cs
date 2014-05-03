namespace RPGGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Map
    {
        private string[] currentLine;
        private List<Coordinates> givenRandomNumbers = new List<Coordinates>();

        public Map(string path)
        {
            this.currentLine = new string[ConsoleClass.HorizontalLinePosition];
            this.MapMatrix = new string[ConsoleClass.HorizontalLinePosition, ConsoleClass.VerticalLinePosition];
            this.VisitedMatrix = new bool[ConsoleClass.HorizontalLinePosition, ConsoleClass.VerticalLinePosition];
            this.VisabilityMapMatrix = new bool[ConsoleClass.HorizontalLinePosition, ConsoleClass.VerticalLinePosition];
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                for (int i = 0; i < ConsoleClass.HorizontalLinePosition; i++)
                {
                    this.currentLine[i] = reader.ReadLine();
                    for (int j = 0; j < ConsoleClass.VerticalLinePosition; j++)
                    {
                        this.MapMatrix[i, j] = this.currentLine[i][j].ToString();
                    }
                }
            }
        }

        private string[,] MapMatrix { get; set; }

        private bool[,] VisitedMatrix { get; set; } // ex WasVisited

        private bool[,] VisabilityMapMatrix { get; set; } // Ex IsShown

        public string ReadFromMap(int x, int y)
        {
            return this.MapMatrix[x, y].ToString();
        }

        public void WriteToMap(int x, int y, string value)
        {
            this.MapMatrix[x, y] = value;
        }

        public bool WasVisited(int x, int y)
        {
            return this.VisitedMatrix[x, y];
        }

        public void MarkAsVisited(int x, int y)
        {
            this.VisitedMatrix[x, y] = true;
        }

        public bool IsShown(int x, int y)
        {
            return this.VisabilityMapMatrix[x, y];
        }

        public void MarkAsShown(int x, int y)
        {
            this.VisabilityMapMatrix[x, y] = true;
        }

        // TO DO: Extract all print methods to separate class

        // currently not used
        //public void PrintWholeMap()
        //{
        //    for (int i = 0; i < ConsoleClass.HorizontalLinePosition; i++)
        //    {
        //        for (int j = 0; j < ConsoleClass.VerticalLinePosition; j++)
        //        {
        //            PrintColor(i, j);
        //            this.MarkAsShown(i, j);
        //        }
        //    }
        //}

        public bool CanBeStepped(int x, int y)
        {
            if (x >= 0 && x < ConsoleClass.HorizontalLinePosition & y >= 0 && y < ConsoleClass.VerticalLinePosition)
            {
                if (this.MapMatrix[x, y] == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // currently not used
        //public void PrintMatrix()
        //{
        //    Console.SetCursorPosition(0, 0);
        //    for (int i = 0; i < ConsoleClass.HorizontalLinePosition; i++)
        //    {
        //        for (int j = 0; j < ConsoleClass.VerticalLinePosition; j++)
        //        {
        //            Console.Write(this.MapMatrix[i, j]);
        //        }

        //        Console.WriteLine();
        //    }
        //}

        public Coordinates RandomFreePosition()
        {
            int seed = int.Parse((DateTime.Now.Ticks % 100000).ToString());
            System.Threading.Thread.Sleep(5);
            Random randomGenerator = new Random(seed);
            int x, y;
            x = randomGenerator.Next(ConsoleClass.HorizontalLinePosition);
            y = randomGenerator.Next(ConsoleClass.VerticalLinePosition);
            while ((!this.CanBeStepped(x, y)) ||
                Math.Abs((x - Hero.StartPositionX)) < 5 ||
                Math.Abs((y - Hero.StartPositionY)) < 5)
            {
                x = randomGenerator.Next(ConsoleClass.HorizontalLinePosition);
                y = randomGenerator.Next(ConsoleClass.VerticalLinePosition);
            }

            return new Coordinates(x, y);
        }

        public void InputCreaturesInMap(List<Creeper> creepers)
        {
            string creeperNumber = "0";

            foreach (var creep in creepers)
            {
                if (creep.GetType().Name == "Goblin")
                {
                    creeperNumber = "5";
                }
                else if (creep.GetType().Name == "Orc")
                {
                    creeperNumber = "6";
                }

                this.WriteToMap(creep.Position.X, creep.Position.Y, creeperNumber);
            }
        }

        public void PrintAroundPoint(int x, int y)
        {
            for (int i = x - 3; i <= x + 3; i++)
            {
                for (int j = y - 3; j <= y + 3; j++)
                {
                    if (i >= 0 && i < ConsoleClass.HorizontalLinePosition && j >= 0 && j < ConsoleClass.VerticalLinePosition)
                    {
                        PrintColor(i, j);
                        this.MarkAsShown(i, j);
                    }
                }
            }

            for (int i = x - 4; i <= x + 4; i++)
            {
                for (int j = y - 2; j <= y + 2; j++)
                {
                    if (i >= 0 && i < ConsoleClass.HorizontalLinePosition && j >= 0 && j < ConsoleClass.VerticalLinePosition)
                    {
                        PrintColor(i, j);
                        this.MarkAsShown(i, j);
                    }
                }
            }

            for (int i = x - 2; i <= x + 2; i++)
            {
                for (int j = y - 4; j <= y + 4; j++)
                {
                    if (i >= 0 && i < ConsoleClass.HorizontalLinePosition && j >= 0 && j < ConsoleClass.VerticalLinePosition)
                    {
                        PrintColor(i, j);
                        this.MarkAsShown(i, j);
                    }
                }
            }
        }

        public void PrintColor(int x, int y)
        {
            Console.SetCursorPosition(y, x);
            if (this.MapMatrix[x, y] == "0")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
            else if (this.MapMatrix[x, y] == "1")
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");
            }
            else if (this.MapMatrix[x, y] == "2" || MapMatrix[x, y] == "3")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(" ");
            }
            else if (this.MapMatrix[x, y] == "4")
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" ");
            }
            else if (this.MapMatrix[x, y] == "5")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("g");
                Console.ResetColor();
            }
            else if (this.MapMatrix[x, y] == "6")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("O");
                Console.ResetColor();
            }
            else if (this.MapMatrix[x, y] == "8")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("^");
                Console.ResetColor();
            }

            Console.SetCursorPosition(y, x);
            Console.ResetColor();
        }
    }
}
