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
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для удаления.");
                return;
            }

            int studentNumber = dgvStudents.SelectedRows[0].Index + 1;

            try
            {
                logic.DeleteStudent(studentNumber);
                RefreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowTableList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");

        }

        private void btnShowHistogram_Click(object sender, EventArgs e)
        {
            HistogramForm form = new HistogramForm(logic);
            form.ShowDialog();
        }

        // Метод обновления таблицы
        private void RefreshTable()
        {
            dgvStudents.Rows.Clear();

            List<string[]> studentsList = new List<string[]>();

            logic.ShowTableList(studentsList);

            foreach (string[] student in studentsList)
            {
                dgvStudents.Rows.Add(student);
            }
        }
    }
}
