using Education.Business.Mediator.Commands.Employee;
using Education.Business.ViewModels.Employee;

namespace Education.Business.Interfaces.Employee
{
    public interface IEmployeeService
    {
        Task<List<EmployeeVM>> GetAll();
        Task<EmployeeVM> Get(int id);
        Task<int> CreateAsync(Core.Entities.Employee employee);
       
    }
}
