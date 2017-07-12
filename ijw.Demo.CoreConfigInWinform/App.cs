using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ijw.Demo.CoreConfigInWinform {
    public class App {
        private readonly IMainForm _mainForm;

        public App(IMainForm mainForm) {
            this._mainForm = mainForm;
        }
        public void Run() {
            Application.Run(this._mainForm as Form);
        }
    }
}
