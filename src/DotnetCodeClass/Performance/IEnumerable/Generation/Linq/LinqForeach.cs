using DotnetCodeClass.Factories.Enumerables;

namespace DotnetCodeClass.Performance.IEnumerable.Generation.Linq
{
    public static class LinqForeach
    {
        public static long TestForeach(long listSize)
        {
            var list = ListFactory.Generate(listSize);

            long sum = 0;

            list.ForEach(item =>
            {
                sum += item;
            });

            return sum;
        }
    }
}
