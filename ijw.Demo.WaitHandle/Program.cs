using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.WaitHandle {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Press any key to send signal. Ctrl-C to exit.");
            Demo d = new Demo();
            //多次紧凑的Set(), 也只能释放一次wait
            //d.ContinueLoop();
            //d.ContinueLoop();
            //在开始前set()就有效, 相当于将are初始化成true
            //d.ContinueLoop();
            d.StartLooping();
            Thread.Sleep(1000);

            while(Console.ReadKey(true).Key != ConsoleKey.Enter) {
                d.ContinueLoop();
            }
        }
    }
}
