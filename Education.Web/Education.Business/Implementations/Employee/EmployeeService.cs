using Education.Business.Interfaces.Employee;
using Education.Core.Interfaces;

namespace Education.Business.Implementations.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Core.Entities.Employee> Get(int id)
        {
            Core.Entities.Employee dbEmployee = await _unitOfWork.EmployeeRepository.Get(x => x.Id == id);
            if (dbEmployee is null) throw new System.Exception("not");
            return dbEmployee;
        }

        public async Task<List<Core.Entities.Employee>> GetAll()
        {
            return await _unitOfWork.EmployeeRepository.GetAll();
        }
    }
}
