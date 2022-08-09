using Education.Business.ViewModels.Account;
using FluentValidation;

namespace Education.Business.Validations.Account
{
    public class RegisterVMValidation:AbstractValidator<RegisterVM>
    {
        public RegisterVMValidation()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Password).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x=>x.ConfirmPassword).Equal(RuleFor(x => x.Password).ToString()).NotNull().NotEmpty();
        }
    }
}