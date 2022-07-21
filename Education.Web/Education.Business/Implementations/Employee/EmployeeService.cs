using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
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

        public Task CreateAsync(CreateEmployeeVM createEmployee)
        {
            throw new NotImplementedException();
            //Core.Entities.Employee employee = _unitOfWork
        }

        public async Task<EmployeeVM> Get(int id)
        {
            Core.Entities.Employee dbEmployee = await _unitOfWork.EmployeeRepository.Get(x => x.Id == id,"Position");
            if (dbEmployee is null) throw new Exception("not");
            EmployeeVM employee = new EmployeeVM
            {
                Id = id,
                FullName = dbEmployee.FullName,
                Age = dbEmployee.Age,
                Position = dbEmployee.Position.Name,
                CreateDate = dbEmployee.CreatedDate
            };
            return employee;
        }

        public async Task<List<EmployeeVM>> GetAll()
        {
            List<Core.Entities.Employee> dbEmployeeList = await _unitOfWork.EmployeeRepository.GetAll(null, "Position");
            List<EmployeeVM> employeeList = new List<EmployeeVM>();
            foreach (var dbEmployee in dbEmployeeList)
            {
                EmployeeVM employee = new EmployeeVM
                {
                    Id = dbEmployee.Id,
                    FullName = dbEmployee.FullName,
                    Age = dbEmployee.Age,
                    Position = dbEmployee.Position.Name,
                    CreateDate = dbEmployee.CreatedDate
                };
                employeeList.Add(employee);
            }
            return employeeList;
        }
    }
}
