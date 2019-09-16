using System.Collections.Generic;

namespace DotnetCodeClass.Factories.Enumerables
{
    public class EnumerableFactory
    {
        public static IEnumerable<long> GenerateYield(long listSize)
        {
            for (long numer = 0; numer < listSize; numer++)
            {
                yield return numer;
            }
        }
    }
}
