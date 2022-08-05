using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Update
{
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeVM>
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<EmployeeVM> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Core.Entities.Employee employee = await _employeeService.Get(request.Id);
            if (request.PositionId != 0)
            {
                employee.PositionId = request.PositionId;
            }
            if (employee.FullName != request.Fullname)
            {
                employee.FullName = request.Fullname;
            }
            if (request.Age != 0)
            {
                employee.Age = request.Age;
            }
            await _employeeService.Update(employee);
            EmployeeVM updateEmployee=_mapper.Map<EmployeeVM>(employee);
            return updateEmployee;
            
        }
    }
}
