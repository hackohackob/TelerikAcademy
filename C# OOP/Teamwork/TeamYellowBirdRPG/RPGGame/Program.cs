using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RPGGame
{
    public class Program
    {
        public const string MapPath = "TheMap.txt";

        public static void Main()
        {
            ConsoleClass.SetConsoleSize();

            // printing intro page
            Intro.PrintYellowBird();

            string heroName = Hero.EnterName();  
            Hero myHero = new Hero(heroName);
            Map mymap = new Map(MapPath);
            ConsoleClass.PrintBorders();
            DateTime now = new DateTime();
            now = DateTime.Now;

            List<NPC> NPCs = new List<NPC>();
            AddNPCs(NPCs,mymap);

            List<Creeper> creepers = new List<Creeper>();
            for (int i = 0; i < 10; i++)
            {
                creepers.Add(new Orc("Orc" + (i + 1), mymap.RandomFreePosition()));
            }
            for (int i = 0; i < 15; i++)
            {
                creepers.Add(new Goblin("Goblin" + (i + 1), mymap.RandomFreePosition()));
            }

            mymap.InputCreaturesInMap(creepers);
            InfoBox.PrintInfo(myHero);
            mymap.PrintAroundPoint(myHero.Position.X, myHero.Position.Y);
            mymap.MarkAsVisited(myHero.Position.X, myHero.Position.Y);
            myHero.PrintHero();
            MessageBox.Print("Hello "+myHero.Name+"!");
            MessageBox.Print("This is Team Yellow Bird's RPG game, hope you enjoy it :)");
            Console.ReadKey();
            MessageBox.Clear();
            while (true)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (mymap.CanBeStepped(myHero.Position.X - 1, myHero.Position.Y))
                        {
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "0");
                            myHero.MoveUp();
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "7");
                        }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (mymap.CanBeStepped(myHero.Position.X + 1, myHero.Position.Y))
                        {
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "0");
                            myHero.MoveDown();
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "7");
                        }
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        if (mymap.CanBeStepped(myHero.Position.X, myHero.Position.Y - 1))
                        {
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "0");
                            myHero.MoveLeft();
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "7");
                        }
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        if (mymap.CanBeStepped(myHero.Position.X, myHero.Position.Y + 1))
                        {
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "0");
                            myHero.MoveRight();
                            mymap.WriteToMap(myHero.Position.X, myHero.Position.Y, "7");
                        }
                    }
                    else if (key.Key == ConsoleKey.Spacebar)
                    {
                        Hero.HitNearby(myHero, creepers);
                    }

                    if (mymap.WasVisited(myHero.Position.X, myHero.Position.Y) == false)
                    {
                        mymap.PrintAroundPoint(myHero.Position.X, myHero.Position.Y);
                        mymap.MarkAsVisited(myHero.Position.X, myHero.Position.Y);
                    }
                    if (key.Key != ConsoleKey.Spacebar)
                    {
                        mymap.PrintAroundPoint(myHero.Position.X, myHero.Position.Y);
                        myHero.PrintHero();
                    }
                    RemoveDeadCreepers(mymap, myHero, creepers);
                }

                NPC.GiveQuestIfNeccessary(NPCs, myHero);
                NPC.OpenDoorIfQuestIsFinished(myHero, mymap);
                if(NPC.IsTheGameFinished(myHero))
                {
                    break;
                }
                MessageBox.Clear();
                now = DateTime.Now;

                if (now.Millisecond % 200 == 0)
                {
                    myHero.PrintHero();

                    Creeper.TurnIfNeccessary(mymap, creepers);
                    Creeper.AllCreepersWalk(mymap, myHero, creepers);
                    Creeper.PrintCreepers(mymap, creepers);
                    Creeper.HitIfNearby(mymap, myHero, creepers);
                }

                if (myHero.Health < 1)
                {
                    GameOver.EndGame();
                    break;
                }
            }

            if (NPC.IsTheGameFinished(myHero))
            {
                GameOver.GameWon();
            }
            ConsoleKeyInfo endKey = Console.ReadKey();
            while (endKey.Key != ConsoleKey.Enter)
            {
                endKey = Console.ReadKey();
            }
            MessageBox.Clear();
            Console.ReadLine();
        }

        private static void RemoveDeadCreepers(Map mymap, Hero myHero, List<Creeper> creepers)
        {
            for (int i = 0; i < creepers.Count; i++)
            {
                if (creepers[i].Health < 1)
                {
                    mymap.WriteToMap(creepers[i].Position.X, creepers[i].Position.Y, "0");
                    Console.SetCursorPosition(creepers[i].Position.Y, creepers[i].Position.X);
                    Console.Write(" ");
                    Console.SetCursorPosition(creepers[i].Position.Y, creepers[i].Position.X);
                    if (creepers[i].GetType().Name == "Orc")
                    {
                        creepers[i] = new Orc("Orc" + (i + 1), mymap.RandomFreePosition());
                        myHero.Health += 3;
                        myHero.Money += 20;
                        InfoBox.PrintMoney(myHero);
                    }
                    else if (creepers[i].GetType().Name == "Goblin")
                    {
                        creepers[i] = new Goblin("Goblin" + (i + 1), mymap.RandomFreePosition());
                        myHero.Health += 2;
                        myHero.Money += 10;
                        InfoBox.PrintMoney(myHero);
                    }
                }
            }
        }

        private static void AddNPCs(List<NPC> NPCs, Map mymap)
        {
            NPCs.Add(new NPC("Kenov", new Coordinates(33,39), new Quest("First Quest", new List<string>{"Hello, boy!" , "You are new here, aren't you?", "You look very weak.", "With only this much health, you won't be able to survive!" , "Bring me 200 coins, and I'll double your health!"})));

            NPCs.Add(new NPC("Kostov", new Coordinates(5, 49), new Quest("Second Quest", new List<string>{"Hey, there!" , "I see you are a tough guy.", "If you can beat all these orcs and goblins", "and bring me 400 coins" , "I'll give you the key for the bridge!"})));

            foreach(var NPC in NPCs)
            {
                mymap.WriteToMap(NPC.Position.X, NPC.Position.Y, "8");
            }
        }
    }
}
