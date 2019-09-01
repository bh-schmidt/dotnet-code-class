using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Language
{
    public class LanguageFor
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
            for (int i = 0; i < strings.Count; i++)
            {
                sum += strings[i].Length;
            }
            return sum;
        }
    }
}
