using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.LoopReferenceJsonSerialization {
    public class Bar {
        public string Name { get; set; }
        public int Age { get; set; }
        public Bar Friend { get; set; }
    }
}
