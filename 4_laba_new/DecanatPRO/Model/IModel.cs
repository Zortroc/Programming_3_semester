using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Представляет метод для передачи обновлённых данных модели.
    /// </summary>
    /// <param name="newData">Обновлённый набор данных.</param>
    public delegate void DataChangedDelegate(IEnumerable<IEnumerable<object>> newData);
    /// <summary>
    /// Определяет интерфейс модели для работы с объектами заданного типа.
    /// </summary>
    /// <typeparam name="T">Тип объектов, с которыми работает модель.</typeparam>
    public interface IModel<T> where T : class
    {
        /// <summary>
        /// Возникает при изменении данных модели и передаёт обновлённые данные.
        /// </summary>
        event DataChangedDelegate DataChanged;
        /// <summary>
        /// Добавляет новый объект в модель.
        /// </summary>
        /// <param name="item">Объект, который необходимо добавить.</param>
        void Insert(T item);
        /// <summary>
        /// Удаляет объект из модели по его индексу.
        /// </summary>
        /// <param name="index">Индекс объекта, который необходимо удалить.</param>
        void Delete(int index);
    }
}