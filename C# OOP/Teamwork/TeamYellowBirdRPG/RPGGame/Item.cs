using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public abstract class Item
    {       
        public virtual int bonusTo { get; protected set; } //the bonus that the item will give
        public Coordinates Position { get; set; }
       
        public Item(int bonus, Coordinates position)
        {
            this.bonusTo = bonus;
            this.Position = position;
        }
    }
}
