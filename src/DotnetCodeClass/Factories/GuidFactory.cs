using System;
using System.Collections.Generic;

namespace DotnetCodeClass.Factories
{
    public static class GuidFactory
    {
        public static IEnumerable<Guid> GenerateMany(long size)
        {
            for (long i = 0; i < size; i++)
            {
                yield return Guid.NewGuid();
            }
        }
    }
}
