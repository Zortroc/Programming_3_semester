namespace Model
{
    /// <summary>
    /// Определяет общий интерфейс для доменных объектов,
    /// имеющих уникальный идентификатор.
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор объекта.
        /// </summary>
        int Id { get; set; }
    }
}
