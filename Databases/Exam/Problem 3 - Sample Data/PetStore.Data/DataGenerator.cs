namespace PetStore.Data
{
    using System.Linq;
    using System.Collections.Generic;
using System;

    public static class DataGenerator
    {
        private static RandomGenerator randomGenerator = RandomGenerator.Instance;

        public static void GenerateAllData()
        {
            using (var data = new PetStoreEntities())
            {
                
                data.Configuration.AutoDetectChangesEnabled = false;
                GenerateCountries(data);
                GenerateSpecies(data);
                GeneratePets(data);
                GenerateCategories(data);
                GenerateProducts(data);
                data.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        private static void GenerateCountries(PetStoreEntities data)
        {
            const int numberOfCountriesToGenerate = 20;
            List<Country> addedCountries = new List<Country>();

            Console.Write("Adding countries:");
            for (int i = 0; i < numberOfCountriesToGenerate; i++)
            {
                addedCountries.Add(new Country
                {
                    Name = randomGenerator.GetRandomString(randomGenerator.GetRandomNumber(5, 50))
                });

                Console.Write(".");
            }
            Console.WriteLine();

            data.Countries.AddRange(addedCountries);
            data.SaveChanges();
            Console.WriteLine("Countries added");
        }

        private static void GenerateSpecies(PetStoreEntities data)
        {
            List<Species> addedSpecies = new List<Species>();
            var countriesIds = data.Countries.Select(c => c.Id).ToList();

            Console.Write("Adding species:");

            foreach (var country in countriesIds)
            {
                int numberOfSpeciesToAdd = randomGenerator.GetRandomNumber(1, 9);

                for (int i = 0; i < numberOfSpeciesToAdd; i++)
                {
					addedSpecies.Add(new Species
                    {
						Name = randomGenerator.GetRandomString(randomGenerator.GetRandomNumber(5,50)),
						CountryId = country
                    });

                    Console.Write(".");
                }
            }

            Console.WriteLine();

            data.Species.AddRange(addedSpecies);
            data.SaveChanges();
            Console.WriteLine("Species added");
        }

        private static void GeneratePets(PetStoreEntities data)
        {
            List<Pet> addedPets = new List<Pet>();
            var species = data.Species.Select(s => s.Id).ToList();
            var colors = data.Colors.Select(c => c.Id).OrderBy(c => c).ToList() ;

            Console.Write("Adding pets:");
            foreach (var specie in species)
            {
                var numberOfPetsToAdd = randomGenerator.GetRandomNumber(40, 60);
                for (int i = 0; i < numberOfPetsToAdd; i++)
                {
                    addedPets.Add(new Pet
                    {
                        SpeciesId = specie,
                        Price = randomGenerator.GetRandomNumber(5, 2500),
                        BirthDateTime = randomGenerator.GetRandomDate(new DateTime(2010, 1, 1), DateTime.Now.AddDays(-60)),
                        ColorId = randomGenerator.GetRandomNumber(colors.First(), colors.Last())
                    });
                }

                Console.Write(".");
            }
            Console.WriteLine();

            data.Pets.AddRange(addedPets);
            data.SaveChanges();
            Console.WriteLine("Pets added");
        }

        private static void GenerateCategories(PetStoreEntities data)
        {
            List<Category> addedCategories = new List<Category>();
            const int numberOfCategoriesToAdd = 50;

            Console.Write("Adding categories:");
            for (int i = 0; i < numberOfCategoriesToAdd; i++)
            {
                addedCategories.Add(new Category {
                    Name = randomGenerator.GetRandomString(randomGenerator.GetRandomNumber(5, 20))
                });
                Console.Write(".");
            }

            Console.WriteLine();

            data.Categories.AddRange(addedCategories);
            data.SaveChanges();
            Console.WriteLine("Categories added");
        }

        private static void GenerateProducts(PetStoreEntities data)
        {
            var categories = data.Categories.Select(c => c.Id).ToList();
            var species = data.Species.ToList();
            List<Product> addedProducts = new List<Product>();

            const int minSpeciesCount = 2;
            const int maxSpeciesCount = 10;

            Console.Write("Adding products:");
            foreach (var category in categories)
            {
                int numberOfProductsToAdd = randomGenerator.GetRandomNumber(350, 450);

                for (int i = 0; i < numberOfProductsToAdd; i++)
                {
                    addedProducts.Add(new Product
                    {
                        Name = randomGenerator.GetRandomString(randomGenerator.GetRandomNumber(5,25)),
                        CategoryId = category,
                        Price = randomGenerator.GetRandomNumber(10,1000),
                        Species = species
                            .OrderBy(s => Guid.NewGuid())
                            .Take(randomGenerator.GetRandomNumber(minSpeciesCount,maxSpeciesCount))
                            .ToList()
                    });

                    Console.Write(".");
                }
            }

            Console.WriteLine();

            data.Products.AddRange(addedProducts);
            data.SaveChanges();
            Console.WriteLine("Products added");
        }
    }
}
