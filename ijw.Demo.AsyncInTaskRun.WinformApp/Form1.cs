using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ijw.Demo.AsyncInTaskRun.WinformApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string s = doWork();
            this.label2.Text = s;
        }

        private string doWork() {
            return doWorkAsync().Result;
        }

        private async Task<string> doWorkAsync() {
            string s = await Task.Run(() => {
                Thread.Sleep(3000);
                return "string";
            });
            s += " from doWorkAsync";
            return s;
        }

        private async void button2_Click(object sender, EventArgs e) {
            string s = null;
            s = await getStringAsync();
            //this.label2.BeginInvoke(new Action(() => {
                this.label2.Text = s;
            //}));
        }

        private async Task<string> getStringAsync() {
            string r = await Task.Run(() => {
                Thread.Sleep(3000);
                return "string";
            });

            r += " from getStringAsync";
            return r;
        }
    }
}
