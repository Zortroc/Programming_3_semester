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
            List<string> specialities = new List<string>();
            List<int> counts = new List<int>();

            logic.ShowHistogram(specialities, counts);

            for (int i = 0; i < specialities.Count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(
                    specialities[i],
                    counts[i]
                );
            }
        }
    }
}
