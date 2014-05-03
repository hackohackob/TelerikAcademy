namespace RPGGame
{
    using System.Collections.Generic;
    public class Quest
    {
        public string Name { get; set; }

        public List<string> QuestMessage { get; set; }

        public Quest(string Name,List<string> Message)
        {
            this.Name = Name;
            this.QuestMessage = Message;
        }
    }
}
