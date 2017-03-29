using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijw.Demo.MEF {
    class Program {
        static void Main(string[] args) {
            MainClass main = new MainClass();

            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog("Plugins"));   //遍历运行目录下的Addin文件夹，查找所需的插件。
            var _container = new CompositionContainer(catalog);
            _container.ComposeParts(main);


            main.SayHello();


            Console.ReadLine();
        }
    }
}
