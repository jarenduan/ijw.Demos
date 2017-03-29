using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.MEF {
    public class MainClass {
        [ImportMany(typeof(IPlugin))]
        IEnumerable<IPlugin> plugins;

        public void SayHello() {
            Console.WriteLine("Hello world, I am Main Class.");

            foreach (var p in plugins) {
                p.SayHello();
            }
        }
    }
}