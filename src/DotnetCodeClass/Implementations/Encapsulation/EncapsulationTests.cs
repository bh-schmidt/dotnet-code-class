using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCodeClass.Implementations.Encapsulation
{
    public class EncapsulationTests
    {
        [Test]
        public void Test()
        {
            var test = new TestClass();

        }

        internal class TestClass
        {
            public string? testString;

            public string? TestString
            {
                get
                {
                    testString ??= "";
                    return testString;
                }
                set { testString = value; }
            }

        }
    }
}
