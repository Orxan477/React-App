using Education.Business.ViewModels.Employee;
using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    public class GetEmployeeAllQuery:IRequest<List<EmployeeVM>>
    {
    }
}
