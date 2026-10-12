using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowView
{
    public partial class HistogramForm : Form
    {
        private Logic logic;
        public HistogramForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void HistogramForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> histogram = logic.ShowHistogram();

            foreach (KeyValuePair<string, int> res in histogram)
            {
                chart1.Series["Series1"].Points.AddXY(res.Key, res.Value);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
