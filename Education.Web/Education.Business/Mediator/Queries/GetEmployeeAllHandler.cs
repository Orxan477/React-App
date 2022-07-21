using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    internal class GetEmployeeAllHandler : IRequestHandler<GetEmployeeAllQuery, List<EmployeeVM>>
    {
        private IEmployeeService _employeeService;

        public GetEmployeeAllHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<List<EmployeeVM>> Handle(GetEmployeeAllQuery request, CancellationToken cancellationToken)
        {
            List<EmployeeVM> employee = await _employeeService.GetAll();
            return employee;
        }
    }
}
