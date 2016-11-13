namespace PetStore.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    using PetStore.Data;
    public class Startup
    {
        public static void Main()
        {
            DataGenerator.GenerateAllData();
        }
    }
}
