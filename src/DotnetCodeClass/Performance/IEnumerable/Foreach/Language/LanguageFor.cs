using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Language
{
    public class LanguageFor
    {
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
