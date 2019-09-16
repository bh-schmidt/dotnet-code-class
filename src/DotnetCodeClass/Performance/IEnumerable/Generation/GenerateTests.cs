using DotnetCodeClass.Factories.Enumerables;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace DotnetCodeClass.Performance.IEnumerable.Generation
{
    public class GenerateTests : BasePerformanceTests
    {
        [Test]
        public void Test()
        {
            var listSize = 10000;
            var times = 10000;

            var languageYieldResults = Run(times, () => EnumerableFactory.GenerateYield(listSize).Last());
            var languageListResults = Run(times, () => ListFactory.Generate(listSize).Last());

            var languageYieldAverage = GetAverage(languageYieldResults);
            var languageListAverage = GetAverage(languageListResults);

            Debug.WriteLine(listSize);
            Debug.WriteLine(languageYieldAverage);
            Debug.WriteLine(languageListAverage);
        }
    }
}
