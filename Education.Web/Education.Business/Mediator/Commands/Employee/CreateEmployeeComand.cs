using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee
{
    public class CreateEmployeeComand:IRequest<EmployeeVM>
    {
        public string Fullname { get; set; }
        public int Age { get; set; }
        public int PositionId { get; set; }
    }
}
