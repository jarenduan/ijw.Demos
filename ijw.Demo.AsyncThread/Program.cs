using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.AsyncThread {
    class Program {
        private static int count = 0;
        private static string LargeString = string.Empty;
        private static Random r = new Random();

        static void Main(string[] args) {
            Console.WriteLine("Main Start...");
            while (count < 100) {
                count++;
                dosomeIO(count);
            }
            Console.WriteLine();
            count = 0;
            while (count < 100) {
                count++;
                Thread.Sleep(15);
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " do work " + count.ToString());
            }
            Console.WriteLine("Main End");
            Console.ReadLine();
        }

        private async static void dosomething(int i) {
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " start async work " + count.ToString());

            Random r = new Random();
            var times = r.Next(1, 5);
            await Task.Delay(1000 * times);

            Console.WriteLine("                             Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " finish work " + i.ToString());
        }

        private async static void dosomeIO(int i) {
            int oldThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread " + oldThread.ToString() + " start async work " + count.ToString() + " with string of " + LargeString.Length + "...");

            using (StreamWriter sw = new StreamWriter("file" + i.ToString() + ".txt", false)) {
                await sw.WriteLineAsync(buildString());
            }

            //下面的代码，根据完成task的时间，有可能是在另外的线程中进行的
            //即，await 前后的代码被分成了两个部分，所等待的操作如果没有马上完成就立即返回，待完成后抓一个线程继续进行后面的代码
            //await内部在有必要的时候使用线程池，对异步开发者屏蔽了线程调用的细节
            int newThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("                             Thread " + newThread.ToString() + " finish async work " + i.ToString() + ". " + ((oldThread == newThread) ? String.Empty : "(Different thread)"));

            string buildString()
            {
                StringBuilder sb = new StringBuilder();
                var length = r.Next(4000);
                for (int j = 0; j < length; j++) {
                    sb.Append(j.ToString());
                }
                LargeString = sb.ToString();
                return LargeString;
            }
        }
    }
}