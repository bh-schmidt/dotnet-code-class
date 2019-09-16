using DotnetCodeClass.Factories;
using DotnetCodeClass.Performance.IEnumerable.Foreach.Language;
using DotnetCodeClass.Performance.IEnumerable.Foreach.Linq;
using NUnit.Framework;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach
{
    public class ForeachTests : BasePerformanceTests
    {
        [Test]
        public void TestPerformance()
        {
            var listSize = 10000;
            var times = 10000;
            var strings = StringFactory.ConcatWithIndex("abcde", listSize).ToList();

            var languageForResults = Run(times, () => LanguageFor.TestList(strings));
            var linqForEachResults = Run(times, () => LinqForeach.TestList(strings));
            var languageForEachResults = Run(times, () => LanguageForeach.TestList(strings));
            var languageWhileResults = Run(times, () => LanguageWhile.Test(strings));

            var mediaLanguageFor = GetAverage(languageForResults);
            var mediaLinqForEach = GetAverage(linqForEachResults);
            var mediaLanguageForEach = GetAverage(languageForEachResults);
            var mediaLanguageWhile = GetAverage(languageWhileResults);

            Debug.WriteLine($"listSize: {listSize}");
            Debug.WriteLine($"language for: {mediaLanguageFor}");
            Debug.WriteLine($"linq foreach: {mediaLinqForEach}");
            Debug.WriteLine($"language foreach: {mediaLanguageForEach}");
            Debug.WriteLine($"language While: {mediaLanguageWhile}");
        }

        [Test]
        public void TestPerformanceWithLinqConvertion()
        {
            var listSize = 10000;
            var times = 10000;
            var strings = StringFactory.ConcatWithIndex("abcde", listSize).ToArray();
            
            var languageWhileResults = Run(times, () => LanguageWhile.Test(strings));
            var languageForEachResults = Run(times, () => LanguageForeach.TestIEnumerable(strings));
            var linqForEachResults = Run(times, () => LinqForeach.TestIEnumerable(strings));

            var mediaLanguageWhile = GetAverage(languageWhileResults);
            var mediaLanguageForEach = GetAverage(languageForEachResults);
            var mediaLinqForEach = GetAverage(linqForEachResults);

            Debug.WriteLine($"listSize: {listSize}");
            Debug.WriteLine($"Language While: {mediaLanguageWhile}");
            Debug.WriteLine($"Language ForEach: {mediaLanguageForEach}");
            Debug.WriteLine($"Linq ForEach: {mediaLinqForEach}");
        }
    }
}
