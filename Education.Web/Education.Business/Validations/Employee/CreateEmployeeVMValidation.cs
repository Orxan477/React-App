using Education.Business.ViewModels.Employee;
using FluentValidation;

namespace Education.Business.Validations.Employee
{
    public class CreateEmployeeVMValidation:AbstractValidator<CreateEmployeeVM>
    {
        public CreateEmployeeVMValidation()
        {
            RuleFor(x=>x.Fullname).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Age).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PositionId).GreaterThanOrEqualTo(0);
        }
    }
}
