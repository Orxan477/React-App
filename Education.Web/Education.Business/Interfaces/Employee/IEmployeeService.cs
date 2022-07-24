using Education.Business.Mediator.Commands.Employee;
using Education.Business.ViewModels.Employee;

namespace Education.Business.Interfaces.Employee
{
    public interface IEmployeeService
    {
        Task<List<Core.Entities.Employee>> GetAll();
        Task<Core.Entities.Employee> Get(int id);
        Task<int> CreateAsync(Core.Entities.Employee employee);
        Task Delete(Core.Entities.Employee employee);
       
    }
}
