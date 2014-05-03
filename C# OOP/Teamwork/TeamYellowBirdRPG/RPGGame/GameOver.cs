using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public static class GameOver
    {
        public static void EndGame()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.BufferWidth - 65), Console.BufferHeight / 2);
            Console.Write("SORRY. GAME OVER. MAYBE NEXT TIME ;)");
        }

        public static void GameWon()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.BufferWidth - 65), Console.BufferHeight / 2);
            Console.WriteLine("CONGRATULATIONS, YOU WON !");
        }
    }
}
