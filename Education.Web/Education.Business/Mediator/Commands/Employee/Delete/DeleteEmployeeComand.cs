using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Delete
{
    public class DeleteEmployeeComand:IRequest<EmployeeVM>
    {
        public int Id { get; set; }
    }
}
