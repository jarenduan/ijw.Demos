using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ijw.Demo.CoreConfigInWinform {
    public partial class MainForm : Form, IMainForm {
        private MainFormSettings _settings;

        public MainFormSettings Settings { get => _settings; set => _settings = value; }

        public MainForm() {
            InitializeComponent();
        }

        public MainForm(MainFormSettings settings) : this() {
            this.Settings = settings;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Text = this.Settings.Name;
        }
    }
}
