using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public abstract class Alive: IAlive
    {
        protected string name;
        protected Coordinates position;
        protected int health;
        protected int damage;
        protected int orientation;
        public abstract string Name { get; protected set; }
        public abstract Coordinates Position { get; set; }
        public abstract int Health { get; set; }

        public abstract int Money { get; set; }
        public abstract int Orientation { get; protected set; }

        public abstract int Damage { get; protected set; }

        public void MoveUp()
        {
               this.Position.X--;
        }
        public void MoveDown()
        {
            this.Position.X++;
        }
        public void MoveLeft()
        {
            this.Position.Y--;
        }
        public void MoveRight()
        {
            this.Position.Y++;
        }
        //ADD ABSTRACT MOVEMENT METHODS AND ALSO ADD THEM IN THE INTERFACE IALIVE

        
    }
}
