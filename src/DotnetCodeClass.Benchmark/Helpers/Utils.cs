using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DotnetCodeClass.Helpers
{
    public static class Utils
    {
        public static List<TimeSpan> Measure(string? name, int averageQuantity, int times, Action action)
        {
            Console.WriteLine();
            if (!string.IsNullOrEmpty(name))
                Console.WriteLine($"Benchmark: {name}");

            var averages = new List<TimeSpan>();
            for (int i = -2; i < averageQuantity; i++)
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                var average = Measure(times, action);
                if (i > -1)
                {
                    Console.WriteLine($"Average {i + 1}: {average}");
                    averages.Add(average);
                }
            }

            var lastAverage = Average(averages);
            Console.WriteLine($"All: {lastAverage}");

            return averages;
        }
        public static TimeSpan Measure(int times, Action action)
        {
            var list = new List<TimeSpan>();
            var sw = new Stopwatch();
            for (int i = 0; i < times; i++)
            {
                sw.Start();
                action();
                sw.Stop();
                list.Add(sw.Elapsed);
                sw.Reset();
            }

            return Average(list);
        }

        public static TimeSpan Average(List<TimeSpan> timeSpans)
        {
            var doubleTicks = timeSpans.Average(x => x.Ticks);
            var longTicks = Convert.ToInt64(doubleTicks);

            return TimeSpan.FromTicks(longTicks);
        }
    }
}
