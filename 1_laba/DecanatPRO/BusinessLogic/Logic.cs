using System;
using System.Collections.Generic;
using System.Linq;
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
            AddStudent("Иванов Иван Иванович", "Прикладная информатика", "ГФ25-02Б");
            AddStudent("Петров Петр Леонидович", "Программная инженерия", "ПИ25-01");
            AddStudent("О Степан Сталинович", "Лечебное дело", "ЛД26-01Б");
        }

        public void AddStudent(string name, string speciality, string group)
        {
            string[] values = { name, speciality, group };
            string[] fieldNames = { "ФИО", "Направление", "Группа" };

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (values[i] ?? "").Trim();

                while (values[i].Contains("  "))
                {
                    values[i] = values[i].Replace("  ", " ");
                }

                if (string.IsNullOrWhiteSpace(values[i]))
                {
                    throw new Exception($"Ошибка: {fieldNames[i]} не может быть пустым.");
                }

                if (fieldNames[i] == "ФИО")
                {
                    string[] nameParts = values[i].Split(' ');

                    foreach (string part in nameParts)
                    {
                        if (!char.IsUpper(part[0]))
                        {
                            throw new Exception("ФИО должны начинаться с заглавной буквы.");
                        }
                    }
                }

                if (fieldNames[i] == "Направление")
                {
                    if (!char.IsUpper(values[i][0]))
                    {
                        throw new Exception("Направление должно начинаться с заглавной буквы.");
                    }
                }

                if (fieldNames[i] != "Группа")
                {
                    foreach (char s in values[i])
                    {
                        if (!char.IsLetter(s) && s != ' ')
                        {
                            throw new Exception($"Ошибка: {fieldNames[i]} может содержать только буквы и пробелы.");
                        }
                    }
                }
                else
                {
                    foreach (char s in values[i])
                    {
                        if (!char.IsLetterOrDigit(s) && s != '-')
                        {
                            throw new Exception("Ошибка: группа может содержать только буквы, цифры и дефис.");
                        }
                    }

                    if (values[i].StartsWith("-") || values[i].EndsWith("-"))
                    {
                        throw new Exception("Ошибка: группа не может начинаться или заканчиваться дефисом.");
                    }

                    if (values[i].Contains("--"))
                    {
                        throw new Exception("Ошибка: группа не может содержать два и более дефиса подряд.");
                    }
                }
            }

            students.Add(new Student 
            { 
                Name = values[0], 
                Speciality = values[1], 
                Group = values[2]
            });
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

            throw new Exception("Студент не найден.");
        }

        public void ShowTableList(List<string[]> studentsList)
        {
            foreach (Student student in students)
            {
                studentsList.Add(new string[]
                {
                    student.Name, 
                    student.Speciality, 
                    student.Group
                });
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
