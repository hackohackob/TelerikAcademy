using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class PersonsProgram
    {
        static void Main()
        {
            Person person1 = new Person("Pesho", 20);
            Person person2 = new Person("Gosho");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}
