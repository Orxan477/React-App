namespace Education.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
