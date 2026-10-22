namespace Model
{
    /// <summary>
    /// Представляет студента и хранит информацию о его идентификаторе,
    /// ФИО, направлении подготовки и учебной группе.
    /// </summary>
    public class Student : IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор студента.
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// ФИО студента.
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Название направления подготовки студента.
        /// </summary>
        public string Speciality { set; get; }
        /// <summary>
        /// Название учебной группы студента.
        /// </summary>
        public string Group { set; get; }
    }
}
