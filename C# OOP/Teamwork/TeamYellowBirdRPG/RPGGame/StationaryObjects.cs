using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public abstract class StationaryObjects : Coordinates
    {
        
        public string Name{ get; set; }

        StationaryObjects(int xPosition, int yPosition, string Name)
            : base(xPosition, yPosition)
        {
            this.Name = Name;
        }

        public abstract int Profit(int health);

    }
}
