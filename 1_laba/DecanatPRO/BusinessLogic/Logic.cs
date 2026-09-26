using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Готовый класс Logic, который содержит методы для работы со студентами.
    /// В случае изменения логики, нужно согласовать!
    /// </summary>
    
    public class Logic
    {
        private List<Student> students { get; set; } = new List<Student>();

        public Logic()
        {
            AddStudent("Иванов Иван Иванович", "Прикладная информатика", "ГФ25-02Б");
            AddStudent("Петров Петр Леонидович", "Программная инженерия", "ПИ25-01");
            AddStudent("О Степан Дебилович", "Лечебное дело", "ЛД26-01Б");
        }

        public void AddStudent(string name, string speciality, string group)
        {
            string[] values = { name, speciality, group };
            string[] fieldNames = { "ФИО", "направление", "группа" };

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (values[i] ?? "").Trim();

                while (values[i].Contains("  "))
                {
                    values[i] = values[i].Replace("  ", " ");
                }

                if (string.IsNullOrWhiteSpace(values[i]))
                {
                    throw new Exception($"ошибка: {fieldNames[i]} не может быть пустым.");
                }

                if (fieldNames[i] == "ФИО")
                {
                    if (values[i].Count(space => space == ' ') != 2)
                        throw new Exception ("ФИО должно содержать фамилию, имя и отчество.");
                }

                if (fieldNames[i] != "группа")
                {
                    foreach (char s in values[i])
                    {
                        if (!char.IsLetter(s) && 
                            s != ' ')
                            throw new Exception($"ошибка: {fieldNames[i]} может содержать только буквы и пробелы.");
                    }
                }
                else
                {
                    foreach (char s in values[i])
                    {
                        if (!char.IsLetterOrDigit(s) &&
                            s != '-')
                            throw new Exception("ошибка: группа может содержать только буквы, цифры и дефис.");
                    }

                    if (values[i].StartsWith("-") ||
                        values[i].EndsWith("-"))
                        throw new Exception("ошибка: группа не может начинаться или заканчиваться дефисом.");

                    if (values[i].Contains("--"))
                        throw new Exception("ошибка: группа не может содержать два дефиса подряд.");
                }
            }

            foreach (Student student in students)
            {
                if (student.Name == values[0] &&
                    student.Speciality == values[1] &&
                    student.Group == values[2])
                {
                    throw new Exception("ошибка: такой студент уже существует.");
                }
            }

            students.Add(new Student { Name = values[0], Speciality = values[1], Group = values[2]});
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
                    return;
                }
            }

            throw new Exception("студент не найден.");
        }

        public void ShowTableList(List<string[]> studentsList)
        {
            foreach (Student student in students)
            {
                studentsList.Add(new string[]{student.Name, student.Speciality, student.Group});
            }
        }


        public void ShowHistogram(List<string> x, List<int> y)
        {
            List<string> specialities = x;
            List<int> counts = y;

            foreach (Student student in students)
            {
                int i = specialities.IndexOf(student.Speciality);

                if (i == -1)
                {
                    specialities.Add(student.Speciality);
                    counts.Add(1);
                }
                else
                {
                    counts[i]++;
                }
            }
        }
    }
}
