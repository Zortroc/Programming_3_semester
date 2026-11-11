using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Реализует модель студентов, обеспечивающую хранение,
    /// добавление, удаление и проверку данных студентов.
    /// </summary>
    public class StudentModel : IModel<Student>
    {
        /// <summary>
        /// Возникает при изменении списка студентов и передаёт его актуальное содержимое.
        /// </summary>
        public event DataChangedDelegate DataChanged;
        private List<Student> students = new List<Student>();
        /// <summary>
        /// Проверяет данные студента и добавляет его в список.
        /// После успешного добавления уведомляет об изменении данных.
        /// </summary>
        /// <param name="student">Студент, которого необходимо добавить.</param>
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

            InvokeDataChanged();
        }
        /// <summary>
        /// Удаляет студента из списка по указанному индексу.
        /// После успешного удаления уведомляет об изменении данных.
        /// </summary>
        /// <param name="index">Индекс студента, которого необходимо удалить.</param>
        public void Delete(int index)
        {
            if (index < 0 || index >= students.Count)
            {
                throw new Exception("Неверный номер.");
            }

            students.RemoveAt(index);

            InvokeDataChanged();
        }

        private void InvokeDataChanged()
        {
            List<List<object>> list = new List<List<object>>();

            foreach (Student item in students)
            {
                list.Add(new List<object>
                {
                    item.Name,
                    item.Speciality,
                    item.Group
                });
            }

            DataChanged?.Invoke(list);
        }

    }
}