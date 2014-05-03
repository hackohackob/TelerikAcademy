namespace RPGGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NPC 
    {
        private const string NAME = "Master Q";
        public Coordinates Position { get; private set; }
        public string Name { get; private set; }

        public Quest questToGive { get; set; }
        public NPC(string NAME,Coordinates position, Quest quest)
        {
            this.Position = position;
            this.Name = NAME;
            this.questToGive = quest;
        }

        public static void GiveQuestIfNeccessary(List<NPC> NPCs, Hero myHero)
        {
            foreach(var NPC in NPCs)
            {
                if(NPC.IsHeroNear(myHero))
                {
                    if(NPC.IsQuestFinished(myHero,NPC.questToGive)==false)
                    {
                        NPC.GiveQuest(myHero);
                    }
                    else
                    {
                        NPC.GiveAward(myHero);
                    }
                }
            }
        }
        public bool IsHeroNear(Hero myhero)
        {
            if (Math.Abs(myhero.Position.X - this.Position.X) < 2 && Math.Abs(myhero.Position.Y - this.Position.Y) < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsQuestFinished(Hero myhero,Quest quest)
        {
            if (this.questToGive.Name == "First Quest" && myhero.Money>199)
            {
                return true;
            }
            else if (this.questToGive.Name == "Second Quest" && myhero.Money>399)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GiveQuest(Hero myHero)
        {
            if (questToGive.Name == "First Quest" && myHero.FirstQuestTold == false)
            {
                foreach (var message in this.questToGive.QuestMessage)
                {
                    MessageBox.Print(message);
                }
                myHero.FirstQuestTold = true; 
                System.Threading.Thread.Sleep(1000);
            }
            else if (questToGive.Name == "Second Quest" && myHero.SecondQuestTold == false)
            {
                foreach (var message in this.questToGive.QuestMessage)
                {
                    MessageBox.Print(message);
                }
                myHero.SecondQuestTold = true;
                System.Threading.Thread.Sleep(1000);
            }

        }

        public void GiveAward(Hero myhero)
        {
            if(this.questToGive.Name=="First Quest")
            {
                if (myhero.HealthQuestFinished == false)
                {
                    MessageBox.Print("Your health is now 200!");
                    myhero.Health = 200;
                    myhero.Money -= 200;
                    InfoBox.PrintHealth(myhero);
                    myhero.HealthQuestFinished = true;
                    System.Threading.Thread.Sleep(1000);
                }
            }
            else if (this.questToGive.Name=="Second Quest")
            {
                if (myhero.KeyQuestFinished == false)
                {
                    MessageBox.Print("Here, this is the key for the bridge gates");
                    myhero.Money -= 400;

                    myhero.keyFound = true;
                    myhero.KeyQuestFinished = true;
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        internal static void OpenDoorIfQuestIsFinished(Hero myHero,Map mymap)
        {
            if (myHero.keyFound)
            {
                mymap.WriteToMap(18, 53, "0");
                mymap.WriteToMap(19, 53, "0");
            }
        }

        public static bool IsTheGameFinished(Hero myhero)
        {
            if(myhero.Position.X>16 && myhero.Position.X<22 && myhero.Position.Y>53)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
