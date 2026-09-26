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
    public partial class AddStudentForm : Form
    {
        private Logic logic;
        public AddStudentForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                logic.AddStudent(txtName.Text, txtSpeciality.Text, txtGroup.Text);

                MessageBox.Show("Студент добавлен");
                this.Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
