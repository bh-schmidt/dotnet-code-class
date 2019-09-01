using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCodeClass
{
    [TestFixture]
    public class BaseTest
    {
        protected TimeSpan GetMedia(List<TimeSpan> times)
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
    }
}
