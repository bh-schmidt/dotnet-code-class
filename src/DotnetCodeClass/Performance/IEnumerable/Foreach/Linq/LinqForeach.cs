using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Linq
{
    public static class LinqForeach
    {
        public static IEnumerable<TimeSpan> RunMany(long times, List<string> strings)
        {
            for (long i = 0; i < times; i++)
            {
                var initialDate = DateTime.Now;
                TestList(strings);
                var endDate = DateTime.Now;
                yield return endDate - initialDate;
            }
        }

        public static long TestList(List<string> strings)
        {
            long sum = 0;
            strings.ForEach(value =>
            {
                sum += value.Length;
            });
            return sum;
        }

        public static IEnumerable<TimeSpan> RunManyWithConvertion(long times, IEnumerable<string> strings)
        {
            for (long i = 0; i < times; i++)
            {
                GC.Collect();
                var initialDate = DateTime.Now;
                TestIEnumerable(strings);
                var endDate = DateTime.Now;
                yield return endDate - initialDate;
            }
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
