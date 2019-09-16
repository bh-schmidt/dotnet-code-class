using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCodeClass.Factories.Enumerables
{
    public static class ListFactory
    {
        public static List<long> Generate(long listSize)
        {
            var resultList = new List<long>();

            for (long numer = 0; numer < listSize; numer++)
            {
                resultList.Add(numer);
            }

            return resultList;
        }
    }
}
