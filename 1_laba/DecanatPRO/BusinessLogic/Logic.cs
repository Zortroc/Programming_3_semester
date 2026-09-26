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
            string[] values = { name, speciality, group };
            string[] fieldNames = { "ФИО", "направление", "группа" };

            for (int i = 0; i < values.Length; i++)
            {
                // Убираем пробелы в начале и конце,
                // а также повторяющиеся пробелы
                if (values[i] != null)
                {
                    values[i] = values[i].Trim();

                    while (values[i].Contains("  "))
                    {
                        values[i] = values[i].Replace("  ", " ");
                    }
                }

                // Проверка на пустое поле
                if (string.IsNullOrWhiteSpace(values[i]))
                {
                    throw new Exception(
                        "ошибка: " + fieldNames[i] + " не может быть пустым."
                    );
                }

                // Проверка ФИО и направления
                if (i < 2)
                {
                    foreach (char symbol in values[i])
                    {
                        if (!char.IsLetter(symbol) && symbol != ' ')
                        {
                            throw new Exception(
                                "ошибка: " + fieldNames[i] +
                                " может содержать только буквы и пробелы."
                            );
                        }
                    }
                }

                // Проверка группы
                else
                {
                    foreach (char symbol in values[i])
                    {
                        if (!char.IsLetterOrDigit(symbol) && symbol != '-')
                        {
                            throw new Exception(
                                "ошибка: группа может содержать только буквы, цифры и дефис."
                            );
                        }
                    }

                    // Дефис не может быть первым или последним символом
                    if (values[i][0] == '-' ||
                        values[i][values[i].Length - 1] == '-')
                    {
                        throw new Exception(
                            "ошибка: группа не может начинаться или заканчиваться дефисом."
                        );
                    }

                    // Два дефиса подряд запрещены
                    if (values[i].Contains("--"))
                    {
                        throw new Exception(
                            "ошибка: группа не может содержать два дефиса подряд."
                        );
                    }
                }
            }

            // Проверка на дубликат
            foreach (Student student in students)
            {
                if (student.Name == values[0] &&
                    student.Speciality == values[1] &&
                    student.Group == values[2])
                {
                    throw new Exception(
                        "ошибка: такой студент уже существует."
                    );
                }
            }

            // Добавление студента
            students.Add(new Student
            {
                Name = values[0],
                Speciality = values[1],
                Group = values[2]
            });
        }


        public void DeleteStudent(int studentNumber)
        {
            if (studentNumber < 1 || studentNumber > students.Count)
            {
                throw new Exception(
                    "ошибка: студента с таким номером нет."
                );
            }

            students.RemoveAt(studentNumber - 1);
        }


        public void ShowTableList(
            Action<string, string, string> showStudent)
        {
            foreach (Student student in students)
            {
                showStudent(
                    student.Name,
                    student.Speciality,
                    student.Group
                );
            }
        }


        public void ShowHistogram(
            Action<string, int> showSpeciality)
        {
            List<string> specialities = new List<string>();

            foreach (Student student in students)
            {
                if (!specialities.Contains(student.Speciality))
                {
                    int count = 0;

                    foreach (Student item in students)
                    {
                        if (item.Speciality == student.Speciality)
                        {
                            count++;
                        }
                    }

                    showSpeciality(student.Speciality, count);
                    specialities.Add(student.Speciality);
                }
            }
        }
    }
}
