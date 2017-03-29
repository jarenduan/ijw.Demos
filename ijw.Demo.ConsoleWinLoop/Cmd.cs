using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleWinLoop {
    public class Cmd {
        FormBehind form = new FormBehind();

        public void Start() {
            Thread t = new Thread(new ThreadStart(startLoop));
            t.IsBackground = true;
            t.Start();
            string cmd = string.Empty;
            while (cmd != "exit") {
                cmd = Console.ReadLine();
                if (cmd == "add") {
                    var btn = new Button();
                    btn.Name = "btn";
                    btn.Click += btn_Click;
                    btn.Text = "console-button";
                    btn.Size = new System.Drawing.Size(100, btn.Size.Height);
                    btn.Location = new System.Drawing.Point(166, 33);
                    this.form.Invoke(new Action(() => {
                        this.form.Controls.Add(btn);
                        this.form.Update();
                    }));
                }
            }
            t.Abort();
        }

        void btn_Click(object sender, EventArgs e) {
            Console.WriteLine("console-button clicked");
        }
        private void startLoop() {
            Application.Run(form);
        }
    }
}
