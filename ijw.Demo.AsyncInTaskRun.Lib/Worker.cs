using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.AsyncInTaskRun.Lib {
    public class Worker: WorkerBase {
        public override string DoWork() {
            return doWorkAsync().GetAwaiter().GetResult();
        }

        protected async Task<string> doWorkAsync() {
            string s = await Task.Run(() => {
                Thread.Sleep(3000);
                return "string from getString";
            });
            s += " from doWorkAsync";
            return s;
        }
    }
}