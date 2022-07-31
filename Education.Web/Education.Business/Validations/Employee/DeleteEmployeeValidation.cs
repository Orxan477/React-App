using Education.Business.Mediator.Commands.Employee.Delete;
using FluentValidation;

namespace Education.Business.Validations.Employee
{
    public class DeleteEmployeeValidation:AbstractValidator<DeleteEmployeeComand>
    {
        public DeleteEmployeeValidation()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull();
        }
    }
}
