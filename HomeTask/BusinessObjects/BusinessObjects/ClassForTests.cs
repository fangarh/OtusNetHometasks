using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ClassForTests
    {
        [JsonInclude]
        public int SomeField1;
        [JsonInclude]
        private int _someField2;

        public string SomeText { get; set; }
        public double SomeDouble { get; set; }

        public ClassForTests()
        {
            SomeField1 = 1;
            _someField2 = 3;
            SomeText = "hello";
            SomeDouble = 2.222;
        }

        public int GetSomeField2() => _someField2;
    }
}
