using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=StudentConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
