using DotnetCodeClass.Factories.Enumerables;

namespace DotnetCodeClass.Performance.IEnumerable.Generation.Language
{
    public class LanguageYield
    {
        public static long TestForeach(long listSize)
        {
            var list = EnumerableFactory.GenerateYield(listSize);

            long sum = 0;

            foreach (var item in list)
            {
                sum += item;
            }

            return sum;
        }
    }
}
