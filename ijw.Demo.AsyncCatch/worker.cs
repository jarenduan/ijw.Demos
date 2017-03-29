using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.AsyncCatch {
    public class worker {
        public void Start() {
            //没使用await
            try {
                Console.WriteLine("Start task...");
                start();
            }
            //无法捕捉
            catch (Exception) {
                throw;
            }
            Console.WriteLine("Back to Main");
        }

        private async Task start() {
            try {
                Task t = Task.Run(() => {
                    Console.WriteLine("[Task] Wait 5s...");
                    Thread.Sleep(5000);
                    Console.WriteLine("[Task] Do async task...something wrong!");
                    throw new Exception("[Task] Exception!");
                });
                //使用await
                await t;
                //异常抛出, 下面不会执行
                Console.WriteLine("Wait 2s.");
                Thread.Sleep(2000);
            }
            //可以捕捉 
            catch (Exception ae) {
                Console.WriteLine("Catch: " + ae.Message);
            }
            Console.WriteLine("Some cleaning job.");
        }
    }
    }

