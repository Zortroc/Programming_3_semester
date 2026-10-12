using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Определяет общий набор операций для работы с объектами доменной модели.
    /// </summary>
    /// <typeparam name="T">
    /// Тип доменного объекта, который должен реализовывать IDomainObject
    /// и иметь публичный конструктор без параметров.
    /// </typeparam>
    public interface IRepository<T> where T : IDomainObject, new()
    {
        /// <summary>
        /// Добавляет новый объект в хранилище данных.
        /// </summary>
        /// <param name="obj">Объект, который необходимо добавить.</param>
        void Create(T obj);
        /// <summary>
        /// Возвращает все объекты указанного типа из хранилища данных.
        /// </summary>
        /// <returns>Последовательность объектов типа T.</returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// Находит объект по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор искомого объекта.</param>
        /// <returns>Найденный объект типа T.</returns>
        T ReadById(int id);
        /// <summary>
        /// Обновляет данные существующего объекта в хранилище.
        /// </summary>
        /// <param name="obj">Объект с обновлёнными данными.</param>
        void Update(T obj);
        /// <summary>
        /// Удаляет объект из хранилища данных.
        /// </summary>
        /// <param name="obj">Объект, который необходимо удалить.</param>
        void Delete(T obj);
    }
}
