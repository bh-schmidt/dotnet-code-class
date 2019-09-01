using System;
using System.Collections.Generic;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Language
{
    public class LanguageWhile
    {
        public static IEnumerable<TimeSpan> RunWithEnumerator(long times, IEnumerable<string> strings)
        {
            for (long i = 0; i < times; i++)
            {
                var initialDate = DateTime.Now;
                TestIEnumerable(strings);
                var endDate = DateTime.Now;
                yield return endDate - initialDate;
            }
        }

        public static long TestIEnumerable(IEnumerable<string> strings)
        {
            var enumerator = strings.GetEnumerator();
            long sum = 0;
            while (enumerator.MoveNext())
            {
                sum += enumerator.Current.Length;
            }
            return sum;
        }
    }
}
