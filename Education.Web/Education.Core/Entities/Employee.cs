namespace Education.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public bool IsDeleted { get; set; }
    }
}
