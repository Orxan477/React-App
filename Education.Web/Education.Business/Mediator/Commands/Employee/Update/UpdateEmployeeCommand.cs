using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee.Update
{
    public class UpdateEmployeeCommand:IRequest<EmployeeVM>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public int PositionId { get; set; }
    }
}
