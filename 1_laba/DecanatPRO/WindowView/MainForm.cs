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
        }
        
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");
            AddStudentForm addForm = new AddStudentForm(logic);
            addForm.ShowDialog();
            RefreshTable();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");
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

            logic.ShowTableList((name, speciality, group) =>
            {
                dgvStudents.Rows.Add(name, speciality, group);
            });
        }
    }
}
