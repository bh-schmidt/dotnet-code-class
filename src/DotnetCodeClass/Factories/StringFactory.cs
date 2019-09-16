using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass.Factories
{
    public static class StringFactory
    {
        private static Random random = new Random();

        public static string Randomize(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static IEnumerable<string> GenerateMany(int stringLenght, long arraySize)
        {
            for (long i = 0; i < arraySize; i++)
            {
                yield return Randomize(stringLenght);
            }
        }

        public static IEnumerable<string> ConcatWithIndex(string value, long arraySize)
        {
            for (long i = 0; i < arraySize; i++)
            {
                yield return value + i;
            }
        }
    }
}
