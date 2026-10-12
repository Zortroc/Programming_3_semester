using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Model;

namespace BusinessLogic
{
    
    public class Logic
    {
        private List<Student> students = new List<Student>();

        public Logic()
        {
            AddStudent("Иванов Иван Иванович", "Прикладная информатика", "ГФ25-02Б");
            AddStudent("Иванов Иван Иванович", "Прикладная информатика", "ГФ25-02Б");
            AddStudent("ffff", "ffff", "ПИ25-01");
            AddStudent("О Степан Сталинович", "Лечебное дело", "ЛД26-01Б");
            AddStudent("О Степан", "Лечебное дело", "ЛД26-01Б");
        }

        public void AddStudent(string name, string speciality, string group)
        {
            string[] values = { name, speciality, group };
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
        }

        public void DeleteStudent(int studentNumber)
        {
            int index = studentNumber - 1;
            if (index >= 0 &&
                index < students.Count)
            {
                students.RemoveAt(index);
            }
            else
            { 
                throw new Exception("Неверный номер.");
            }    
        }

        public List<string[]> ShowTableList()
        {
            List<string[]> studentsList = new List<string[]>();

            foreach (Student student in students)
            {
                studentsList.Add(
                    new string[]
                    {
                        student.Name, 
                        student.Speciality, 
                        student.Group
                    }
                );
            }
            return studentsList;
        }

        public Dictionary<string, int> ShowHistogram()
        {
            Dictionary<string, int> histogram = new Dictionary<string, int>();

            foreach (Student student in students)
            {
                if (!histogram.ContainsKey(student.Speciality))
                {
                    histogram.Add(student.Speciality, 1);
                }
                else
                {
                    histogram[student.Speciality]++;
                }
            }

            return histogram;
        }
    }
}
