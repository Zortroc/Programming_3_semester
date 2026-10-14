using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Model;
using DataAccessLayer;
using System.Linq;

namespace BusinessLogic
{
    
    public class Logic
    {
        private readonly IRepository<Student> _repository 
            = new EFRepository(new StudentContext());

        //public Logic()
        //{
        //    AddStudent("Иванов Иван Иванович", "Прикладная информатика", "ГФ25-02Б");
        //    AddStudent("Иванов Иван Иванович", "Прикладная информатика", "ГФ25-02Б");
        //    AddStudent("ffff", "ffff", "ПИ25-01");
        //    AddStudent("О Степан Сталинович", "Лечебное дело", "ЛД26-01Б");
        //    AddStudent("О Степан", "Лечебное дело", "ЛД26-01Б");
        //}

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

            _repository.Create(new Student 
            { 
                Name = values[0], 
                Speciality = values[1], 
                Group = values[2]
            });
        }

        public void DeleteStudent(int studentNumber)
        {
            List<Student> students = _repository.ReadAll().ToList();

            int index = studentNumber - 1;
            if (index >= 0 &&
                index < students.Count)
            {
                _repository.Delete(students[index]);
            }
            else
            { 
                throw new Exception("Неверный номер.");
            }    
        }

        public string[,] ShowTableList()
        {
            List<Student> students = _repository.ReadAll().ToList();

            string[,] table = new string[students.Count, 3];
            for (int i = 0; i < students.Count; i++)
            {
                table[i,0] = students[i].Name;
                table[i,1] = students[i].Speciality;
                table[i,2] = students[i].Group;
            }

            return table;
        }

        public Dictionary<string, int> ShowHistogram()
        {
            List<Student> students = _repository.ReadAll().ToList();

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
