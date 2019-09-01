using DotnetCodeClass.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Language
{
    public static class LanguageForeach
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
            foreach (var value in strings)
            {
                sum += value.Length;
            }
            return sum;
        }

        public static IEnumerable<TimeSpan> RunManyWithoutConvertion(long times, IEnumerable<string> strings)
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
            long sum = 0;
            foreach (var value in strings)
            {
                sum += value.Length;
            }
            return sum;
        }
    }
}
