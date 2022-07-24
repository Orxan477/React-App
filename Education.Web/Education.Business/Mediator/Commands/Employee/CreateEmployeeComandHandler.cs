using Education.Business.ViewModels.Employee;
using AutoMapper;
using MediatR;
using Education.Business.Interfaces.Employee;

namespace Education.Business.Mediator.Commands.Employee
{
    public class CreateEmployeeComandHandler : IRequestHandler<CreateEmployeeComand, EmployeeVM>
    {
        public IMapper _mapper { get; set; }
        public IEmployeeService _employeeService { get; set; }
        public CreateEmployeeComandHandler(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }
        public async Task<EmployeeVM> Handle(CreateEmployeeComand request, CancellationToken cancellationToken)
        {
            Core.Entities.Employee dbEmployee = _mapper.Map<Core.Entities.Employee>(request);
            int employeeId= await _employeeService.CreateAsync(dbEmployee);
            Core.Entities.Employee employee = await _employeeService.Get(employeeId);
            EmployeeVM employeeVM = _mapper.Map<EmployeeVM>(employee);
            return employeeVM;
        }
    }
}
