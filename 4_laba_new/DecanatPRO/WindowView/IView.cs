using System.Collections.Generic;

namespace View
{
    /// <summary>
    /// Представляет метод для передачи данных из представления в Presenter
    /// при добавлении нового объекта.
    /// </summary>
    /// <param name="data">Данные нового объекта.</param>
    public delegate void AddDataDelegate(IEnumerable<object> data);
    /// <summary>
    /// Представляет метод для передачи индекса удаляемого объекта.
    /// </summary>
    /// <param name="index">Индекс объекта, который необходимо удалить.</param>
    public delegate void DeleteDataDelegate(int index);
    /// <summary>
    /// Определяет интерфейс представления для взаимодействия с пользователем.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Возникает при запросе пользователя на добавление нового объекта.
        /// </summary>
        event AddDataDelegate AddDataEvent;
        /// <summary>
        /// Возникает при запросе пользователя на удаление объекта.
        /// </summary>
        event DeleteDataDelegate DeleteDataEvent;
        /// <summary>
        /// Обновляет отображаемые данные представления.
        /// </summary>
        /// <param name="data">Данные, которые необходимо отобразить.</param>
        void RedrawForm(IEnumerable<IEnumerable<object>> data);
    }
}