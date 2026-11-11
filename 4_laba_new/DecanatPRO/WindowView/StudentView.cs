using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace View
{
    /// <summary>
    /// Представляет графический интерфейс для отображения списка студентов
    /// и взаимодействия пользователя с моделью через Presenter.
    /// </summary>
    public partial class StudentView : Form, IView
    {
        /// <summary>
        /// Возникает при нажатии пользователем кнопки добавления студента.
        /// </summary>
        public event AddDataDelegate AddDataEvent;
        /// <summary>
        /// Возникает при запросе пользователя на удаление выбранного студента.
        /// </summary>
        public event DeleteDataDelegate DeleteDataEvent;
        public StudentView()
        {
            InitializeComponent();
        }
        private void StudentView_Load(object sender, EventArgs e)
        {
        }
        public void RedrawForm(IEnumerable<IEnumerable<object>> data)
        {
            dgvStudents.Rows.Clear();

            foreach (IEnumerable<object> student in data)
            {
                List<object> fields = new List<object>(student);
                dgvStudents.Rows.Add(fields.ToArray());
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddDataEvent?.Invoke(new List<object>()
            {
                textName.Text,
                textSpeciality.Text,
                textGroup.Text
            });
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для удаления.");
                return;
            }

            int index = dgvStudents.CurrentRow.Index;

            DeleteDataEvent?.Invoke(index);

        }

    }
}
