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
        public string DeleteStudent(string name, string speciality = "", string group = "") 
        {
            List<Student> found = new List<Student>();
            foreach (Student s in students)
            {
                bool nameMatches = s.Name == name;
                bool specMatches = string.IsNullOrEmpty(speciality) || s.Speciality == speciality;
                bool groupMatches = string.IsNullOrEmpty(group) || s.Group == group;

                if (nameMatches && specMatches && groupMatches)
                {
                    found.Add(s);
                }
            }

            if (found.Count == 0)
            {
                return "студент не найден.";
            }

            if (found.Count == 1)
            {
                students.Remove(found[0]);
                return "студент успешно удален.";
            }

            string warning = "найдено несколько совпадений:\n";
            foreach (Student s in found)
            {
                warning += s.Name + " | " + s.Speciality + " | " + s.Group + "\n";
            }
            warning += "укажите специальность и группу для точного удаления.";
            return warning;
        }

        public List<string> ListAllStudents()
        {
            List<String> result = new List<string>();

            foreach (Student student in students)
            {
                result.Add(string.Join(" | ", student.Name, student.Speciality, student.Group));
            }

            return result;

        }
        // создали метод, который просто возвращает весь список, 
        // students будут расписаны уже благодаря set и get в начале Logic.cs
        
        public List<string> ShowHistogram()
        // ПП говорит, что для WindowView мб в будущем неудобно будет получить отдельно название специальности,
        // из-за того, что я засунул два списка в одну строку, но посмотрим как будет
        
        {
            List<string> histogram = new List<string>(); // первый лист хранит результат
            List<string> specialities = new List<string>(); // второй лист нужен для проверки какие спец-сти были обработаны

            foreach (Student student in students)
            {
                if (!specialities.Contains(student.Speciality))
                    //проверка на повтор, если спец-сть встречается впервые, то начинаем её считать
                    // изначально specialities пуст

                {
                    int count = 0;

                    foreach (Student item in students) 
                    // этот форич считает всех студентов, смотря у кого совпадает специальность 
                    // и прибавляет к счетчику
                    {
                        if (item.Speciality == student.Speciality)
                        {
                            count++;
                        }
                    }

                    histogram.Add(student.Speciality + ": " + count); 
                    // выводим строку с результатами для каждого студента, к примеру "ИТ: 3"

                    specialities.Add(student.Speciality);
                    // и к концу те спец-сти, что мы обработали помечаем,
                    // добавляя в список через Add, дабы избежать повторов 
                }
            }

            return histogram;
        }
    }
}
