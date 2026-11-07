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
    public partial class MainForm : Form, IView
    {

        public event AddDataDelegate AddDataEvent;
        public event DeleteDataDelegate DeleteDataEvent;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddDataEvent?.Invoke(new object[]
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

        public void RedrawForm(IEnumerable<IEnumerable<object>> data)
        {
            dgvStudents.Rows.Clear();

            foreach (IEnumerable<object> student in data)
            {
                List<object> fields = new List<object>();

                foreach (object field in student)
                {
                    fields.Add(field);
                }

                dgvStudents.Rows.Add(fields.ToArray());
            }
        }
    }
}
