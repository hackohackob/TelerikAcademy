using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Test
    {
        static void Main()
        {
            //whatever you want to test here
            Student stud1 = new Student("Pesho", "Peshev", 123);
            Student stud2 = new Student("Pesho", "Peshev", 123);

            Console.WriteLine(stud1.CompareTo(stud2));
        }
    }
}
