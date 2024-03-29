﻿using Education.Business.ViewModels.Employee;
using FluentValidation;

namespace Education.Business.Validations.Employee
{
    public class CreateEmployeeVMValidation:AbstractValidator<CreateEmployeeVM>
    {
        public CreateEmployeeVMValidation()
        {
            RuleFor(x=>x.Fullname).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Age).NotNull().NotEmpty();
            RuleFor(x => x.PositionId).NotNull().NotEmpty();
        }
    }
}
