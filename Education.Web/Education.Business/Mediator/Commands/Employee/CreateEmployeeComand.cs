using Education.Business.ViewModels.Employee;
using MediatR;

namespace Education.Business.Mediator.Commands.Employee
{
    internal class CreateEmployeeComand:IRequest<CreateEmployeeVM>
    {
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }
}
