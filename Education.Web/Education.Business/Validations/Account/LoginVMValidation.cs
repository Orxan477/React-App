using Education.Business.ViewModels.Account;
using FluentValidation;

namespace Education.Business.Validations.Account
{
    public class LoginVMValidation:AbstractValidator<LoginVM>
    {
        public LoginVMValidation()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().MaximumLength(255);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(255);
        }
    }
}
