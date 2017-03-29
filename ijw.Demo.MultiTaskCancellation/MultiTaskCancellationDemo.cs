using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ijw.Demo.MultiTaskCancellation {
    public class MultiTaskCancellationDemo {
        private CancellationTokenSource cts;
        private CancellationToken ct;
        public void StartTask() {
            this.cts = new CancellationTokenSource();
            this.ct = this.cts.Token;
            Task.Factory.StartNew(() => {
                Debug.WriteLine("Start listening.");
                //Listen(this.ct);
                Listen();
            }, this.ct);
            Task.Factory.StartNew(() => {
                Debug.WriteLine("Start event notifying loop.");
                Notify(this.ct);
            }, this.ct);
        }

     
        private void Listen() {
        //private void Listen(CancellationToken cancellationToken) {
            int i = 0;
            while (true) {
                Thread.Sleep(1000);
                i++;
                if (this.ct.IsCancellationRequested) {
               // if (cancellationToken.IsCancellationRequested) {
                    break;
                } 
                Console.WriteLine("Notify" + i.ToString());
            }
        }
        private void Notify(CancellationToken cancellationToken) {
            int i = 0;
            while (true) {
                Thread.Sleep(1000);
                i++;
                if (cancellationToken.IsCancellationRequested) {
                    break;
                }
                Console.WriteLine("Listen" + i.ToString());
            }
        }

        public void StopTask() {
            this.cts.Cancel();
        }
    }
}
