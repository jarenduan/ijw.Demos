using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.LoopReferenceJsonSerialization {
    public class Foo {
        public string Name { get; set; }
        public int Age { get; set; }
        public Foo Child { get; set; }
        public Foo Parent { get; set; }
    }
}
