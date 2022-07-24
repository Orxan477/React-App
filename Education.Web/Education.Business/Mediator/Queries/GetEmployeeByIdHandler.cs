using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    internal class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeVM>
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<EmployeeVM> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Employee employee = await _employeeService.Get(request.Id);
            EmployeeVM employeeVM = _mapper.Map<EmployeeVM>(employee);
            return employeeVM;
        }
    }
}
