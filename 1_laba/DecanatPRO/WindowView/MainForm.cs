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

                MessageBox.Show(
                    "Студент успешно удалён.",
                    "Удаление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

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
            MessageBox.Show("В разработке");
        }

        // Метод обновления таблицы
        private void RefreshTable()
        {
            dgvStudents.Rows.Clear();

            List<string[]> result = new List<string[]>();

            logic.ShowTableList(result);

            foreach (string[] student in result)
            {
                dgvStudents.Rows.Add(
                    student[0],
                    student[1],
                    student[2]
                );
            }
        }
    }
}
