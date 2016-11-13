namespace SocialNetwork.ConsoleClient
{
    using System.Linq;
    using System.Data.Entity;

    using SocialNetwork.Data;
    using SocialNetwork.Importer;
    using Data.Migrations;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            using (var db = new SocialNetworkDbContext())
            {
                Importer.ImportXML();
            }
        }
    }
}
