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
    /// <summary>
    /// Реализует операции CRUD для студентов с использованием Entity Framework.
    /// Обеспечивает добавление, чтение, обновление и удаление студентов в базе данных.
    /// </summary>
    public class EFRepository : IRepository<Student>
    {
        /// <summary>
        /// Контекст Entity Framework, используемый для взаимодействия с базой данных.
        /// </summary>
        private readonly StudentContext _context;
        /// <summary>
        /// Инициализирует репозиторий указанным контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст Entity Framework для работы со студентами.</param>
        public EFRepository(StudentContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Добавляет нового студента в базу данных и сохраняет изменения.
        /// </summary>
        /// <param name="obj">Студент, которого необходимо добавить.</param>
        public void Create(Student obj)
        {
            _context.Set<Student>().Add(obj);
            _context.SaveChanges();
        }
        /// <summary>
        /// Получает список всех студентов из базы данных.
        /// </summary>
        /// <returns>Список объектов Student.</returns>
        public IEnumerable<Student> ReadAll()
        {
            return _context.Set<Student>().ToList();
        }
        /// <summary>
        /// Находит студента в базе данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор искомого студента.</param>
        /// <returns>Найденный студент или null, если студент не найден.</returns>
        public Student ReadById(int id)
        {

            return _context.Students.Find(id);

        }

        public void Delete(Student obj) 
        {
            _context.Set<Student>().Remove(obj);
            _context.SaveChanges();
        }

    }
}
