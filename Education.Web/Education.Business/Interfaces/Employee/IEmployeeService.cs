using Education.Business.ViewModels.Employee;

namespace Education.Business.Interfaces.Employee
{
    public interface IEmployeeService
    {
        Task<List<EmployeeVM>> GetAll();
        Task<EmployeeVM> Get(int id);
        Task CreateAsync(CreateEmployeeVM createEmployee);
       
    }
}
