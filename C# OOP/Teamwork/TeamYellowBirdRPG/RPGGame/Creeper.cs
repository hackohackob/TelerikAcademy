namespace RPGGame
{
    using System;
    using System.Collections.Generic;

    public abstract class Creeper : Alive, ICreeper, IAlive
    {
        private const int RangeAroundCreeper = 5;

        public void Walk(Map mymap, Hero myHero, Creeper creeper)
        {
            if (!HeroInRange(myHero, creeper))
            {
                if (this.Orientation == 0)
                {
                    if (mymap.CanBeStepped(this.Position.X - 1, this.Position.Y))
                    {
                        this.MoveUp();
                    }
                }
                else if (this.Orientation == 1)
                {
                    if (mymap.CanBeStepped(this.Position.X, this.Position.Y + 1))
                    {
                        this.MoveRight();
                    }
                }
                else if (this.Orientation == 2)
                {
                    if (mymap.CanBeStepped(this.Position.X + 1, this.Position.Y))
                    {
                        this.MoveDown();
                    }
                }
                else if (this.Orientation == 3)
                {
                    if (mymap.CanBeStepped(this.Position.X, this.Position.Y - 1))
                    {
                        this.MoveLeft();
                    }
                }
            }
            else
            {
                this.MoveTowardsHero(mymap, myHero, creeper);
            }
        }

        private void MoveTowardsHero(Map mymap, Hero myHero, Creeper creeper)
        {
            for (int i = creeper.Position.X - RangeAroundCreeper; i < creeper.Position.X + RangeAroundCreeper; i++)
            {
                for (int j = creeper.Position.Y - RangeAroundCreeper; j < creeper.Position.Y + RangeAroundCreeper; j++)
                {
                    if (myHero.Position.X == i && myHero.Position.Y == j)
                    {
                        if (i < creeper.Position.X)
                        {
                            if (mymap.CanBeStepped(this.Position.X - 1, this.Position.Y))
                            {
                                creeper.Orientation = 0;
                                if (mymap.CanBeStepped(this.Position.X - 1, this.Position.Y))
                                {
                                    this.MoveUp();
                                }
                            }
                            else if (j < creeper.Position.Y)
                            {
                                if (mymap.CanBeStepped(this.Position.X, this.Position.Y - 1))
                                {
                                    creeper.MoveLeft();
                                }
                            }
                            else if (j > creeper.Position.Y)
                            {
                                if (mymap.CanBeStepped(this.Position.X, this.Position.Y + 1))
                                {
                                    creeper.MoveRight();
                                }
                            }
                        }
                        else if (i > creeper.Position.X)
                        {
                            if (mymap.CanBeStepped(this.Position.X + 1, this.Position.Y))
                            {
                                creeper.Orientation = 2;
                                if (mymap.CanBeStepped(this.Position.X + 1, this.Position.Y))
                                {
                                    this.MoveDown();
                                }
                            }
                            else if (j < creeper.Position.Y)
                            {
                                if (mymap.CanBeStepped(this.Position.X, this.Position.Y - 1))
                                {
                                    creeper.MoveLeft();
                                }
                            }
                            else if (j > creeper.Position.Y)
                            {
                                if (mymap.CanBeStepped(this.Position.X, this.Position.Y + 1))
                                {
                                    creeper.MoveRight();
                                }
                            }
                        }
                        else if (j < creeper.Position.Y)
                        {
                            if (mymap.CanBeStepped(this.Position.X, this.Position.Y - 1))
                            {
                                creeper.Orientation = 3;
                                if (mymap.CanBeStepped(this.Position.X, this.Position.Y - 1))
                                {
                                    this.MoveLeft();
                                }
                            }
                            else if (mymap.CanBeStepped(this.Position.X - 1, this.Position.Y))
                            {
                                creeper.MoveUp();
                            }
                            else if (mymap.CanBeStepped(this.Position.X + 1, this.Position.Y))
                            {
                                creeper.MoveDown();
                            }
                        }
                        else if (j > creeper.Position.Y)
                        {
                            if (mymap.CanBeStepped(this.Position.X, this.Position.Y + 1))
                            {
                                creeper.Orientation = 1;
                                if (mymap.CanBeStepped(this.Position.X, this.Position.Y + 1))
                                {
                                    this.MoveRight();
                                }
                            }
                            else if (mymap.CanBeStepped(this.Position.X - 1, this.Position.Y))
                            {
                                creeper.MoveUp();
                            }
                            else if (mymap.CanBeStepped(this.Position.X + 1, this.Position.Y))
                            {
                                creeper.MoveDown();
                            }
                        }
                    }

                }
            }
        }

        public static void AllCreepersWalk(Map map, Hero myHero, List<Creeper> creepers)
        {
            foreach (var creeper in creepers)
            {
                Console.SetCursorPosition(creeper.Position.Y, creeper.Position.X);
                Console.Write(" ");
                map.WriteToMap(creeper.Position.X, creeper.Position.Y, "0");
                creeper.Walk(map, myHero, creeper);

                string creeperNumber = "0";

                if (creeper.GetType().Name == "Goblin")
                {
                    creeperNumber = "5";
                }
                else if (creeper.GetType().Name == "Orc")
                {
                    creeperNumber = "6";
                }

                map.WriteToMap(creeper.Position.X, creeper.Position.Y, creeperNumber);
            }
        }

        internal static void TurnIfNeccessary(Map mymap, List<Creeper> creepers)
        {
            foreach (var creeper in creepers)
            {
                CreeperTurnIfNeccessary(mymap, creeper);
            }
        }

        private static void CreeperTurnIfNeccessary(Map mymap, Creeper creeper)
        {
            Random randomGenerator = new Random();

            if (creeper.Orientation == 0 && !mymap.CanBeStepped(creeper.Position.X - 1, creeper.Position.Y))
            {
                creeper.Orientation = randomGenerator.Next(4);
            }
            else if (creeper.Orientation == 1 && !mymap.CanBeStepped(creeper.Position.X, creeper.Position.Y + 1))
            {
                creeper.Orientation = randomGenerator.Next(4);
            }
            else if (creeper.Orientation == 2 && !mymap.CanBeStepped(creeper.Position.X + 1, creeper.Position.Y))
            {
                creeper.Orientation = randomGenerator.Next(4);
            }
            else if (creeper.Orientation == 3 && !mymap.CanBeStepped(creeper.Position.X, creeper.Position.Y - 1))
            {
                creeper.Orientation = randomGenerator.Next(4);
            }
        }

        internal static void PrintCreepers(Map mymap, List<Creeper> creepers)
        {
            foreach (var creeper in creepers)
            {
                if (mymap.IsShown(creeper.Position.X, creeper.Position.Y))
                {
                    Console.SetCursorPosition(creeper.Position.Y, creeper.Position.X);
                    mymap.PrintColor(creeper.Position.X, creeper.Position.Y);
                    Console.SetCursorPosition(creeper.Position.Y, creeper.Position.X);
                }
            }
        }

        internal static void HitIfNearby(Map mymap, Hero myHero, List<Creeper> creepers)
        {
            foreach (var creeper in creepers)
            {
                if (Creeper.HeroNearby(mymap, myHero, creeper))
                {
                    myHero.Health -= creeper.Damage;
                    InfoBox.PrintHealth(myHero);
                    Console.Beep();
                }
            }
        }

        public static bool HeroNearby(Map mymap, Hero myHero, Creeper creeper)
        {
            for (int i = creeper.Position.X - 1; i <= creeper.Position.X + 1; i++)
            {
                for (int j = creeper.Position.Y - 1; j <= creeper.Position.Y + 1; j++)
                {
                    if (myHero.Position.X == i && myHero.Position.Y == j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool HeroInRange(Hero myHero, Creeper creeper)
        {
            for (int i = creeper.Position.X - RangeAroundCreeper; i < creeper.Position.X + RangeAroundCreeper; i++)
            {
                for (int j = creeper.Position.Y - RangeAroundCreeper; j < creeper.Position.Y + RangeAroundCreeper; j++)
                {
                    if (myHero.Position.X == i && myHero.Position.Y == j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
