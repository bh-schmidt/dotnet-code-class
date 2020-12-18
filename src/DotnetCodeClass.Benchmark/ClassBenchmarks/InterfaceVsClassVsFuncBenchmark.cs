using DotnetCodeClass.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DotnetCodeClass.Benchmark.ClassBenchmarks
{
    public class InterfaceVsClassVsFuncBenchmark : IBenchmark
    {
        public bool IsEnabled()
        {
            return true;
        }

        private delegate int MyDelegate(List<int> list, int number);

        private readonly MyDelegate propFunc = (list, number) => number + list.Count;


        public void Run()
        {
            var numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ISample iSample = GetInterface();
            Sample sample = new Sample();

            var tests = 5;
            var averages = 5;
            var forCount = 100_000_000;

            Func<List<int>, int, int> localFunc = (list, number) => number + list.Count;
            var propLocalFunc = propFunc;

            Utils.Measure("Class", tests, averages, () =>
            {
                for (int i = 0; i < forCount; i++)
                    sample.Process(numberList, i);
            });

            Utils.Measure("Method", tests, averages, () =>
            {
                for (int i = 0; i < forCount; i++)
                    Method(numberList, i);
            });

            Utils.Measure("Local Func", tests, averages, () =>
            {
                for (int i = 0; i < forCount; i++)
                    localFunc(numberList, i);
            });

            Utils.Measure("Prop Func", tests, averages, () =>
            {
                for (int i = 0; i < forCount; i++)
                    propFunc(numberList, i);
            });

            Utils.Measure("Local Prop Func", tests, averages, () =>
            {
                for (int i = 0; i < forCount; i++)
                    propLocalFunc(numberList, i);
            });

            Utils.Measure("Interface", tests, averages, () =>
            {
                for (int i = 0; i < forCount; i++)
                    iSample.Process(numberList, i);
            });
        }

        private int Method(List<int> list, int number) => number + list.Count;

        private ISample GetInterface()
        {
            var rd = new Random();
            var number = rd.Next(int.MinValue, int.MaxValue);
            if (number == 0)
                return new Sample2();

            return new Sample();
        }
    }

    interface ISample { int Process(List<int> list, int number); }
    class Sample : ISample
    {
        public int Process(List<int> list, int number)
        {
            return number + list.Count;
        }
    }
    class Sample2 : ISample
    {
        public int Process(List<int> list, int number)
        {
            throw new NotImplementedException();
        }
    }

    class Sample3 : ISample
    {
        public int Process(List<int> list, int number)
        {
            throw new NotImplementedException();
        }
    }
}
