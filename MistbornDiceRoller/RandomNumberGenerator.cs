using System;

namespace MistbornDiceRoller
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static Random _random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
