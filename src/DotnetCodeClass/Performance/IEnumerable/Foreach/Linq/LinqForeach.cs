using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Linq
{
    public static class LinqForeach
    {
        public static long TestList(List<string> strings)
        {
            long sum = 0;
            strings.ForEach(value =>
            {
                sum += value.Length;
            });
            return sum;
        }

        public static long TestIEnumerable(IEnumerable<string> strings)
        {
            long sum = 0;
            strings.ToList().ForEach(value =>
            {
                sum += value.Length;
            });
            return sum;
        }
    }
}
