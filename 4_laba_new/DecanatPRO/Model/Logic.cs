using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Model
{

    public class Logic : IModel<Student>
    {
        private List<Student> students = new List<Student>();
        public event Action<IEnumerable<IEnumerable<object>>> DataChanged;

        public Logic()
        {
            Insert(new Student { Name = "Иванов Иван Иванович", Speciality = "Прикладная информатика", Group = "ГФ25-02Б" });
            Insert(new Student { Name = "Иванов Иван Иванович", Speciality = "Прикладная информатика", Group = "ГФ25-02Б" });
            Insert(new Student { Name = "ffff", Speciality = "ffff", Group = "ffff" });
            Insert(new Student { Name = "О Степан Сталинович", Speciality = "Лечебное дело", Group = "ЛД26-01Б" });
            Insert(new Student { Name = "О Степан", Speciality = "Лечебное дело", Group = "ЛД26-01Б" });
        }

        public void Insert(Student student)
        {
            string[] values = { student.Name, student.Speciality, student.Group };
            string[] fieldNames = { "ФИО", "Направление", "Группа" };

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (values[i] ?? "").Trim();

                if (values[i] == "")
                {
                    throw new Exception($"Ошибка: {fieldNames[i]} не может быть пустым.");
                }

                while (values[i].Contains("  "))
                {
                    values[i] = values[i].Replace("  ", " ");
                }

                if (fieldNames[i] != "Группа")
                {
                    foreach (char s in values[i])
                    {
                        if (!char.IsLetter(s) &&
                            s != ' ')
                        {
                            throw new Exception($"Ошибка: {fieldNames[i]} может содержать только буквы и пробелы.");
                        }
                    }
                }
                else
                {
                    foreach (char s in values[i])
                    {
                        if (!char.IsLetterOrDigit(s) &&
                            s != '-')
                        {
                            throw new Exception("Ошибка: группа может содержать только буквы, цифры и дефис.");
                        }
                    }

                    if (values[i].StartsWith("-") ||
                        values[i].EndsWith("-"))
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

            NotifyDataChanged();
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= students.Count)
            {
                throw new Exception("Неверный номер.");
            }

            students.RemoveAt(index);

            NotifyDataChanged();
        }

        public IEnumerable<IEnumerable<object>> GetData()
        {
            List<IEnumerable<object>> data =
                new List<IEnumerable<object>>();

            foreach (Student student in students)
            {
                data.Add(new object[]
                {
                    student.Name,
                    student.Speciality,
                    student.Group
                });
            }

            return data;
        }

        private void NotifyDataChanged()
        {
            List<List<object>> data = new List<List<object>>();

            foreach (Student student in students)
            {
                data.Add(new List<object>
                {
                    student.Name,
                    student.Speciality,
                    student.Group
                });
            }

            DataChanged?.Invoke(data);
        }

        public void Refresh()
        {
            NotifyDataChanged();
        }
    }
}
