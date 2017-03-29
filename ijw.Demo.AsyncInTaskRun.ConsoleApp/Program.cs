using ijw.Demo.AsyncInTaskRun.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.AsyncInTaskRun.ConsoleApp {
    class Program {
        static void Main(string[] args) {
            Worker w = new Worker();
            Console.WriteLine("ConsoleApp Main Start:");
            Console.WriteLine("ConsoleApp Main use worker:");
            string s = w.DoWork();
            Console.WriteLine($"ConsoleApp Main s = {s}");

            Console.WriteLine("ConsoleApp Main use TaskWorker:");
            TaskWorker tw = new TaskWorker();
            s = tw.DoWork();
            Console.WriteLine($"ConsoleApp Main s = {s??"NULL"}");
            Console.WriteLine("ConsoleApp Main Ends");
            Console.ReadLine();
        }
    }
}
