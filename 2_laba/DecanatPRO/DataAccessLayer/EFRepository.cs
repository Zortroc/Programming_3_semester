using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EFRepository : IRepository<Student>
    {
        private readonly StudentContext _context;

        public EFRepository(StudentContext context)
        {
            _context = context;
        }
        public void Create(Student obj)
        {
            _context.Set<Student>().Add(obj);
            _context.SaveChanges();
        }
        public IEnumerable<Student> ReadAll()
        {
            return _context.Set<Student>().ToList();
        }
        public Student ReadById(int id)
        {

            return _context.Students.Find(id);

        }
        public void Update(Student obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Student obj) 
        {
            _context.Set<Student>().Remove(obj);
            _context.SaveChanges();
        }

    }
}
