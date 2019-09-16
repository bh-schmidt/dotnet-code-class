using DotnetCodeClass.Factories.Enumerables;

namespace DotnetCodeClass.Performance.IEnumerable.Generation.Language
{
    public class LanguageList
    {
        public static long TestForeach(long listSize)
        {
            var list = ListFactory.Generate(listSize);

            long sum = 0;

            foreach (var item in list)
            {
                sum += item;
            }

            return sum;
        }
    }
}
