using NUnit.Framework;
using System;

namespace DotnetCodeClass.Test
{
    public class DotNetClassReader
    {
        [Test]
        public void ReadFile()
        {
            var file = @"
using System;
using System.Text;

namespace DotnetCodeClass.Test
{
    public class DotNetClassReader
    {
        public void ReadFile()
        {
            var file = @"""";
        }

        public bool ReadNext() { return 1 == 2; }

        public void ReadUsing() { }

        public void ReadClass() { }

        public void ReadClassMember() { }
    }
}
";            
            var reader = new ClassReader(file);
            while (reader.CanRead)
            {
                var result = reader.ReadNext();

                if (result == "using")
                {
                    //read imports
                    result = reader.ReadUntilSemiColumn();
                    continue;
                }

                if (result is "public" or "internal" or "protected" or "private")
                {
                    //read members
                }
            }
        }

        public void ReadNext() { }

        public void ReadUsing() { }

        public void ReadClass() { }

        public void ReadClassMember() { }
    }
}
