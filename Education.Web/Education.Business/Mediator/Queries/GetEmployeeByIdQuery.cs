using Education.Core.Entities;
using MediatR;

namespace Education.Business.Mediator.Queries
{
    public class GetEmployeeByIdQuery:IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
