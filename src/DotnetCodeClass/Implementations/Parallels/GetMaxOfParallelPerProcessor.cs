using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCodeClass.Implementations.Parallels
{
    public class GetMaxOfParallelPerProcessor : BaseTests
    {
        const long times = 1000;
        [Test]
        public void GetMaxOfParallelism()
        {
            long maxOfParallelism = 0;
            Parallel.For(0, times, index =>
            {
                if (maxOfParallelism > 0)
                {
                    return;
                }

                Thread.Sleep(FirstWait());
                maxOfParallelism++;
            });

        }

        private TimeSpan FirstWait()
        {
            return TimeSpan.FromSeconds(5);
        }
    }
}
