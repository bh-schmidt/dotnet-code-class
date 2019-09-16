using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass.Performance
{
    public class BasePerformanceTests : BaseTests
    {
        protected TimeSpan GetAverage(IEnumerable<TimeSpan> times)
        {
            var sum = TimeSpan.Zero;

            if (times == null)
            {
                return sum;
            }

            foreach (var item in times)
            {
                sum += item;
            }

            return sum / times.Count();
        }

        protected List<TimeSpan> Run(long times, Action action)
        {
            if (times < 1)
            {
                throw new ArgumentException(nameof(times));
            }

            if (action == null)
            {
                throw new ArgumentException(nameof(action));
            }

            long count = 0;

            List<TimeSpan> executionTimes = new List<TimeSpan>();

            while (count < times)
            {
                var firstDate = DateTime.Now;
                action();
                var lastDate = DateTime.Now;
                executionTimes.Add(firstDate - lastDate);

                checked
                {
                    count++;
                }
            }

            return executionTimes;
        }
    }
}
