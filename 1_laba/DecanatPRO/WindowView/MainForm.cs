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
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для удаления.");
                return;
            }

            int i = dgvStudents.CurrentRow.Index;

            List<string[]> studentsList = new List<string[]>();
            logic.ShowTableList(studentsList);

            string[] student = studentsList[i];

            string name = student[0];
            string speciality = student[1];
            string group = student[2];

            logic.DeleteStudent(name, speciality, group);
            RefreshTable();

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

            List<string[]> studentsList = new List<string[]>();

            logic.ShowTableList(studentsList);

            foreach (string[] student in studentsList)
            {
                dgvStudents.Rows.Add(student);
            }
        }
    }
}
