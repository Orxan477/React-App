namespace Education.Business.Interfaces.Employee
{
    public interface IEmployeeService
    {
        Task<List<Core.Entities.Employee>> GetAll();
        Task<Core.Entities.Employee> Get(int id);
    }
}
