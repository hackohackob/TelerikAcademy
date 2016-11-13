namespace SocialNetwork.Importer
{
    using XmlModels;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;
    using System.Linq;

    using SocialNetwork.Data;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    public static class Importer
    {
        public static void ImportXML()
        {
            FriendshipImport();
            PostsImport();
        }

        public static void FriendshipImport()
        {
            var serializer = new XmlSerializer(typeof(Friendships));
            string xmlFileName = ".\\XmlFiles\\Friendships-Test.xml";

            using (var fs = new FileStream(xmlFileName, FileMode.Open))
            {
                Friendships friendships = (Friendships)serializer.Deserialize(fs);


                List<Friendship> friendshipToAdd = new List<Friendship>();
                List<UserProfile> usersToAdd = new List<UserProfile>();
                List<Image> imagesToAddFirstUser = new List<Image>();
                List<Image> imagesToAddSecondUser = new List<Image>();


                using (var db = new SocialNetworkDbContext())
                {

                    var currentUsersnamesInDatabase = db.UserProfiles.Select(up => up.Username).ToList();

                    foreach (var friendship in friendships.Friendship)
                    {

                        if (!currentUsersnamesInDatabase.Contains(friendship.FirstUser.Username))
                        {
                            var firstUser = friendship.FirstUser;

                            usersToAdd.Add(new UserProfile
                            {
                                FirstName = firstUser.FirstName,
                                LastName = firstUser.LastName,
                                Username = firstUser.Username,
                                RegistrationDate = firstUser.RegisteredOn
                            });

                            foreach (var image in firstUser.Images)
                            {
                                imagesToAddFirstUser.Add(new Image {
                                    Url = image.ImageUrl,
                                    FileExtension = image.FileExtension
                                });
                            }
                        }

                        if (!currentUsersnamesInDatabase.Contains(friendship.SecondUser.Username))
                        {
                            var secondUser = friendship.SecondUser;

                            usersToAdd.Add(new UserProfile
                            {
                                FirstName = secondUser.FirstName,
                                LastName = secondUser.LastName,
                                Username = secondUser.Username,
                                RegistrationDate = secondUser.RegisteredOn
                            });

                            foreach (var image in secondUser.Images)
                            {
                                imagesToAddSecondUser.Add(new Image
                                {
                                    Url = image.ImageUrl,
                                    FileExtension = image.FileExtension,
                                });
                            }
                        }

                        if(usersToAdd.Count >0)
                        {
                            db.UserProfiles.AddRange(usersToAdd);
                            db.SaveChanges();
                        }

                        var allUsersInDatabase = db.UserProfiles.ToList();
                        currentUsersnamesInDatabase = allUsersInDatabase.Select(up => up.Username).ToList();
                        var firstUserFromDb = allUsersInDatabase.Single(u => u.Username == friendship.FirstUser.Username);
                        var secondUserFromDb = allUsersInDatabase.Single(u => u.Username == friendship.SecondUser.Username);



                        foreach (var image in imagesToAddFirstUser)
                        {
                            image.UserProfile = firstUserFromDb;
                        }

                        foreach (var image in imagesToAddSecondUser)
                        {
                            image.UserProfile = secondUserFromDb;
                        }

                        


                        var usersFriendship = new SocialNetwork.Models.Friendship
                        {
                            Approved = (bool)friendship.Approved,
                            ApprovedOn = friendship.FriendsSince,
                            FirstUser = firstUserFromDb,
                            SecondUser = secondUserFromDb,
                        };


                        db.Images.AddRange(imagesToAddFirstUser);
                        db.Images.AddRange(imagesToAddSecondUser);
                        db.Friendships.AddOrUpdate(usersFriendship);
                    }

                    db.SaveChanges();
                }
            }
        }

        public static void PostsImport()
        {

        }

    }
}
