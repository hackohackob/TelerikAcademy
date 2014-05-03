using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPGGame
{
    static class MessageBox
    {
        private static int used=0;
        public static void Print(string message)
        {
            if(used==5)
            {
                Clear();
            }
            Console.SetCursorPosition(0,36+used);
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(50);
            }
            used++;            
        }

        public static void Clear()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, 36+i);
                Console.Write("".PadRight(60, ' '));
            }
            used = 0;
        }

    }
}
