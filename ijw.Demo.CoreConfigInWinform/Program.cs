using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ijw.Demo.CoreConfigInWinform {
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
            //设定配置文件
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("app-settings.json", false, true)
                                    .Build();
            //使用Options
            serviceCollection.AddOptions();

            //从配置文件的一个section生成一个强类型配置MainFormSettings
            serviceCollection.Configure<MainFormSettings>(configuration.GetSection("MainForm"));

            //把所有需要MainFormSettings实例的地方，都用下面的方式获取
            serviceCollection.AddTransient(srv => srv.GetService<IOptionsSnapshot<MainFormSettings>>().Value);

            // add app
            serviceCollection.AddTransient<App>();
            serviceCollection.AddTransient<IMainForm, MainForm>();
        }
    }
}
