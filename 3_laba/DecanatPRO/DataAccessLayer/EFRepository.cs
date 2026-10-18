using Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    /// <summary>
    /// Реализует операции CRUD для студентов с использованием Entity Framework.
    /// Обеспечивает добавление, чтение, обновление и удаление студентов в базе данных.
    /// </summary>
    public class EFRepository : IRepository<Student>
    {
        
        private readonly DataContext _context;
        /// <summary>
        /// Инициализирует репозиторий указанным контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст Entity Framework для работы со студентами.</param>
        public EFRepository(DataContext context)
        {
            _context = context;
        }
        ///<inheritdoc/>
        public void Create(Student obj)
        {
            _context.Set<Student>().Add(obj);
            _context.SaveChanges();
        }
        ///<inheritdoc/>
        public IEnumerable<Student> ReadAll()
        {
            return _context.Set<Student>().ToList();
        }
        ///<inheritdoc/>
        public Student ReadById(int id)
        {

            return _context.Students.Find(id);

        }
        ///<inheritdoc/>
        public void Delete(Student obj) 
        {
            _context.Set<Student>().Remove(obj);
            _context.SaveChanges();
        }

    }
}
