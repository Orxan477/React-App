using AutoMapper;
using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    internal class GetEmployeeAllHandler : IRequestHandler<GetEmployeeAllQuery, List<EmployeeVM>>
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public GetEmployeeAllHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<List<EmployeeVM>> Handle(GetEmployeeAllQuery request, CancellationToken cancellationToken)
        {
            List<Employee> employee = await _employeeService.GetAll();
            List<EmployeeVM> employeeVM = _mapper.Map<List<EmployeeVM>>(employee);
            return employeeVM;
        }
    }
}
