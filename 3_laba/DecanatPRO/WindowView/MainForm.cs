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
using Ninject;

namespace WindowView
{
    public partial class MainForm : Form
    {
        private static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        private static Logic logic = ninjectKernel.Get<Logic>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }
        
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addForm = new AddStudentForm(logic);
            addForm.ShowDialog();
            RefreshTable();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для удаления.");
                return;
            }

            int i = dgvStudents.CurrentRow.Index;
            try
            { 
                logic.DeleteStudent(i + 1);
                RefreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnShowHistogram_Click(object sender, EventArgs e)
        {
            if (dgvStudents.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения гистограммы.");
                return;
            }
            HistogramForm form = new HistogramForm(logic);
            form.ShowDialog();
        }

        private void RefreshTable()
        {
            dgvStudents.Rows.Clear();
            string[,] table = logic.ShowTableList();

            for (int i = 0; i < table.GetLength(0); i++)
            {
                dgvStudents.Rows.Add(
                    table[i, 0],
                    table[i, 1],
                    table[i, 2]
                );
            }
        }
    }
}
