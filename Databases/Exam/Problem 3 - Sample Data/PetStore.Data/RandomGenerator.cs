namespace PetStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomGenerator();
                }

                return instance;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            return new String(Letters.OrderBy(l => Guid.NewGuid()).Take(length).ToArray());
        }

        
        public DateTime GetRandomDate(DateTime from, DateTime to)
        {
            Random rnd = new Random();
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
