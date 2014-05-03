using System;

namespace RPGGame
{
    public interface  IAlive
    {
        string Name { get; }
        Coordinates Position { get; set; }
        int Health { get; }

        int Orientation { get; }
    }
}
