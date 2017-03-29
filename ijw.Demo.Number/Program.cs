using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ijw.Demo.Number {
    class Program {
        static void Main(string[] args) {
            Int64 i = Int64.MaxValue;
            Int64 j = Int64.MaxValue;

            double ii = i * Math.Pow(10, 19);
            BigInteger m = new BigInteger(ii);
            BigInteger n = new BigInteger(j);
            m = m + n;

            decimal iid = (decimal)Math.Pow(10, 19);
            iid = (decimal)i * iid;

            Console.WriteLine(m.ToString());
            Console.ReadLine();
        }
    }
}
