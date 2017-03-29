
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.WaitHandle {
    public class Demo {
        private AutoResetEvent are = new AutoResetEvent(false);

        public void StartLooping() {
            Task.Factory.StartNew(() => {
                int i = 0;
                Console.WriteLine("Loop begins...");
                while (i < 100) {
                    //多次waitOne, 需要多次Set();
                    Console.Write("Wait the 1st signal...");
                    are.WaitOne();
                    Console.WriteLine("got it!");
                    Thread.Sleep(500);
                    Console.Write("Wait the 2nd signal...");
                    are.WaitOne();
                    Console.WriteLine("got it!");
                    i++;
                    Console.WriteLine("Loop continues: iteration of " + i.ToString());
                }
                Console.WriteLine("Oh, too many times, loop ends.");
            });
        }

        public void ContinueLoop() {
            Console.Write("the signal's coming...");
            are.Set();
        }
    }
}
