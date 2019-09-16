using System;
using System.Collections.Generic;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach.Language
{
    public class LanguageWhile
    {
        public static long Test(IEnumerable<string> strings)
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
