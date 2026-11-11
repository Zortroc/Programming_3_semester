namespace Model
{
    /// <summary>
    /// Описывает сущность студента
    /// </summary>
    public class Student
    {
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
