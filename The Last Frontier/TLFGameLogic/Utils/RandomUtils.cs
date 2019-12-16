using System;

namespace TLFGameLogic.Utils
{
    public class RandomUtils
    {
        private static readonly Random _random = new Random();

        public static float NextGauss(float center, float sigma)
        {
            return (float) (center + sigma * (_random.NextDouble() + _random.NextDouble() + _random.NextDouble() +
                                              _random.NextDouble() - 2) / 2);
        }
    }
}