using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.AsyncInTaskRun.Lib {
    public class TaskWorker : WorkerBase {
        public override string DoWork() {
            string s = null;
            Task.Run(async () => {
                s = await getString();
                s += " from doWorkInTaskRun";
                Console.WriteLine($"Task Ended. s = {s}");
            });
            Console.WriteLine("Task Started.");
            return s;
        }
        private async Task<string> getString() {
            return await Task.Run(() => {
                Thread.Sleep(3000);
                return "string from getString";
            });
        }
    }
}
