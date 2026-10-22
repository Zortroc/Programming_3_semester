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
                // Забираем данные из полей ввода и отдаем логике
                logic.AddStudent(txtName.Text, txtSpeciality.Text, txtGroup.Text);

                MessageBox.Show("Студент добавлен");
                this.Close(); // закрываем окно ввода
            }
            catch (Exception ex)
            {
                // Если логика бросила throw (пустое поле или дубликат), показываем текст ошибки
                MessageBox.Show(ex.Message);
            }
        }
    }
}
