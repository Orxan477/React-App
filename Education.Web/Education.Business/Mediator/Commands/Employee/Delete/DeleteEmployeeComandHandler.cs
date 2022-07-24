using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Delete
{
    public class DeleteEmployeeComandHandler : IRequestHandler<DeleteEmployeeComand, EmployeeVM>
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public DeleteEmployeeComandHandler(IEmployeeService employeeService, AutoMapper.IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<EmployeeVM> Handle(DeleteEmployeeComand request, CancellationToken cancellationToken)
        {
            Core.Entities.Employee employee = await _employeeService.Get(request.Id);
            await _employeeService.Delete(employee);
            EmployeeVM employeeVM = _mapper.Map<EmployeeVM>(employee);
            return employeeVM;
        }
    }
}
