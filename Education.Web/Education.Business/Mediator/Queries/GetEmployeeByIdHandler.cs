using Education.Business.Interfaces.Employee;
using Education.Business.ViewModels.Employee;
using Education.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Business.Mediator.Queries
{
    internal class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeVM>
    {
        private IEmployeeService _employeeService;

        public GetEmployeeByIdHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<EmployeeVM> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            EmployeeVM employee = await _employeeService.Get(request.Id);
            return employee;
        }
    }
}
