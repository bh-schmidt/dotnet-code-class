using DotnetCodeClass.Factories;
using DotnetCodeClass.Performance.IEnumerable.Foreach.Language;
using DotnetCodeClass.Performance.IEnumerable.Foreach.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Foreach
{
    public class ForeachTests : BaseTest
    {
        [Test]
        public void TestPerformance()
        {
            var listSize = 100000;
            var iterations = 1000;
            var strings = StringFactory.ConcatIndexWith("abcde", listSize).ToList();
            
            var linqForEachResults = LinqForeach.RunMany(iterations, strings).ToList();
            var languageForResults = LanguageFor.RunMany(iterations, strings).ToList();
            var languageForEachResults = LanguageForeach.RunMany(iterations, strings).ToList();
            var languageWhileResults = LanguageWhile.RunWithEnumerator(iterations, strings.ToImmutableArray()).ToList();

            var mediaLinqForEach = GetMedia(linqForEachResults);
            var mediaLanguageFor = GetMedia(languageForResults);
            var mediaLanguageForEach = GetMedia(languageForEachResults);
            var mediaLanguageWhile = GetMedia(languageWhileResults);

            Debug.WriteLine($"listSize: {listSize}");
            Debug.WriteLine($"linq foreach: {mediaLinqForEach}");
            Debug.WriteLine($"language for: {mediaLanguageFor}");
            Debug.WriteLine($"language foreach: {mediaLanguageForEach}");
            Debug.WriteLine($"Language While: {mediaLanguageWhile}");
        }

        [Test]
        public void TestPerformanceWithLinqConvertion()
        {
            var listSize = 100000;
            var iterations = 1000;
            var strings = StringFactory.ConcatIndexWith("abcde", listSize).ToArray();

            var linqForEachResults = LinqForeach.RunManyWithConvertion(iterations, strings).ToList();
            var languageWhileResults = LanguageWhile.RunWithEnumerator(iterations, strings).ToList();
            var languageForEachResults = LanguageForeach.RunManyWithoutConvertion(iterations, strings).ToList();

            var mediaLinqForEach = GetMedia(linqForEachResults);
            var mediaLanguageWhile = GetMedia(languageWhileResults);
            var mediaLanguageForEach = GetMedia(languageForEachResults);

            Debug.WriteLine($"listSize: {listSize}");
            Debug.WriteLine($"Linq ForEach: {mediaLinqForEach}");
            Debug.WriteLine($"Language While: {mediaLanguageWhile}");
            Debug.WriteLine($"Language ForEach: {mediaLanguageForEach}");
        }
    }
}
