using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Hero : Alive, IAlive
    {
        private const string HeroCharOnMap = "@";
        private const int HeroInitialHealth = 100;
        private const int HeroInitialDamage = 30;
        private const int HeroInitialMoney = 0;

        public const int StartPositionX = 33;
        public const int StartPositionY = 45 ;
        
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
                    // TODO make exception class
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public bool FirstQuestTold { get; set; }
        public bool SecondQuestTold { get; set; }
        public bool HealthQuestFinished { get; set; }
        public bool keyFound { get; set; }
        public bool KeyQuestFinished { get; set; }


        public override Coordinates Position { get; set; }

        public override int Health { get; set; }

        public override int Money { get; set; }

        public override int Damage { get; protected set; }

        public override int Orientation { get; protected set; }

        public Hero(string name)
        {
            this.Name = name;
            this.Position = new Coordinates(StartPositionX, StartPositionY); ;
            this.Health = HeroInitialHealth;
            this.Orientation = 10;
            this.Damage = HeroInitialDamage;
            this.Money = HeroInitialMoney;
        }

        // TODO extract to class Print, implement IPrinttable
        public void PrintHero() 
        {
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.Write(HeroCharOnMap);
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
        }

        public static string EnterName()
        {
            Console.SetCursorPosition((Console.BufferWidth - 65), Console.BufferHeight / 2);
            Console.Write("Please, input your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            return name;
        }


        internal static void HitNearby(Hero myHero, List<Creeper> creepers)
        {

            for (int i = 0; i < creepers.Count; i++)
            {
                if (Math.Abs(creepers[i].Position.X - myHero.Position.X) < 2 && Math.Abs(creepers[i].Position.Y - myHero.Position.Y) < 2)
                {
                    creepers[i].Health -= myHero.Damage;
                    Console.Beep(5000, 50);
                }
            }
        }
    }
}
