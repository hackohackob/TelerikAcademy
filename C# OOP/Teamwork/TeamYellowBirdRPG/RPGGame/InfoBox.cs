using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public static class InfoBox
    {
        public static void PrintName(Hero myhero)
        {
            Console.SetCursorPosition(62, 0);
            Console.Write("".PadRight(11, ' '));
            Console.SetCursorPosition(62, 0);
            Console.Write("Name: {0}", myhero.Name);
        }
        public static void PrintHealth(Hero myhero)
        {
            Console.SetCursorPosition(62, 1);
            Console.Write("".PadRight(11, ' '));
            Console.SetCursorPosition(62, 1);
            Console.Write("Health: {0}",myhero.Health);
        }

        public static void PrintMoney(Hero myHero)
        {
            Console.SetCursorPosition(62, 2);
            Console.Write("".PadRight(11, ' '));
            Console.SetCursorPosition(62, 2);
            Console.Write("Money: {0}", myHero.Money);
        }

        public static void PrintInfo(Hero myHero)
        {
            PrintHealth(myHero);
            PrintMoney(myHero);
            PrintName(myHero);
        }
    }
}
