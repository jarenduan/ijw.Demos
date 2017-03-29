using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.AsyncCatch {
    class Program {
        static void Main(string[] args) {
            worker w = new worker();
            w.Start();
            Console.WriteLine("Main Ends...");
            Console.ReadLine();
        }
    }
}
