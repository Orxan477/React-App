using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.Mediator.Commands.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Interfaces;

namespace Education.Business.Implementations.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(Core.Entities.Employee createEmployee)
        {
            if (createEmployee is null) throw new Exception("not");
            await _unitOfWork.EmployeeRepository.CreateAsync(createEmployee);
            await _unitOfWork.SaveChangeAsync();
            return createEmployee.Id;
        }

        public async Task Delete(Core.Entities.Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Core.Entities.Employee> Get(int id)
        {
            Core.Entities.Employee dbEmployee = await _unitOfWork.EmployeeRepository.Get(x => x.Id == id,"Position");
            if (dbEmployee is null) throw new Exception("not");
            return dbEmployee;
        }

        public async Task<List<Core.Entities.Employee>> GetAll()
        {
            List<Core.Entities.Employee> dbEmployeeList = await _unitOfWork.EmployeeRepository.GetAll(null, "Position");
            List<EmployeeVM> employeeList = new List<EmployeeVM>();
            foreach (var dbEmployee in dbEmployeeList)
            {
                EmployeeVM employee = _mapper.Map<EmployeeVM>(dbEmployee);
                employeeList.Add(employee);
            }
            return dbEmployeeList;
        }
    }
}
