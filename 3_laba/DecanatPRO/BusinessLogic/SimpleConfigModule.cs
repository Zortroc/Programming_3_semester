using DataAccessLayer;
using Ninject.Modules;
using Model;

namespace BusinessLogic
{
    /// <summary>
    /// Настраивает зависимости приложения с помощью Ninject.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        /// <summary>
        /// Связывает интерфейс репозитория студентов с реализацией Dapper.
        /// </summary>
        public override void Load()
        {
            Bind<IRepository<Student>>().To<DapperRepository>().InSingletonScope();
        }
    }
}
