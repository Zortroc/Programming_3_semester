namespace Model
{
    public class Student : IDomainObject
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Speciality { set; get; }
        public string Group { set; get; }
    }
}
