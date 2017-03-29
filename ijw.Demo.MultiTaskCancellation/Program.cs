using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.MultiTaskCancellation {
    class Program {
        static void Main(string[] args) {
            MultiTaskCancellationDemo demo = new MultiTaskCancellationDemo();
            demo.StartTask();
            Console.WriteLine("Task start. Enter to stop task.");
            Console.ReadLine();
            demo.StopTask();
            Console.WriteLine("Stopped.");
            Console.WriteLine("Enter to exit..");
            Console.ReadLine();
        }
    }
}
