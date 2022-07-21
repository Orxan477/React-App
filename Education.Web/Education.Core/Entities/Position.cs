namespace Education.Core.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
