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
        public List<Student> students { get; set; } = new List<Student>();

        public Logic()
        {
            AddStudent(
                "Иванов Иван Иванович",
                "Прикладная информатика",
                "ГФ25-02Б"
            );

            AddStudent(
                "Петров Петр",
                "Программная инженерия",
                "ПИ25-01"
            );

            AddStudent(
                "О Степан",
                "Лечебное дело",
                "ЛД26-01Б"
            );
        }

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


        public void ShowHistogram(List<string> specialities, List<int> counts)
        {
            foreach (Student student in students)
            {
                int index = specialities.IndexOf(student.Speciality);

                if (index == -1)
                {
                    specialities.Add(student.Speciality);
                    counts.Add(1);
                }
                else
                {
                    counts[index]++;
                }
            }
        }
    }
}
