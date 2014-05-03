using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Orc : Creeper, ICreeper, IAlive
    {

        Random randomGenerator = new Random();

        public override string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public override Coordinates Position { get; set; }

        public override int Health { get;  set; }

        public override int Money { get; set; }
        public override int Damage { get; protected set; }

        public override int Orientation { get; protected set; }

        public Orc(string name,Coordinates position)
        {
            this.Name = name;
            this.Position = position;
            this.Health = 100;
            this.Damage = 3;
            this.Orientation = randomGenerator.Next(4);
        }
    }
}
