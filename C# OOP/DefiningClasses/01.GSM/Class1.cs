using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSM;

namespace _01.GSM
{
    class Class1
    {
        public static void Main()
        {

            GSMAll[] phones = new GSMAll[4];

            phones[0] = new GSMAll("S4 mini", "Samsung", "Hacko", 600, new Display(920, 1024, 6000000), new Battery("samsung", 12, 1));
            phones[1] = new GSMAll("S4 ", "Samsung", "Someone", 1000, new Display(1280, 1024, 6000000), new Battery("samsung", 16, 4));
            phones[2] = new GSMAll("HTC", "One", "Anybody", 20, new Display(1280, 1024, 6000000), new Battery("HTC", 12, 1));
            phones[3] = GSMAll.iPhone4S;


            Console.WriteLine("Phones:");
            foreach(GSMAll phone in phones)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(phone.ToString());
            }

            Console.WriteLine("------------------------------");

           
        }
    }
}
