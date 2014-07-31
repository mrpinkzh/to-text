using System;

namespace ToText.Api.Infrastructure
{
    public static class CreateRandom
    {
        private static readonly Random Random = new Random();

        public static string String()
        {
            return Int().ToString();
        }

        public static int Int()
        {
            return Random.Next();
        }
    }
}