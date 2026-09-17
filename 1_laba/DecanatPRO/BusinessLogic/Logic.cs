using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class Logic
    {
        public List<Student> students { set; get; }
            = new List<Student>();

        public void AddStudent(string name, string speciality, string group) 
        {
            students.Add(new Student { Name = name, Speciality = speciality, Group = group });
        }
        public void DeleteStudent(string name, string speciality, string group) 
        {
            foreach (Student student in students)
            {
                if (student.Name == name && 
                    student.Speciality == speciality &&
                    student.Group == group)
                {
                    students.Remove(student);
                    break;
                    /// сначала находим конкретного студента по фио и ток потом удаляем его
                    /// а до этого мы просто создавали новый объект через students.Remove( new Student...)
                }
            }
        }

        public List<Student> ListAllStudents()
        {
            return students; 
        }
        /// создали метод, который просто возвращает весь список, 
        /// students будут расписаны уже благодаря set и get в начале Logic.cs
        
        public List<string> ShowHistogram()
        /// ПП говорит, что для WindowView мб в будущем неудобно будет получить отдельно название специальности,
        ///из-за того, что я засунул два списка в одну строку, но посмотрим как будет
        
        {
            List<string> histogram = new List<string>(); // первый лист хранит результат
            List<string> specialities = new List<string>(); // второй лист нужен для проверки какие спец-сти были обработаны

            foreach (Student student in students)
            {
                if (!specialities.Contains(student.Speciality))
                    ///проверка на повтор, если спец-сть встречается впервые, то начинаем её считать, изначально specialities пуст
                    /// изначально specialities пуст

                {
                    int count = 0;

                    foreach (Student item in students) 
                    /// этот форич считает всех студентов, смотря у кого совпадает специальность 
                    /// и прибавляет к счетчику
                    {
                        if (item.Speciality == student.Speciality)
                        {
                            count++;
                        }
                    }

                    histogram.Add(student.Speciality + ": " + count); // выводим строку с результатами

                    specialities.Add(student.Speciality);
                    /// и к концу те спец-сти, что мы обработали помечаем,
                    /// добавляя в список через Add, дабы избежать повторов 
                }
            }

            return histogram;
        }
    }
}
