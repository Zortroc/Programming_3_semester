using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Student>
    {
        private readonly string connectionString;
        public DapperRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ARDOR\Source\Repos\Programming_3_semester\2_laba\DecanatPRO\DataAccessLayer\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True";
        }

        private void UseScript(string script)
        {
            if(!string.IsNullOrEmpty(script))
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute(script);
                }
            }
        }

        public void Create(Student student)
        {
            string script = "INSERT INTO Students (Name, Speciality, [Group]) VALUES ('" + student.Name + "', '" + student.Speciality + "', '" + student.Group + "')";
            UseScript(script);
        }

        public IEnumerable<Student> ReadAll()
        {
            List<Student> students;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                students = db.Query<Student>("SELECT * FROM Students ").ToList();
            }
            return students;
        }

        public Student ReadById(int id)
        {
            Student student;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                student = db.Query<Student>("Select * FROM Students WHERE Id = " + id).FirstOrDefault();
            }
            return student;
        }

        public void Delete(Student student) 
        {
            string script = "DELETE FROM Students WHERE Id = " + student.Id;
            UseScript(script);
        }
    }
}
