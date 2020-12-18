using NUnit.Framework;

namespace DotnetCodeClass.Implementations.Types
{
    public class GetTypeHashcode
    {
        [Test]
        public void TestWithString()
        {
            string a = "";
            string b = "";

            var aType = a.GetType();
            var bType = b.GetType();

            var aHash = aType.GetHashCode();
            var bHash = bType.GetHashCode();

            var equals = aType == bType;
        }

        [Test]
        public void TestWithEqualClasses()
        {
            A a = new A { };
            B b = new B { };

            var aType = a.GetType();
            var bType = b.GetType();

            var aHash = aType.GetHashCode();
            var bHash = bType.GetHashCode();

            var equals = aType == bType;
        }

        [Test]
        public void TestWithDynamic()
        {
            var a = new { x = "" };
            var b = new { x = "" };
            var c = new { z = "" };

            var aType = a.GetType();
            var bType = b.GetType();
            var cType = c.GetType();

            var aHash = aType.GetHashCode();
            var bHash = bType.GetHashCode();
            var cHash = cType.GetHashCode();

            var firstEquals = aType == bType;
            var secondEquals = aType == cType;

        }
    }

    class A { public int Property { get; set; } }
    class B { public int Property { get; set; } }
}
