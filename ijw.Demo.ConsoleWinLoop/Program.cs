using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleWinLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new Cmd();
            cmd.Start();
        }
    }
}