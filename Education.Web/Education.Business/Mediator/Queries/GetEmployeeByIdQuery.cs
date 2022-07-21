using Education.Business.ViewModels.Employee;
using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    public class GetEmployeeByIdQuery:IRequest<EmployeeVM>
    {
        public int Id { get; set; }
    }
}
