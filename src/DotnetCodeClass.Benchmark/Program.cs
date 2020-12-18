using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DotnetCodeClass.Benchmark
{
    public class Program
    {
        static void Main()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            var benchmarks = types.Where(e => !e.IsInterface && typeof(IBenchmark).IsAssignableFrom(e));
            foreach (var benchmarkType in benchmarks)
            {
                var benchmark = (IBenchmark)Activator.CreateInstance(benchmarkType);
                if (benchmark.IsEnabled())
                    benchmark.Run();
            }
        }
    }
}
