using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public class EFRepository : IRepository<Student>
    {
        public void Create(Student obj) { }
        public IEnumerable<Student> ReadAll() 
        {
            throw new NotImplementedException();
        }
        public Student ReadById(int id) 
        {
            throw new NotImplementedException();
        }
        public void Update(Student obj) { }
        public void Delete(Student obj) { }

    }
}
