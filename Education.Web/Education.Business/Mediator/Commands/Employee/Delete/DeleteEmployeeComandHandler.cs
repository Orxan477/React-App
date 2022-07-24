using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Delete
{
    public class DeleteEmployeeComandHandler : IRequestHandler<DeleteEmployeeComand, Core.Entities.Employee>
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public DeleteEmployeeComandHandler(IEmployeeService employeeService, AutoMapper.IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<Core.Entities.Employee> Handle(DeleteEmployeeComand request, CancellationToken cancellationToken)
        {
            EmployeeVM employeeVM =await _employeeService.Get(request.Id);
            Core.Entities.Employee employee=_mapper.Map<Core.Entities.Employee>(employeeVM);
            await _employeeService.Delete(employee);
            return employee;
        }
    }
}
