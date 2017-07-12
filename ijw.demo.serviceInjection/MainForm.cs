using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ijw.demo.serviceInjection {
    public partial class MainForm : Form, IMainForm {
        private IServiceScope _scope;
        private IServiceScopeFactory _scopeFactory;
        private IServiceCollection _srvs;
        private IServiceProvider _prv;
        const int COUNT = 5000;

        public MainForm() {
            InitializeComponent();
        }

        public MainForm(IServiceCollection srvs, IServiceProvider serviceProvider, IServiceScope scope, IServiceScopeFactory scopes) : this() {
            this._srvs = srvs;
            this._scope = scope;
            this._scopeFactory = scopes;
            this._prv = serviceProvider;
        }

        private void MainForm_Load(object sender, EventArgs e) {
        }

        #region use scopeFactory
        IMockForm[] _temp_scopeFactory = new IMockForm[COUNT];
        private void buttonUseScopeFactory_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < _temp_scopeFactory.Length; i++) {
                this._scopeFactory.UseResourceInNewScope<IMockForm>((s, f) => {
                    f.ID = i;
                    f.FormClosed += (__, _) => {
                        s.Dispose();
                        Debug.WriteLine($"dispose scope:{s.GetHashCode().ToString()}");
                    };
                    _temp_scopeFactory[i] = f;
                    f.Show();
                });


                //var scope = this._scopeFactory.CreateScope();
                //IMockForm form = scope.ServiceProvider.GetService<IMockForm>();
                //if (form != null) {
                //    form.ID = i;
                //    form.FormClosed += (s, ee) => {
                //        scope.Dispose();
                //        Debug.WriteLine($"dispose scope:{scope.GetHashCode().ToString()}");
                //    };
                //    form.Show();
                //}
                //_temp_scopeFactory[i] = form;
            }
            sw.Stop();
            Debug.WriteLine("scopeFactory create " + COUNT.ToString() + " IMockForm :" + sw.Elapsed.TotalSeconds + "s.");

        }
        private void buttonCleanUseScopeFactory_Click(object sender, EventArgs e) {
            Clean(ref _temp_scopeFactory);
        }
        private void buttonCleanOneUseScopeFactory_Click(object sender, EventArgs e) {
            Clean(ref _temp_scopeFactory, 1);
        }
        #endregion

        #region use scope
        IMockForm[] _temp_scope = new IMockForm[COUNT];
        private void buttonUseScope_Click(object sender, EventArgs e) {
            if (this._scope == null) {
                MessageBox.Show("Scope 被回收");
                return;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < _temp_scope.Length; i++) {
                IMockForm form = this._scope.ServiceProvider.GetService<IMockForm>();
                //IMockForm form = this._prv.GetService<IMockForm>();
                if (form != null) {
                    form.ID = i;
                    form.Show();
                }
                _temp_scope[i] = form;
            }
            sw.Stop();
            Debug.WriteLine("scope create " + COUNT.ToString() + " IMockForm :" + sw.Elapsed.TotalSeconds + "s.");
        }
        private void buttonCleanScope_Click(object sender, EventArgs e) {
            Clean(ref _temp_scope, 1);
        }
        private void buttonCleanOneAndScope_Click(object sender, EventArgs e) {
            Clean(ref _temp_scope, 1);
            if (this._scope != null) {
                this._scope.Dispose();
                this._scope = null;
            }
            GC.Collect();
            GC.Collect();
        }
        #endregion

        #region use ServiceCollection
        IMockForm[] _fromServiceCollection = new IMockForm[COUNT];
        private void buttonUseServiceCollection_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < _fromServiceCollection.Length; i++) {
                IMockForm form = this._srvs.GetService<IMockForm>();
                if (form != null) {
                    form.ID = i;
                    form.Show();
                }
                _fromServiceCollection[i] = form;
            }
            sw.Stop();
            Debug.WriteLine("serviceCollection create " + COUNT.ToString() + " IMockForm :" + sw.Elapsed.TotalSeconds + "s.");
        }
        private void buttonCleanOneUseServiceCollection_Click(object sender, EventArgs e) {
            Clean(ref _fromServiceCollection, 1);
        }
        #endregion

        #region use new
        IMockForm[] _formNew = new IMockForm[COUNT];
        private void buttonUseNew_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < _formNew.Length; i++) {
                IMockForm form = new MockForm();
                if (form != null) {
                    form.ID = i;
                    form.FormClosed += (s, ee) => {
                        Debug.WriteLine($"form closed:{form.GetHashCode().ToString()}");
                    };
                    form.Show();
                }
                _formNew[i] = form;
            }
            sw.Stop();
            Debug.WriteLine("New create " + COUNT.ToString() + " IMockForm :" + sw.Elapsed.TotalSeconds + "s.");
        }
        private void buttonCleanOneNew_Click(object sender, EventArgs e) {
            Clean(ref _formNew, 1);
        }
        #endregion

        private void Clean(ref IMockForm[] temp, int count = 0) {
            if (temp == null) {
                return;
            }
            int j = 0;
            for (int i = 0; i < temp.Length; i++) {
                if (temp[i] != null) {
                    temp[i].Close();
                    temp[i] = null;
                    j++;
                }
                if (count != 0 && j >= count) {
                    break;
                }
            }

            GC.Collect();
            GC.Collect();
        }
    }
}
