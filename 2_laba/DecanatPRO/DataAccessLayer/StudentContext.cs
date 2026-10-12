using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Контекст Entity Framework, обеспечивающий взаимодействие
    /// между приложением и базой данных студентов.
    /// </summary>
    public class StudentContext : DbContext
    {
        /// <summary>
        /// Создаёт контекст базы данных и устанавливает подключение
        /// с использованием строки подключения StudentConnection.
        /// </summary>
        public StudentContext() : base("name=StudentConnection")
        {
        }
        /// <summary>
        /// Представляет набор студентов в базе данных.
        /// Используется для получения, добавления, изменения и удаления записей.
        /// </summary>
        public DbSet<Student> Students { get; set; }
    }
}
