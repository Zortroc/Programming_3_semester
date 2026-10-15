using Dapper;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    /// <summary>
    /// Реализует CRUD-операции для студентов с помощью Dapper.
    /// </summary>
    public class DapperRepository : IRepository<Student>
    {
        
        private string connectionString;

        /// <summary>
        /// Создаёт репозиторий с указанной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
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
        /// Добавляет студента в базу данных.
        /// </summary>
        /// <param name="student">Добавляемый студент.</param>
        public void Create(Student student)
        {
            string script = "INSERT INTO Students (Name, Speciality, [group]) VALUES (" + student.Name + ", " + student.Speciality + "," + student.Group + ")";
            UseScript(script);
        }
        /// <summary>
        /// Возвращает всех студентов из базы данных.
        /// </summary>
        /// <returns>Список студентов.</returns>
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
        /// <returns>Найденный студент или null, если его нет.</returns>
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
