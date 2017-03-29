using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.MEF {
    [Export(typeof(IPlugin))]
    public class PluginB : IPlugin {
        public string Name { get; set; } = "Plugin B";

        public void SayHello() {
            Console.WriteLine("Hi, I'm Plugin B");
        }
    }
}
