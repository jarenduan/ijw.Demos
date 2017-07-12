using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ijw.demo.serviceInjection {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            //创建窗体前必须先执行
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create service collection
            var serviceCollection = new ServiceCollection();

            //配置服务
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // 启动App
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection) {
            //演示注入四种基础服务
            serviceCollection.AddSingleton(serviceCollection); //注入服务集合
            serviceCollection.AddTransient(srv => srv.GetService<IServiceScopeFactory>());  //注入服务Scope工厂
            serviceCollection.AddTransient(srv => srv.CreateScope()); //注入新的scope
            serviceCollection.AddTransient(srv => serviceCollection.BuildServiceProvider());

            // add app
            serviceCollection.AddTransient<App>();
            serviceCollection.AddTransient<IMainForm, MainForm>();
            serviceCollection.AddTransient<IMockForm, MockForm>();
        }
    }
}
