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
    internal class StudentPresenter
    {
        private IModel<Student> model;

        public StudentPresenter(IView view, IModel<Student> model)
        {
            this.model = model;

            model.DataChanged += view.RedrawForm;

            view.AddDataEvent += OnAddData;
            view.DeleteDataEvent += model.Delete;

            model.Insert(new Student { Name = "Иванов Иван Иванович", Speciality = "Прикладная информатика", Group = "ГФ25-02Б" });
            model.Insert(new Student { Name = "Иванов Иван Иванович", Speciality = "Прикладная информатика", Group = "ГФ25-02Б" });
            model.Insert(new Student { Name = "ffff", Speciality = "ffff", Group = "ffff" });
            model.Insert(new Student { Name = "О Степан Сталинович", Speciality = "Лечебное дело", Group = "ЛД26-01Б" });
            model.Insert(new Student { Name = "О Степан", Speciality = "Лечебное дело", Group = "ЛД26-01Б" });
        }

        private void OnAddData(IEnumerable<object> data)
        {
            try
            {
                List<object> list = new List<object>(data);

                Student student = new Student();

                student.Name = list[0].ToString();
                student.Speciality = list[1].ToString();
                student.Group = list[2].ToString();

                model.Insert(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
