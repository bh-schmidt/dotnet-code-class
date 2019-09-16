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
        public static long TestList(List<string> strings)
        {
            long sum = 0;
            foreach (var value in strings)
            {
                sum += value.Length;
            }
            return sum;
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
