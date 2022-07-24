using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Delete
{
    public class DeleteEmployeeComand:IRequest<Core.Entities.Employee>
    {
        public int Id { get; set; }
    }
}
