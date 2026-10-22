using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Контекст Entity Framework, обеспечивающий взаимодействие
    /// между приложением и базой данных студентов.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Создаёт контекст базы данных и устанавливает подключение
        /// с использованием строки подключения StudentConnection.
        /// </summary>
        public DataContext() : base("name=StudentConnection")
        {
        }
        /// <summary>
        /// Представляет набор студентов в базе данных.
        /// Используется для получения, добавления, изменения и удаления записей.
        /// </summary>
        public DbSet<Student> Students { get; set; }
    }
}
