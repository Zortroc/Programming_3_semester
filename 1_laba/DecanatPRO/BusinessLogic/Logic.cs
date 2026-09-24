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
            List<string> values = new List<string> { name, speciality, group };

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] != null)
                {
                    values[i] = values[i].Trim();
                    while (values[i].Contains("  "))
                    {
                        values[i] = values[i].Replace("  ", " ");
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(values[0]))
            {
                throw new Exception("ошибка: ФИО не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(values[1]))
            {
                throw new Exception("ошибка: направление не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(values[2]))
            {
                throw new Exception("ошибка: группа не может быть пустой.");
            }

            foreach (Student s in students)
            {
                if (s.Name == values[0] && s.Speciality == values[1] && s.Group == values[2])
                {
                    throw new Exception("ошибка: такой студент уже существует.");
                }
            }

            students.Add(new Student
            {
                Name = values[0],
                Speciality = values[1],
                Group = values[2]
            });
        }
        
        public void DeleteStudent(string name, string speciality = "", string group = "")
        {
        }
        

        public List<string> ShowTableList()
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
