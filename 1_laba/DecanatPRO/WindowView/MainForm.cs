using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace WindowView
{
    public partial class MainForm : Form
    {
        private Logic logic;
        public MainForm()
        {
            InitializeComponent();
            logic = new Logic();
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addForm = new AddStudentForm(logic);
            addForm.ShowDialog();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {

        }

        private void btnShowTableList_Click(object sender, EventArgs e)
        {

        }

        private void btnShowHistogram_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
