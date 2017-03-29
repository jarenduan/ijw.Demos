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
using DevExpress.XtraCharts;

namespace ijw.Demo.DevExChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.chartControl1.Series.Clear();
            // Create the first side-by-side bar series and add points to it.
            Series series1 = new Series("Side-by-Side Bar Series 1", ViewType.Line);
            series1.Points.Add(new SeriesPoint("A", new double[] { 10 }));
            series1.Points.Add(new SeriesPoint("B", new double[] { 12 }));
            series1.Points.Add(new SeriesPoint("C", new double[] { 14 }));
            series1.Points.Add(new SeriesPoint("D", new double[] { 17 }));

            // Create the second side-by-side bar series and add points to it.
            Series series2 = new Series("Side-by-Side Bar Series 2", ViewType.Bar);
            series2.Points.Add(new SeriesPoint("A", new double[] { 15 }));
            series2.Points.Add(new SeriesPoint("B", new double[] { 18 }));
            series2.Points.Add(new SeriesPoint("C", new double[] { 25 }));
            series2.Points.Add(new SeriesPoint("D", new double[] { 33 }));

            // Add the series to the chart.
            this.chartControl1.Series.Add(series1);
            this.chartControl1.Series.Add(series2);

            // Hide the legend (if necessary).
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;


        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Random r  = new Random(1);
            for (int i = 0; i < 100; i++) {
                Thread.Sleep(10);
                this.chartControl1.Series[0].Points.Add(new SeriesPoint(i * r.Next()));
                this.chartControl1.Update();
            }
        }
    }
}
