namespace RPGGame
{
    using System;

    public static class ConsoleClass
    {
        public const byte ConsoleHeight = 41;
        public const byte ConsoleWidth = 81;
        public const byte MidleInterfaceLinePosition = 21;
        public const byte VerticalLinePosition = 60;
        public const byte HorizontalLinePosition = 35;

        public static void SetConsoleSize()
        {
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight);
            Console.CursorVisible = false;
        }

        public static void PrintBorders()
        {
            for (int i = 0; i < ConsoleHeight; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(VerticalLinePosition, i);
                Console.Write("#");
                Console.SetCursorPosition(VerticalLinePosition, i);
                Console.ResetColor();
            }

            for (int i = VerticalLinePosition; i < ConsoleWidth; i++)
            {
                Console.SetCursorPosition(i, MidleInterfaceLinePosition);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("#");
                Console.SetCursorPosition(i, MidleInterfaceLinePosition);
                Console.ResetColor();
            }

            for (int i = 0; i <= VerticalLinePosition; i++)
            {
                Console.SetCursorPosition(i, HorizontalLinePosition);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("#");
                Console.SetCursorPosition(i, HorizontalLinePosition);
                Console.ResetColor();
            }
        }
    }
}
