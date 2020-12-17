using System;

namespace Bjss.Library
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random = new Random();

        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
