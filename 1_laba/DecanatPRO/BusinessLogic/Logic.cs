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

        public void AddStudent(string name, string speciality, string group) {...}
        public void DeleteStudent(string name, string speciality, string group) {...}
    }
}
