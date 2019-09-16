using DotnetCodeClass.Performance.IEnumerable.Generation.Language;
using DotnetCodeClass.Performance.IEnumerable.Generation.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Generation
{
    public class GenerateAndForeachTests : BasePerformanceTests
    {
        [Test]
        public void Test()
        {
            var listSize = 10000;
            var times = 10000;

            var languageYieldResults = Run(times, () => LanguageYield.TestForeach(listSize));
            var linqResults = Run(times, () => LinqForeach.TestForeach(listSize));
            var languageListResults = Run(times, () => LanguageList.TestForeach(listSize));

            var languageYieldAverage = GetAverage(languageYieldResults);
            var linqAverage = GetAverage(linqResults);
            var languageListAverage = GetAverage(languageListResults);

            Debug.WriteLine(listSize);
            Debug.WriteLine(languageYieldAverage);
            Debug.WriteLine(linqAverage);
            Debug.WriteLine(languageListAverage);
        }
    }
}
