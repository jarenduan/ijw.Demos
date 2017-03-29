using System;

namespace ijw.Demo.Abilities {
    class Program {
        static void Main(string[] args) {
            nodebase nb = new nodebase();
            nb.Name = "Node";

            Connection c = new Connection();
            nb.AddRecieveConnection(c);
            //nb.RemoveRecieve(null);

            nb = null;

            GC.Collect(0);

            nodebase nb1 = new nodebase();
            nb1.Name = "name1";
            Console.WriteLine(RecievableImpl.GetInConnections(nb1).ToString());

            Console.ReadLine();
        }
    }
}
