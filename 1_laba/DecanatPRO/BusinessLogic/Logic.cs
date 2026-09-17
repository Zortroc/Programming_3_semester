using System;
using System.Collections.Generic;
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
        public void DeleteStudent(string name, string speciality, string group) 
        {
            students.Remove(new Student { Name = name, Speciality = speciality, Group = group });
        }

        public void ListAllStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student.Name, student.Speciality, student.Group);
            }
        }

        public void ShowHistogram(List<Student> students)
        {
            List<string> specialities = new List<string>();

            foreach (Student student in students)
            {
                if student.Speciality =;
            }


        }
    }
}
