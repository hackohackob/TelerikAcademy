using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;

        private byte? age;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid input!");
                this.name = value;
            }
        }

        public byte Age
        {
            get { return this.age.Value; }
            set 
            {
                if (value < 0 || value > 125)
                    throw new ArgumentException("What the *#@$ ?!");
                this.age = value;
            }
        }


        public Person(string name, byte? age = null)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            if (this.age != null)
            {
                return string.Format("\nName: {0}\nAge: {1}", this.name, this.age);
            }
            return string.Format("\nName: {0}\nAge was not specified!", this.name);
        }
    }
}
