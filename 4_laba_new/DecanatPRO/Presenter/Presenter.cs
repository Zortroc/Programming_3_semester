using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using System.Windows.Forms;

namespace Presenter
{
    internal class Presenter
    {
        private readonly IModel<Student> model;
        private readonly IView view;

        public Presenter()
        {
            model = new Logic();
            view = new MainForm();

            view.AddDataEvent += OnAddData;
            view.DeleteDataEvent += OnDeleteData;
            model.DataChanged += OnDataChanged;
        }

        private void OnAddData(IEnumerable<object> data)
        {
            try
            {
                List<object> fields = new List<object>(data);

                Student student = new Student
                {
                    Name = fields[0]?.ToString(),
                    Speciality = fields[1]?.ToString(),
                    Group = fields[2]?.ToString()
                };

                model.Insert(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnDeleteData(int index)
        {
            try
            {
                model.Delete(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnDataChanged(IEnumerable<IEnumerable<object>> data)
        {
            view.RedrawForm(data);
        }

        public void Run()
        {
            model.Refresh();
            Application.Run((Form)view);
        }

    }
}
