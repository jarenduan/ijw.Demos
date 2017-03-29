using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace ijw.Demo.MEF {
    [Export(typeof(IPlugin))]
    public class PluginA : IPlugin {
        public string Name { get; set; } = "A";

        public void SayHello() {
            Console.WriteLine("Hello world, I'm A");
        }
    }
}
