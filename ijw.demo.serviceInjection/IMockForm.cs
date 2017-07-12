using System;
using System.Windows.Forms;

namespace ijw.demo.serviceInjection {
    public interface IMockForm : IDisposable //如果不是IDisposable，Dispose之后可以被GC回收
        {
        int ID { get; set; }

        event FormClosedEventHandler FormClosed;

        void Close();
        void Show();
    }
}