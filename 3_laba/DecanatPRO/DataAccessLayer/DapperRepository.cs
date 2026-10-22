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
    /// <summary>
    /// Реализует CRUD-операции для студентов с помощью библиотеки Dapper.
    /// </summary>
    public class DapperRepository : IRepository<Student>
    {
        private readonly string connectionString;
        /// <summary>
        /// Инициализирует репозиторий и задаёт строку подключения к базе данных.
        /// </summary>
        public DapperRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ARDOR\Source\Repos\Programming_3_semester\3_laba\DecanatPRO\DataAccessLayer\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True";
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
        /// <summary>
        /// Добавляет нового студента в базу данных.
        /// </summary>
        /// <param name="student">Добавляемый студент.</param>
        public void Create(Student student)
        {
            string script = "INSERT INTO Students (Name, Speciality, [Group]) VALUES ('" + student.Name + "', '" + student.Speciality + "', '" + student.Group + "')";
            UseScript(script);
        }
        /// <summary>
        /// Возвращает всех студентов из базы данных.
        /// </summary>
        /// <returns>Коллекция студентов.</returns>
        public IEnumerable<Student> ReadAll()
        {
            List<Student> students;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                students = db.Query<Student>("SELECT * FROM Students ").ToList();
            }
            return students;
        }
        /// <summary>
        /// Находит студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Найденный студент или null, если студент не найден.</returns>
        public Student ReadById(int id)
        {
            Student student;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                student = db.Query<Student>("Select * FROM Students WHERE Id = " + id).FirstOrDefault();
            }
            return student;
        }
        /// <summary>
        /// Удаляет студента из базы данных.
        /// </summary>
        /// <param name="student">Удаляемый студент.</param>
        public void Delete(Student student) 
        {
            string script = "DELETE FROM Students WHERE Id = " + student.Id;
            UseScript(script);
        }
    }
}
