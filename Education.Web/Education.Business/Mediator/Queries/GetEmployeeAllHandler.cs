using Education.Business.Interfaces.Employee;
using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    internal class GetEmployeeAllHandler : IRequestHandler<GetEmployeeAllQuery, List<Employee>>
    {
        private IEmployeeService _employeeService;

        public GetEmployeeAllHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<List<Employee>> Handle(GetEmployeeAllQuery request, CancellationToken cancellationToken)
        {
            List<Employee> employee = await _employeeService.GetAll();
            return employee;
        }
    }
}
